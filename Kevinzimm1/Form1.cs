using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Kevinzimm1
{
    public class StaffData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Supervisor { get; set; }
        public string SupervisorEmail { get; set; }

        // Add any additional fields you need
    }
    public partial class sdfcactivityFrm : Form
    {
       


        private string filePath;
        private const string sheetName1 = "Staff";
        private const string sheetName2 = "Data Fields";

        private Dictionary<string, StaffData> codeToNameMap = new Dictionary<string, StaffData>();

        private List<StaffData> staffDataList = new List<StaffData>();

        private string Associate_Name;
        private string Associate_Email;
        private string Supervisor_Name;
        private string Supervisor_Email;



        public sdfcactivityFrm()
        {
            InitializeComponent();
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                filePath = selectedFilePath;

                LoadStaffNames();
                LoadActivities();
            }
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
                    string selectQuery1 = $"SELECT [Code], [Name], [Email], [Supervisor], [Supervisor Email] FROM [{sheetName1}$]";
                    using (OleDbCommand command1 = new OleDbCommand(selectQuery1, connection))
                    {
                        using (OleDbDataReader reader1 = command1.ExecuteReader())
                        {
                            // Extract staff names and codes
                            while (reader1.Read())
                            {
                                StaffData staffData = new StaffData
                                {
                                    Code = reader1["Code"].ToString(),
                                    Name = reader1["Name"].ToString(),
                                    Email = reader1["Email"].ToString(),
                                    Supervisor = reader1["Supervisor"].ToString(),
                                    SupervisorEmail = reader1["Supervisor Email"].ToString(),
                                    // Add additional fields here
                                };

                                // Add the StaffData instance to the list
                                staffDataList.Add(staffData);

                                // Populate the dictionary with code-to-staff data mapping
                                codeToNameMap[staffData.Code] = staffData;
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


        private void WriteEventDataToExcel(string associateCode, string associateName, string associateEmail, string supervisorName, string supervisorEmail, DateTime date, DateTime time, string activity, string length, string note)
        {
            bool sendNote = chkNote.Checked;

            try
            {
                // Connection string for Excel files
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0 Xml;HDR=YES';";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Insert data into the "Events" sheet
                    string insertQuery = $"INSERT INTO [Events$] ([Associate Code], [Associate Name], [Associate Email], [Supervisor Name], [Supervisor Email], [Date], [Time], [Activity], [Length], [Note], [Send Note]) " +
                                         $"VALUES ('{associateCode}', '{associateName}', '{associateEmail}', '{supervisorName}', '{supervisorEmail}', '{date.ToShortDateString()}', '{time.ToShortTimeString()}', '{activity}', '{length}', '{note}', IIF({sendNote}, 'Yes', 'No'))";

                    using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing data to file: {ex.Message}");
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {

            WriteEventDataToExcel(txtStaffCode.Text, Associate_Name, Associate_Email, Supervisor_Name, Supervisor_Email, CustomdatePicker.Value, CustomtimePicker.Value, CmbActivities.Text, (txtMinutesEntry.Text + " " + txtNumericInput.Text), txtNote.Text);
            MessageBox.Show("Data has been appended", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void txtStaffCode_TextChanged(object sender, EventArgs e)
        {
            // Find the corresponding staff data based on the entered code
            string enteredCode = txtStaffCode.Text.Trim();

            if (codeToNameMap.TryGetValue(enteredCode, out StaffData selectedStaff))
            {
                CmbBoxStaffName.Text = selectedStaff.Name;
                Associate_Name = CmbBoxStaffName.Text;
                Associate_Email = selectedStaff.Email;
                Supervisor_Name = selectedStaff.Supervisor;
                Supervisor_Email = selectedStaff.SupervisorEmail;


            }
            else
            {
                CmbBoxStaffName.SelectedIndex = -1; // No match found, clear selection
            }
        }


    }


}
