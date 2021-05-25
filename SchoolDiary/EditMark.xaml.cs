using System.Windows;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace SchoolDiary
{
    public class stat_edit
    {
        public string code_group { get; set; }
        public string code_student { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string mid_name { get; set; }
        public string dob { get; set; }
        public int mark { get; set; }
        public string date { get; set; }
        public string stat { get; set; }
    }
    public partial class EditMark : Window
    {
        SqlConnection connection;
        Window parent;
        string email;
        public EditMark(SqlConnection connection, string email, Window parent)
        {
            InitializeComponent();
            for (int i = 2; i <= 5; i++)
            {
                marks_box.Items.Add(i);

            }
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

        public void update_student_info()
        {

            string selected_state_group = group.SelectedItem.ToString();
            string selected_stat_subject = box_subject.SelectedItem.ToString();
            List<stat_edit> edit_list = new List<stat_edit>();
            try
            {
                string sqlExpression = " SELECT dbo.STUDENTS.code_group, dbo.STUDENTS.code_student, dbo.STUDENTS.last_name, dbo.STUDENTS.first_name, dbo.STUDENTS.mid_name, dbo.STUDENTS.date_of_birth, dbo.STAT.mark, dbo.LESSONS.date, dbo.STAT.code_stat"
                    + " FROM dbo.STUDENTS INNER JOIN "
                    + "  dbo.STAT ON dbo.STUDENTS.code_student = dbo.STAT.code_student AND dbo.STUDENTS.code_group = dbo.STAT.code_group INNER JOIN "
                    + " dbo.LESSONS ON dbo.STAT.code_lesson = dbo.LESSONS.code_lesson INNER JOIN "
                    + " dbo.EDUCATION ON dbo.LESSONS.code_education = dbo.EDUCATION.code_education INNER JOIN "
                    + "  dbo.SUBJECTS ON dbo.EDUCATION.code_subject = dbo.SUBJECTS.code_subject "
                    + " WHERE(dbo.SUBJECTS.name_subject = '" + selected_stat_subject + "') AND(dbo.STUDENTS.code_group = '" + selected_state_group + "')";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        stat_edit s = new stat_edit();
                        s.code_group = reader.GetString(0);
                        s.code_student = reader.GetString(1);

                        s.last_name = reader.GetString(2);
                        s.first_name = reader.GetString(3);
                        s.mid_name = reader.GetString(4);
                        s.dob = reader.GetDateTime(5).ToString("yyyy.dd.MM");
                        s.mark = reader.GetInt32(6);
                        s.date = reader.GetDateTime(7).ToString("yyyy.dd.MM");
                        s.stat = reader.GetString(8);
                        edit_list.Add(s);

                    }
                    grid.ItemsSource = edit_list;
                    reader.Close();
                    grid.Columns[0].Visibility = Visibility.Hidden;
                    grid.Columns[1].Visibility = Visibility.Hidden;
                    grid.Columns[8].Visibility = Visibility.Hidden;
                    grid.Columns[2].Header = "Фамилия";
                    grid.Columns[3].Header = "Имя";
                    grid.Columns[4].Header = "Отчество";
                    grid.Columns[5].Header = "Дата рождения";
                    grid.Columns[6].Header = "Оценка";
                    grid.Columns[7].Header = "Дата оценки";
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
            edit_but.Visibility = Visibility.Visible;
            marks_box.Visibility = Visibility.Visible;


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
                update_student_info();
            }

        }

        private void back_to_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (marks_box.SelectedItem != null)
            {
                stat_edit stud = (stat_edit)grid.SelectedItem;
                try
                {
                    if (stud != null)
                    {
                        string id_student = stud.code_student;
                        string id_group = stud.code_group;
                        string mark = marks_box.SelectedItem.ToString();
                        string id_stat = stud.stat;
                        string sqlExpression = "UPDATE STAT SET mark = '" + mark + "' where (code_student = '" + id_student + "' ) AND (code_group = '" + id_group + "') AND (code_stat = '" + id_stat + "')";
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Оценка изменена");
                        marks_box.SelectedItem = null;
                        update_student_info();
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
