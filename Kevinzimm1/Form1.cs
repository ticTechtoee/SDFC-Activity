using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Kevinzimm1
{
    public partial class sdfcactivityFrm : Form
    {
        private const string filePath = @"D:\Development\Kevinzimm1\Requirements\Backup.xlsx";
        private const string sheetName1 = "Staff";
        private const string sheetName2 = "Data Fields";

        public sdfcactivityFrm()
        {
            InitializeComponent();
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            LoadStaffNames();
            LoadActivities();
        }

        private void LoadStaffNames()
        {
            try
            {
                // Connection string for Excel files
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0 Xml;HDR=YES';";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Select staff names from the "Staff" sheet
                    string selectQuery1 = $"SELECT [Name] FROM [{sheetName1}$]";
                    using (OleDbCommand command1 = new OleDbCommand(selectQuery1, connection))
                    {
                        using (OleDbDataReader reader1 = command1.ExecuteReader())
                        {
                            // Extract staff names
                            while (reader1.Read())
                            {
                                string name = reader1["Name"].ToString();
                                CmbBoxStaffName.Items.Add(name);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }

        }

        private void LoadActivities()
        {
            try
            {
                // Connection string for Excel files
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0 Xml;HDR=YES';";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Select activities from the "Data Fields" sheet
                    string selectQuery2 = $"SELECT [Activities] FROM [{sheetName2}$]";
                    using (OleDbCommand command2 = new OleDbCommand(selectQuery2, connection))
                    {
                        using (OleDbDataReader reader2 = command2.ExecuteReader())
                        {
                            // Extract activities
                            while (reader2.Read())
                            {
                                string activity = reader2["Activities"].ToString();
                                CmbActivities.Items.Add(activity);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

            private List<StaffItem> staffItems = new List<StaffItem>();
        private void txtStaffCode_TextChanged(object sender, EventArgs e)
        {

            // Find the corresponding staff name based on the entered code
            string enteredCode = txtStaffCode.Text.Trim();
            StaffItem selectedStaff = staffItems.FirstOrDefault(item => item.Code == enteredCode);

            if (selectedStaff != null)
            {
                CmbBoxStaffName.SelectedItem = selectedStaff;
            }
            else
            {
                CmbBoxStaffName.SelectedIndex = -1; // No match found, clear selection
            }

        }

    private class StaffItem
        {
            public string Code { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return $"{Name}";
            }
        }
    }
}
