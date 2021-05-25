using System.Windows;
using System.Data.SqlClient;

namespace SchoolDiary
{
    public partial class Teacher_menu : Window
    {

        SqlConnection connection;
        Window parent;
        public Teacher_menu(SqlConnection connection, string email, Window parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.connection = connection;
            parent.Visibility = Visibility.Hidden;
            this.Show();
            add_mark.Click += (e, w) => new AddMark(connection, email, this);
            check_all_stat.Click += (e, w) => new CheckStat(connection, email, this);
            edit_marks.Click += (e, w) => new EditMark(connection, email, this);
            check_groups.Click += (e, w) => new CheckGroup(connection, this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
