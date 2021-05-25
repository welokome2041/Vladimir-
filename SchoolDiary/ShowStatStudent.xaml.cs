using System.Windows;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SchoolDiary
{
    public class student_stat
    {
        public string date { get; set; }
        public int mark { get; set; }
        public string teacher { get; set; }
    }

    public partial class ShowStatStudent : Window
    {
        SqlConnection connection;
        Window parent;
        string email;

        private Dictionary<string, string> map;
        public ShowStatStudent(SqlConnection connection, string email, Window parent)
        {
            InitializeComponent();
            map = new Dictionary<string, string>();
            this.connection = connection;
            this.parent = parent;
            this.email = email;
            parent.Visibility = Visibility.Hidden;
            this.Show();
            try
            {
                string sqlExpression = "SELECT code_subject, name_subject FROM dbo.SUBJECTS";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string local_id_sub = reader.GetString(0);
                        string local_name_sub = reader.GetString(1);
                        box_subject.Items.Add(local_name_sub);
                        map[local_name_sub] = local_id_sub;
                    }
                    reader.Close();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Close();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = null;
            if (box_subject.SelectedItem != null) {
                string local_subject = map[box_subject.Text];

                try
                {
                    string sqlExpression = "SELECT dbo.LESSONS.date, dbo.STAT.mark, dbo.TEACHERS.last_name + ' ' + LEFT(dbo.TEACHERS.first_name, 1) + '.' + LEFT(dbo.TEACHERS.mid_name, 1) + '.' AS init "
                        + " FROM dbo.LESSONS INNER JOIN "
                        + "  dbo.STAT ON dbo.LESSONS.code_lesson = dbo.STAT.code_lesson INNER JOIN "
                        + " dbo.EDUCATION ON dbo.LESSONS.code_education = dbo.EDUCATION.code_education INNER JOIN "
                        + " dbo.TEACHERS ON dbo.EDUCATION.code_teacher = dbo.TEACHERS.code_teacher INNER JOIN "
                        + " dbo.STUDENTS ON dbo.STAT.code_student = dbo.STUDENTS.code_student AND dbo.STAT.code_group = dbo.STUDENTS.code_group "
                        + " WHERE(dbo.STUDENTS.email = '" + email + "' AND (dbo.EDUCATION.code_subject = '" + local_subject + "'))";

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    List<student_stat> stat_list = new List<student_stat>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            student_stat s = new student_stat();

                            s.date = reader.GetDateTime(0).ToString("yyyy.dd.MM");
                            s.mark = reader.GetInt32(1);
                            s.teacher = reader.GetString(2);
                            stat_list.Add(s);
                        }
                        reader.Close();
                        grid.ItemsSource = stat_list;
                        grid.Columns[0].Header = "Дата оценки";
                        grid.Columns[1].Header = "Оценка";
                        grid.Columns[2].Header = "Учитель";


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
