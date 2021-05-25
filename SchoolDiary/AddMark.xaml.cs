using System;
using System.Windows;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SchoolDiary
{
    public partial class AddMark : Window
    {

        public class student
        {
            public string id_student { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string mid_name { get; set; }
            public string dob { get; set; }
        }


        SqlConnection connection;
        Window parent;
        string email;
        private Dictionary<string, string> map;
        public AddMark(SqlConnection connection, string email, Window parent)
        {
            InitializeComponent();
            map = new Dictionary<string, string>();
            this.Show();
            this.connection = connection;
            this.parent = parent;
            parent.Visibility = Visibility.Hidden;
            this.email = email;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Close();

        }

        private void select_subject_group(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            string selected_state = box_subject.SelectedItem.ToString();
            try
            {
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
                    date_lesson_box.Items.Clear();
                    //marks_box.Items.Clear();
                    grid.ItemsSource = null;
                    marks_box.Visibility = Visibility.Hidden;
                    date_lesson_box.Visibility = Visibility.Hidden;
                    set_mark.Visibility = Visibility.Hidden;
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
            if (box_subject.SelectedItem != null && group.SelectedItem !=null) {

                try
                {
                    string selected_state_group = group.SelectedItem.ToString();
                    string selected_stat_subject = box_subject.SelectedItem.ToString();
                    List<student> student_list = new List<student>();

                    string sqlExpression = "SELECT DISTINCT code_student, last_name, first_name, mid_name, date_of_birth FROM dbo.STUDENTS WHERE(code_group = '" + selected_state_group + "')";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            student s = new student();
                            s.id_student = reader.GetString(0);
                            s.last_name = reader.GetString(1);
                            s.first_name = reader.GetString(2);
                            s.mid_name = reader.GetString(3);
                            s.dob = reader.GetDateTime(4).ToString("yyyy.dd.MM");
                            student_list.Add(s);

                        }
                        grid.ItemsSource = student_list;
                        reader.Close();
                        grid.Columns[0].Header = "Номер";
                        grid.Columns[1].Header = "Фамилия";
                        grid.Columns[2].Header = "Имя";
                        grid.Columns[3].Header = "Отчество";
                        grid.Columns[4].Header = "Дата рождения";
                    }
                    else
                    {
                        reader.Close();
                    }

                    
                    for (int i = 2; i <= 5; i++)
                    {
                        marks_box.Items.Add(i);

                    }

                    marks_box.Visibility = Visibility.Visible;
                    set_mark.Visibility = Visibility.Visible;
                    date_lesson_box.Visibility = Visibility.Visible;

                    sqlExpression = " SELECT DISTINCT dbo.LESSONS.code_lesson, dbo.LESSONS.date "
                     + "  FROM dbo.LESSONS INNER JOIN "
                     + "  dbo.GROUPS ON dbo.LESSONS.code_group = dbo.GROUPS.code_group INNER JOIN "
                     + " dbo.EDUCATION ON dbo.LESSONS.code_education = dbo.EDUCATION.code_education INNER JOIN "
                     + " dbo.SUBJECTS ON dbo.EDUCATION.code_subject = dbo.SUBJECTS.code_subject "
                     + "  WHERE(dbo.GROUPS.code_group = '" + selected_state_group + "') AND(dbo.SUBJECTS.name_subject = '" + selected_stat_subject + "') ";

                    command = new SqlCommand(sqlExpression, connection);
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {

                            string id_lesson = reader.GetString(0);
                            string date_lesson = reader.GetDateTime(1).ToString("yyyy.dd.MM");
                            date_lesson_box.Items.Add(date_lesson);
                            map[date_lesson] = id_lesson;

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

        }

        private void set_mark_Click(object sender, RoutedEventArgs e)
        {
            student student_local = (student)grid.SelectedItem;
            if (student_local == null)
            {
                return;
            }

            if (date_lesson_box.SelectedItem != null && marks_box.SelectedItem != null)
            {

                string id_stat = DateTime.Now.ToString("yyyyddMMss");
                string id_group = group.SelectedItem.ToString();
                string id_stud = student_local.id_student;
                string id_lesson = map[date_lesson_box.Text];
                string mark = marks_box.SelectedItem.ToString();

                try
                {
                    string sqlExpression = "INSERT INTO STAT VALUES(@stat_value,@group_value,@stud_value,@lesson_value,@mark_value)";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter id_stat_par = new SqlParameter("@stat_value", id_stat);
                    SqlParameter id_group_par = new SqlParameter("@group_value", id_group);
                    SqlParameter id_stud_par = new SqlParameter("@stud_value", id_stud);
                    SqlParameter id_lesson_par = new SqlParameter("@lesson_value", id_lesson);
                    SqlParameter id_mark_par = new SqlParameter("@mark_value", mark);

                    command.Parameters.Add(id_stat_par);
                    command.Parameters.Add(id_group_par);
                    command.Parameters.Add(id_stud_par);
                    command.Parameters.Add(id_lesson_par);
                    command.Parameters.Add(id_mark_par);

                    command.ExecuteNonQuery();
                }
                catch (SqlException er)
                {
                    MessageBox.Show("Ошибка подключения" + er.ToString());
                }
                MessageBox.Show("Оценка выставлена");
                
            }
        }
    }
}
