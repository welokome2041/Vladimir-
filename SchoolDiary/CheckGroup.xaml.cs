using System.Windows;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SchoolDiary
{
    public class group
    {
        public string id_special { get; set; }
        public string code_group { get; set; }
    }
    public partial class CheckGroup : Window
    {


        SqlConnection connection;
        Window parent;
        public CheckGroup(SqlConnection connection, Window parent)
        {

            InitializeComponent();
            parent.Visibility = Visibility.Hidden;
            this.connection = connection;
            this.parent = parent;
            this.Show();
            update_grid();
        }

        public void update_grid()
        {
            try
            {
                string sqlExpression = "SELECT code_spec, code_group FROM dbo.GROUPS";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<group> group_list = new List<group>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        group s = new group();
                        s.id_special = reader.GetString(0);
                        s.code_group = reader.GetString(1);
                        group_list.Add(s);



                    }

                    grid.ItemsSource = group_list;
                    reader.Close();
                    grid.Columns[0].Header = "Специальность";
                    grid.Columns[1].Header = "Номер группы";

                }
                else
                {

                    reader.Close();

                }
            }
            catch (SqlException er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.Visibility = Visibility.Visible;
            this.Close();
        }


        public static string check_gr(string name_gr)
        {
            if (name_gr.Length == 0)
            {
                return "error";
            }

            string name_gr_loc = name_gr.Trim();
            if (name_gr_loc.Length == 0)
            {
                return "error";

            }
            if (name_gr_loc.Length > 49)
            {
                return "error";
            }

            Regex regex = new Regex(@"^([А-яЁё]+)((-|\s)[0-9]+)*$");
            if (!regex.IsMatch(name_gr_loc))
            {
                return "error";
            }

            return "";
        }


        private void edit_but_Click(object sender, RoutedEventArgs e)
        {
            bool error = false;
            string error_mes = "";

            group group_local = (group)grid.SelectedItem;
            if (group_local == null)
            {
                return;
            }

            if ((error_mes = check_gr(gr_name.Text)) != "")
            {
                error = true;
            }

            if (!error)
            {
                string new_name_gr = gr_name.Text;
                string id_gr = group_local.code_group;

                try
                {

                    string sqlExpression = "UPDATE dbo.GROUPS SET code_group = '" + new_name_gr + "' WHERE code_group = '" + id_gr + "'";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
                catch (SqlException er)
                {
                    MessageBox.Show("Ошибка подключения" + er.ToString());
                }
                MessageBox.Show("группа изменена");
                update_grid();
            }
        }
    }
}
