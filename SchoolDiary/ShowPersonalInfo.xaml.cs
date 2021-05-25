using System.Windows;
using System.Data.SqlClient;

namespace SchoolDiary
{
    public partial class ShowPersonalInfo : Window
    {
        SqlConnection connection;
        Window parent;
        public ShowPersonalInfo(SqlConnection connection, string email, Window parent)
        {
            InitializeComponent();
            this.Show();
            this.connection = connection;
            this.parent = parent;
            parent.Visibility = Visibility.Hidden;
            try
            {
                string sqlExpression = " SELECT last_name, first_name, mid_name, date_of_birth, email, code_group FROM dbo.STUDENTS WHERE (email = '" + email + "') ";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    last_name.Content = reader.GetString(0);
                    first_name.Content = reader.GetString(1);
                    mid_name.Content = reader.GetString(2);
                    dob.Content = reader.GetDateTime(3).ToString("yyyy.dd.MM");
                    mail.Content = reader.GetString(4);
                    group.Content = reader.GetString(5);

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
    }
}
