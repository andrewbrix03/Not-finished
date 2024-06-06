using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace BillingSystemDesgin
{

    public partial class Blank : Form
    {
        public Blank()
        {
            InitializeComponent();
            LoadRegisteredAccounts();
            button2.Click += button2_Click;
        }

       

        private void LoadRegisteredAccounts()
        {
            string connectionString = "Data Source=DESKTOP-TU0VOQH\\SQLEXPRESS;Initial Catalog=Register;Integrated Security=True";
            string query = "SELECT contact_number, contact_name, contact_password, electric_bill, water_bill, cable_bill FROM Registration";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoginPage form1 = new LoginPage();
            form1.Show();
            this.Hide();
        }
    }
}
