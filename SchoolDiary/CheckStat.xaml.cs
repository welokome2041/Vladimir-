using System.Windows;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SchoolDiary
{
    public partial class CheckStat : Window
    {
        SqlConnection connection;
        Window parent;
        string email;

        public class stat_group
        {
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string mid_name { get; set; }
            public string dob { get; set; }
            public int avg { get; set; }

        }

        public CheckStat(SqlConnection connection, string email, Window parent)
        {
            InitializeComponent();
            this.Show();
            this.connection = connection;
            this.email = email;
            this.parent = parent;
            parent.Visibility = Visibility.Hidden;
            try
            {
                string sqlExpression = "SELECT dbo.EDUCATION.code_subject, dbo.SUBJECTS.name_subject "
                   + " FROM dbo.EDUCATION INNER JOIN "
                   + "  dbo.SUBJECTS ON dbo.EDUCATION.code_subject = dbo.SUBJECTS.code_subject INNER JOIN "
                   + " dbo.TEACHERS ON dbo.EDUCATION.code_teacher = dbo.TEACHERS.code_teacher "
                   + " WHERE(dbo.TEACHERS.email = '" + email + "')";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    group.Items.Clear();
                    while (reader.Read())
                    {
                        string local_id_sub = reader.GetString(0);
                        string local_name_sub = reader.GetString(1);
                        box_subject.Items.Add(local_name_sub);

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

        private void select_subject_group(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            try
            {
                string selected_state = box_subject.SelectedItem.ToString();
                string sqlExpression = "SELECT DISTINCT dbo.LESSONS.code_group " +
                     " FROM dbo.EDUCATION INNER JOIN " +
                     " dbo.TEACHERS ON dbo.EDUCATION.code_teacher = dbo.TEACHERS.code_teacher INNER JOIN " +
                     " dbo.LESSONS ON dbo.EDUCATION.code_education = dbo.LESSONS.code_education INNER JOIN " +
                     " dbo.SUBJECTS ON dbo.EDUCATION.code_subject = dbo.SUBJECTS.code_subject " +
                     " WHERE(dbo.TEACHERS.email = '" + email + "') AND(dbo.SUBJECTS.name_subject = '" + selected_state + "')";

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    group.Items.Clear();

                    grid.ItemsSource = null;

                    while (reader.Read())
                    {

                        string local_group = reader.GetString(0);
                        group.Items.Add(local_group);

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

        private void _continue_Click(object sender, RoutedEventArgs e)
        {
            if (group.SelectedItem != null && box_subject.SelectedItem != null)
            {
                string selected_state_group = group.SelectedItem.ToString();
                string selected_stat_subject = box_subject.SelectedItem.ToString();
                List<stat_group> group_list = new List<stat_group>();
                try
                {
                    string sqlExpression = "SELECT dbo.STUDENTS.last_name, dbo.STUDENTS.first_name, dbo.STUDENTS.mid_name, dbo.STUDENTS.date_of_birth, AVG(dbo.STAT.mark) AS AVG "
                      + " FROM dbo.STUDENTS INNER JOIN "
                      + " dbo.STAT ON dbo.STUDENTS.code_student = dbo.STAT.code_student AND dbo.STUDENTS.code_group = dbo.STAT.code_group INNER JOIN "
                      + "   dbo.LESSONS ON dbo.STAT.code_lesson = dbo.LESSONS.code_lesson INNER JOIN "
                      + "  dbo.EDUCATION ON dbo.LESSONS.code_education = dbo.EDUCATION.code_education INNER JOIN "
                      + "  dbo.SUBJECTS ON dbo.EDUCATION.code_subject = dbo.SUBJECTS.code_subject "
                      + " GROUP BY dbo.STUDENTS.last_name, dbo.STUDENTS.first_name, dbo.STUDENTS.mid_name, dbo.STUDENTS.date_of_birth, dbo.SUBJECTS.name_subject, dbo.STUDENTS.code_group "
                      + " HAVING(dbo.SUBJECTS.name_subject = '" + selected_stat_subject + "') AND(dbo.STUDENTS.code_group = '" + selected_state_group + "')";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            stat_group s = new stat_group();
                            s.last_name = reader.GetString(0);
                            s.first_name = reader.GetString(1);
                            s.mid_name = reader.GetString(2);
                            s.dob = reader.GetDateTime(3).ToString("yyyy.dd.MM");
                            s.avg = reader.GetInt32(4);

                            group_list.Add(s);

                        }
                        grid.ItemsSource = group_list;
                        
                        grid.Columns[0].Header = "Фамилия";
                        grid.Columns[1].Header = "Имя";
                        grid.Columns[2].Header = "Отчество";
                        grid.Columns[3].Header = "Дата рождения";
                        grid.Columns[4].Header = "Средний бал";
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
        }


        private void back_to(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
