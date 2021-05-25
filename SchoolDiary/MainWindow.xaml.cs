using System.Data.SqlClient;
using System.Windows;

namespace SchoolDiary
{

    public partial class MainWindow : Window
    {
        private SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = @"DESKTOP-ARHG322\SQLEXPRESS",
                    InitialCatalog = "S_Diary",
                    IntegratedSecurity = true
                };
                connection = new SqlConnection(builder.ConnectionString);

            }
            catch (SqlException e)
            {
                MessageBox.Show("Ошибка подключения" + e.ToString());
            }
            connection.Open();
        }

        private void EntryStudent(object sender, RoutedEventArgs e)
        {
            en_teacher.Visibility = Visibility.Hidden;
            check_correct.Visibility = Visibility.Hidden;
            en_student.Visibility = Visibility.Visible;

            if (login_text.Text.Length > 0 && password_text.Password.Length > 0)
            {

                try
                {
                    SqlParameter login_parameter = new SqlParameter("@login_val", login_text.Text);
                    SqlParameter password_parameter = new SqlParameter("@password_val", password_text.Password);
                    string sqlExpression = "SELECT email FROM dbo.USERS WHERE(email = @login_val AND password_text = @password_val AND code_role = '2')";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.Add(login_parameter);
                    command.Parameters.Add(password_parameter);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        sqlExpression = " SELECT dbo.USERS.email, dbo.STUDENTS.code_group, dbo.STUDENTS.last_name, dbo.STUDENTS.first_name, dbo.STUDENTS.mid_name, dbo.USERS.code_role "
                        + " FROM dbo.USERS INNER JOIN "
                        + " dbo.STUDENTS ON dbo.USERS.email = dbo.STUDENTS.email " +
                              " WHERE(dbo.Users.email = @login_val) ";
                        command = new SqlCommand(sqlExpression, connection);
                        login_parameter = new SqlParameter("@login_val", login_text.Text);
                        command.Parameters.Add(login_parameter);
                        reader = command.ExecuteReader();
                        reader.Read();

                        string email = reader.GetString(0);
                        string code_group = reader.GetString(1);
                        string last_name = reader.GetString(2);
                        string first_name = reader.GetString(3);
                        string middle_name = reader.GetString(4);
                        int id_role = reader.GetInt32(5);
                        reader.Close();
                        password_text.Password = "";
                        check_correct.Visibility = Visibility.Hidden;
                        new Student_menu(connection, email, this, code_group);

                    }
                    else
                    {
                        reader.Close();
                        check_correct.Visibility = Visibility.Visible;
                    }
                }
                catch (SqlException er)
                {
                    MessageBox.Show("Ошибка подключения" + er.ToString());
                }
            }

        }

        private void EntryTeacher(object sender, RoutedEventArgs e)
        {
            en_student.Visibility = Visibility.Hidden;
            check_correct.Visibility = Visibility.Hidden;
            en_teacher.Visibility = Visibility.Visible;

            if (login_text.Text.Length > 0 && password_text.Password.Length > 0)
            {
                try
                {
                    SqlParameter login_parameter = new SqlParameter("@login_val", login_text.Text);
                    SqlParameter password_parameter = new SqlParameter("@password_val", password_text.Password);
                    string sqlExpression = "SELECT email FROM dbo.USERS WHERE(email = @login_val AND password_text = @password_val AND code_role = '1')";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.Add(login_parameter);
                    command.Parameters.Add(password_parameter);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        sqlExpression = " SELECT dbo.USERS.email, dbo.TEACHERS.last_name, dbo.TEACHERS.first_name, dbo.TEACHERS.mid_name, dbo.USERS.code_role " +
                        " FROM dbo.USERS INNER JOIN "
                         + " dbo.TEACHERS ON dbo.USERS.email = dbo.TEACHERS.email " +
                              " WHERE(dbo.Users.email = @login_val) ";
                        command = new SqlCommand(sqlExpression, connection);
                        login_parameter = new SqlParameter("@login_val", login_text.Text);
                        command.Parameters.Add(login_parameter);
                        reader = command.ExecuteReader();
                        reader.Read();

                        string email = reader.GetString(0);
                        string last_name = reader.GetString(1);
                        string first_name = reader.GetString(2);
                        string middle_name = reader.GetString(3);
                        int id_role = reader.GetInt32(4);
                        reader.Close();
                        password_text.Password = "";
                        check_correct.Visibility = Visibility.Hidden;
                        new Teacher_menu(connection, email, this);

                    }
                    else
                    {
                        reader.Close();
                        check_correct.Visibility = Visibility.Visible;
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
