using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Kevinzimm1
{
    public partial class sdfcactivityFrm : Form
    {
        private const string filePath = @"D:\Development\Kevinzimm1\Requirements\newfile.xlsx";
        private static readonly object fileLock = new object();

        public sdfcactivityFrm()
        {
            InitializeComponent();
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                // Use a lock to ensure mutual exclusion
                lock (fileLock)
                {
                    // Read the content of the Excel file
                    string fileContent = File.ReadAllText(filePath);

                    // Process and display the read content as needed
                    MessageBox.Show("Read content:\n" + fileContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                // Use a lock to ensure mutual exclusion
                lock (fileLock)
                {
                    // Get the updated content (you can replace this with your logic)
                    string updatedContent = "Updated content goes here";

                    // Write the updated content to the Excel file
                    File.WriteAllText(filePath, updatedContent);

                    MessageBox.Show("File updated successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to file: " + ex.Message);
            }
        }
    }
}
