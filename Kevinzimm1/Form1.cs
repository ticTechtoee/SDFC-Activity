using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Kevinzimm1
{
    public partial class sdfcactivityFrm : Form
    {
        public sdfcactivityFrm()
        {
            InitializeComponent();
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\Development\Kevinzimm1\Requirements\Activity Tracker Project VB.xlsx";
            string sheetName = "staff";

            // Connection string for Excel files
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0 Xml;HDR=YES';";

            // SQL query to select data from the specified sheet
            string query = $"SELECT * FROM [{sheetName}$]";

            // Create an OleDbConnection and OleDbCommand
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    // Use OleDbDataAdapter to fill a DataTable
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Display the data
                        foreach (DataRow row in dataTable.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                
                                txtSbj.Text += item;
                            }
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    
                }
            }
        }
    }
}
