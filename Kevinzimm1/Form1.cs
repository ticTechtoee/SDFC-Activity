using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Kevinzimm1.Properties;
using OfficeOpenXml;
using System.IO;

namespace Kevinzimm1
{
    /// <summary>
    /// Problem Statement: Get the data from one sheet and write it in another sheet. Multiple users must be able to access the same sheet and read and write in it.
    /// Create a Portable application, instead of installing it on the system.
    /// </summary>

    public partial class sdfcactivityFrm : Form
    {
        private string filePath;
        private const string sheetName1 = "Staff";
        private const string sheetName2 = "Data Fields";

        private Dictionary<string, StaffData> codeToStaffDataMap = new Dictionary<string, StaffData>();


        private List<StaffData> staffDataList = new List<StaffData>();

        private string Associate_Name;
        private string Associate_Email;
        private string Supervisor_Name;
        private string Supervisor_Email;



        public sdfcactivityFrm()
        {
            InitializeComponent();
        }

        // Loading and selecting the targetted file.

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                filePath = selectedFilePath;

                LoadStaffData();
                LoadActivities();
            }
        }

        //This function will get the staff name and other details from the excel sheet i.e "Staff"

        private void LoadStaffData()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName1];

                    int rowCount = worksheet.Dimension.Rows;
                    int codeColumnIndex = 1;
                    int nameColumnIndex = 2;
                    int emailColumnIndex = 3;
                    int supervisorColumnIndex = 4;
                    int supervisorEmailColumnIndex = 5;
                    

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string code = worksheet.Cells[row, codeColumnIndex].Text;
                        string name = worksheet.Cells[row, nameColumnIndex].Text;
                        string email = worksheet.Cells[row, emailColumnIndex].Text;
                        string supervisor = worksheet.Cells[row, supervisorColumnIndex].Text;
                        string supervisorEmail = worksheet.Cells[row, supervisorEmailColumnIndex].Text;
                        

                        StaffData staffData = new StaffData
                        {
                            Code = code,
                            Name = name,
                            Email = email,
                            Supervisor = supervisor,
                            SupervisorEmail = supervisorEmail,
                            
                        };

                        // Populate the dictionary with code-to-staff data mapping
                        codeToStaffDataMap[code] = staffData;

                        // Populate the dropdown with staff names
                        CmbBoxStaffName.Items.Add(staffData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }
        }


        private void txtStaffCode_TextChanged(object sender, EventArgs e)
        {
            // Find the corresponding staff data based on the entered code
            string enteredCode = txtStaffCode.Text.ToUpper().Trim();

            if (codeToStaffDataMap.TryGetValue(enteredCode, out StaffData selectedStaff))
            {
                // Access other relevant fields
                //string email = selectedStaff.Email;
                //string supervisor = selectedStaff.Supervisor;
                //string supervirsorEmail = selectedStaff.SupervisorEmail;
                CmbBoxStaffName.Text = selectedStaff.Name;
                Associate_Name = selectedStaff.Name;

                Associate_Email = selectedStaff.Email;
                Supervisor_Name = selectedStaff.Supervisor;
                Supervisor_Email = selectedStaff.SupervisorEmail;
            }
            else
            {
                CmbBoxStaffName.SelectedIndex = -1; // No match found, clear selection
            }

        }


        // Creating a seperate method to get the Activities list from the "Data Fields"
        private void LoadActivities()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName2];

                    int rowCount = worksheet.Dimension.Rows;
                    int activitiesColumnIndex = 1;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string activity = worksheet.Cells[row, activitiesColumnIndex].Text;
                        CmbActivities.Items.Add(activity);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }
        }

        // Writing the Information from app to the "Events" sheet

        private void WriteEventDataToExcel(string associateCode, string associateName, string associateEmail, string supervisorName, string supervisorEmail, DateTime date, DateTime time, string activity, string length, string note)
        {
            bool sendNote = chkNote.Checked;

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Events"];

                    int rowCount = worksheet.Dimension.Rows;
                    int newRow = rowCount + 1;

                    worksheet.Cells[newRow, 1].Value = associateCode;
                    worksheet.Cells[newRow, 2].Value = associateName;
                    worksheet.Cells[newRow, 3].Value = associateEmail;
                    worksheet.Cells[newRow, 4].Value = supervisorName;
                    worksheet.Cells[newRow, 5].Value = supervisorEmail;
                    worksheet.Cells[newRow, 6].Value = date.ToShortDateString();
                    worksheet.Cells[newRow, 7].Value = time.ToShortTimeString();
                    worksheet.Cells[newRow, 8].Value = activity;
                    // New Fields to Include
                    worksheet.Cells[newRow, 9].Value = associateName;
                    worksheet.Cells[newRow, 10].Value = associateEmail;
                    worksheet.Cells[newRow, 11].Value = supervisorName;
                    worksheet.Cells[newRow, 12].Value = supervisorEmail;
                    // Old Fields
                    worksheet.Cells[newRow, 13].Value = length;
                    worksheet.Cells[newRow, 14].Value = note;
                    worksheet.Cells[newRow, 15].Value = sendNote ? "Yes" : "No";

                    package.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing data to file: {ex.Message}");
            }
        }


        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                WriteEventDataToExcel(txtStaffCode.Text.ToUpper(), CmbBoxStaffName.Text, Associate_Email, Supervisor_Name, Supervisor_Email, CustomdatePicker.Value, CustomtimePicker.Value, CmbActivities.Text, (txtMinutesEntry.Text + " " + txtNumericInput.Text), txtNote.Text);

                // Set the value for LblNULL after successful data writing
                LblNULL.Text = Associate_Name + " " + CmbActivities.Text;

                Settings.Default.Username = Associate_Name;
                Settings.Default.Last_Entry = CmbActivities.Text;
                Settings.Default.Save();

                MessageBox.Show("Data has been appended", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


       

        private void sdfcactivityFrm_Load(object sender, EventArgs e)
        {
            LblNULL.Text = Settings.Default.Username + " " + Settings.Default.Last_Entry;
        }

        private void CmbBoxStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Access selected staff data when ComboBox selection changes
            if (CmbBoxStaffName.SelectedItem is StaffData selectedStaff)
            {
                //string code = selectedStaff.Code;
                //string name = selectedStaff.Name;
                //string email = selectedStaff.Email;
                //string supervisor = selectedStaff.Supervisor;

                Associate_Name = selectedStaff.Name;
                Associate_Email = selectedStaff.Email;
                Supervisor_Name = selectedStaff.Supervisor;
                Supervisor_Email = selectedStaff.SupervisorEmail;
            }
        }
    }

    public class StaffData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Supervisor { get; set; }
        public string SupervisorEmail { get; set; }
        

        // Override ToString to display the name in the ComboBox
        public override string ToString()
        {
            return Name;
        }
    }

}
