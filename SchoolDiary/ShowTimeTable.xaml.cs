using System.Collections.Generic;
using System.Windows;
using System.Data.SqlClient;

namespace SchoolDiary
{

    public class time_table
    {
        public string subject { get; set; }
        public string teacher { get; set; }
    }

    public partial class ShowTimeTable : Window
    {
        SqlConnection connection;
        Window parent;
        string code_group;
        public ShowTimeTable(SqlConnection connection, string code_group, Window parent)
        {
            InitializeComponent();
            this.Show();
            this.parent = parent;
            this.connection = connection;
            this.code_group = code_group;
            parent.Visibility = Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Close();
        }

        private void check_table_Click(object sender, RoutedEventArgs e)
        {

            if (sel_dat.SelectedDate != null) {
                string local_date = sel_dat.SelectedDate.ToString();
                string date_show = sel_dat.DisplayDate.ToString("dddd yyyy.dd.MM");
                grid.ItemsSource = null;
                lab_inf.Content = "Расписание на " + date_show + " для группы " + code_group;
                try
                {
                    string sqlExpression = " SELECT dbo.SUBJECTS.name_subject, dbo.TEACHERS.last_name + ' ' + LEFT(dbo.TEACHERS.first_name, 1) + '.' + LEFT(dbo.TEACHERS.mid_name, 1) + '.' AS init "
                         + " FROM dbo.EDUCATION INNER JOIN "
                         + "  dbo.LESSONS ON dbo.EDUCATION.code_education = dbo.LESSONS.code_education INNER JOIN "
                         + " dbo.SUBJECTS ON dbo.EDUCATION.code_subject = dbo.SUBJECTS.code_subject INNER JOIN "
                         + "  dbo.TEACHERS ON dbo.EDUCATION.code_teacher = dbo.TEACHERS.code_teacher "
                         + "  WHERE(dbo.LESSONS.date = '" + local_date + "') AND(dbo.LESSONS.code_group = '" + code_group + "')";

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    List<time_table> table_list = new List<time_table>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            time_table s = new time_table();
                            s.subject = reader.GetString(0);
                            s.teacher = reader.GetString(1);
                            table_list.Add(s);
                        }
                        reader.Close();
                        grid.ItemsSource = table_list;
                        grid.Columns[0].Header = "Предмет";
                        grid.Columns[1].Header = "Преподаватель";


                    }
                    else
                    {
                        reader.Close();

                    }
                }
                catch (SqlException er)
                {
                    MessageBox.Show("Ошибка подключения" + er.ToString());
                }
            }
        }
    }
}
