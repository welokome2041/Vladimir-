using System;
using System.Windows;
using System.Data.SqlClient;

namespace SchoolDiary
{

    public partial class Student_menu : Window
    {
        Window parent;
        SqlConnection connection;
        string email;
        public Student_menu(SqlConnection connection, string email, Window parent, string code_group)
        {
            InitializeComponent();
            this.parent = parent;
            this.connection = connection;
            this.email = email;
            parent.Visibility = Visibility.Hidden;
            this.Show();
            Check_stat.Click += (e, w) => new ShowStatStudent(connection, email, this);
            time_table.Click += (e, w) => new ShowTimeTable(connection, code_group, this);
            personal_info.Click += (e, w) => new ShowPersonalInfo(connection, email, this);

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
