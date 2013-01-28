// Project: DocExtractor Utility for SharePoint
// By Eng. Ibrahem A. Ibraheem 2012
// v1.0.0.0

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DocExtractor
{
    public partial class MainForm : Form
    {
        DocExtractor de;
        LoginForm SiteLoginForm;
        DownloaderForm FileDownloadForm;
        AboutForm myAboutForm;

        string DownloadType;

        public MainForm()
        {
            InitializeComponent();

            DownloadType = "Folders and Files";

            de = new DocExtractor();
            myAboutForm = new AboutForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

            performStart();            
        }


        private void performStart()
        {
            // show site login form
            SiteLoginForm = new LoginForm();
            SiteLoginForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            if (SiteLoginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // after user entered a site url and user credentials, the main form shows through Form_Load
                populateMainForm();
            }
            else
            {
                // user exited/canceled the login form
                PerformExit();
            }
        }

        private void populateMainForm()
        {
            // update SiteUrl
            de.SiteUrl = SiteLoginForm.SPSiteCollectionURL;


            this.Text = "IBR DocExtractor Utility for SharePoint";

            // suppose login user is the Site Collection Administrator until otherwise specified

            // populate combobox of sites (only sites that login user is admin of)
            cbSites.Items.Add("All Sites"); // adding the 1st option
            foreach (string s in de.getAllSitesInSiteCollection()) // adding all sites
            {
                cbSites.Items.Add(s);
            }
            //cbSites.SelectedItem = "All Sites";
            cbSites.Text = "All Sites";

            // populate combobox of users
            cbUsers.Items.Add("All Users"); // adding the 1st option
            foreach (string usr in de.getAllUsersInSiteCollection()) // adding all users
            {
                cbUsers.Items.Add(usr);
            }
            cbUsers.SelectedItem = "All Users";

            // populate combobox of user relation 
            cbUserRelation.Items.Add("Created By");
            cbUserRelation.Items.Add("Modified By");
            cbUserRelation.SelectedItem = "Created By";

            // populate combobox of doc types
            cbDocTypes.DataSource = de.DocTypes;

            // populate combobox of date relation
            cbDateRelation.Items.Add("All Dates");
            cbDateRelation.Items.Add("Created");
            cbDateRelation.Items.Add("Modified");
            cbDateRelation.SelectedItem = "All Dates";

            // populate comboxbox of size
            tbSize.Text = "0";
            cbSizeUnit.Items.Add("B");
            cbSizeUnit.Items.Add("KB");
            cbSizeUnit.Items.Add("MB");
            cbSizeUnit.SelectedItem = "KB";

            // populate combobox of text
            cbFileNameText.Items.Add("Any Text");
            cbFileNameText.Items.Add("Specific Text");
            cbFileNameText.SelectedItem = "Any Text";

            // populate combobox of download type
            cbDownloadType.Items.Add("Folders and Files");
            cbDownloadType.Items.Add("Files only");
            cbDownloadType.SelectedItem = "Folders and Files";

            // default settings
            rbNoCriteria.Checked = true;
        }
        
        // for lists
        private void btnResults_Click(object sender, EventArgs e)
        {
            // check the availability of an output dir first
            if (EnsureFolder(tbOutDir.Text))
            {
                getTheFiles();
            }
        }

        private void getTheFiles()
        {
            string OutputDir = "";
            List<string> Files = new List<string>();

            // shows wait cursor while getting the files info
            System.Windows.Forms.Cursor currentCurser = this.Cursor;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            // prepare parameters for the query
            if (rbNoCriteria.Checked)
            { 
                // set query criteria to include everything
                de.UserSelection = DocExtractor.FilterUser.AllUsers;// Users
                de.DocSize = 0;// Size
                de.DocDateSelection = DocExtractor.FilterDate.AllDates;// Date
                de.NameTextSelection = DocExtractor.FilterText.AnyText;
                de.TextinName = "";

                // Run the query
                Files = de._getAllDocsInSiteCollection();
            }
            else if (rbSetCriteria.Checked)
            { 
                // set query criteria based on user selection
                CheckUserSelection(); // Users
                if (!CheckTypeSelection())// Type
                    return;
                if (!CheckSizeSelection())// Size
                    return;
                if (!CheckDateSelection())// Date
                    return;
                CheckTextSelection();// Text
                
                // Run the query and get file urls
                if ((string)cbSites.SelectedItem == "All Sites")
                {
                    Files = de._getSpecificDocsInSiteCollection();
                }
                else if ((string)cbSites.SelectedItem != "All Sites")
                {
                    Files = de._getSpecificDocsInSingleSite((string)cbSites.SelectedItem);// put site name here
                }
            }

            this.Cursor = currentCurser;

            // Prepare the files downloading
            int FileCount = Files.Count;
            OutputDir = tbOutDir.Text;
            
            if (FileCount == 0)
            {
                MessageBox.Show("No files were found. Try changing the criteria.", "No Results Found");
            }
            
            // Proceed only when there are files, the user wants to proceed, and when dir is created/overwrited
            else if ((FileCount > 0) && 
                MessageBox.Show(FileCount.ToString() + " files found. Do you want to proceed with downloading?", "Results Found", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FileDownloadForm = new DownloaderForm(de.SiteUrl, Files, OutputDir, DownloadType);
                FileDownloadForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                FileDownloadForm.Show();// show the downloader form and begin downloading files
            }
            Files = null;
       }

        private void CheckUserSelection()
       {
            if ((string)cbUsers.SelectedItem == "All Users")
            {
                de.UserSelection = DocExtractor.FilterUser.AllUsers;
            }
            else// for specific user
            {
                if ((string)cbUserRelation.SelectedItem == "Created By")
                {
                    de.UserSelection = DocExtractor.FilterUser.SpecificCreatedByUser;
                }
                else if ((string)cbUserRelation.SelectedItem == "Modified By")
                {
                    de.UserSelection = DocExtractor.FilterUser.SpecifiModifiedByUSer;
                }
            }
        }

        private bool CheckTypeSelection()
        {
            if ((string)cbDocTypes.SelectedItem == "All Types")
            {
                de.DocTypeSelection = DocExtractor.FilterType.AllTypes; return (true);
            }
            else if ((string)cbDocTypes.SelectedItem == "MS Office: .docx, .xlsx, .pptx")
            {
                de.DocTypeSelection = DocExtractor.FilterType.MSOffice; return (true);
            }
            else if ((string)cbDocTypes.SelectedItem == "Adobe .pdf")
            {
                de.DocTypeSelection = DocExtractor.FilterType.AdobePDF; return (true);
            }
            else if ((string)cbDocTypes.SelectedItem == "Images: .jpg, .bmp, .png")
            {
                de.DocTypeSelection = DocExtractor.FilterType.Images; return (true);
            }
            else if ((string)cbDocTypes.SelectedItem == "Videos: .wmv, .mpg, .avi, .mp4")
            {
                de.DocTypeSelection = DocExtractor.FilterType.Videos; return (true);
            }
            else if ((string)cbDocTypes.SelectedItem == "Audio: .mp3, .wav, .wma")
            {
                de.DocTypeSelection = DocExtractor.FilterType.Audio; return (true);
            }
            else if ((string)cbDocTypes.SelectedItem == "Web: .htm, .aspx, .xml")
            {
                de.DocTypeSelection = DocExtractor.FilterType.Web; return (true);
            }
            else if ((string)cbDocTypes.SelectedItem == "Custom")
            {
                de.DocTypeSelection = DocExtractor.FilterType.Custom;
                
                // validation
                if (tbCustomDocType.Text == null || tbCustomDocType.Text == "")
                {
                    MessageBox.Show("Missing Custom Typr entry. Please enter a valid file extension.", "Missing Entry");
                    return (false);
                }
                if (tbCustomDocType.Text.StartsWith("."))
                    de.CusDocType = tbCustomDocType.Text.Substring(1);
                else
                    de.CusDocType = tbCustomDocType.Text;
                return (true);
            }
            return (false);
        }

        private bool CheckSizeSelection()
        {
            // validation
            if (tbSize.Text == "")
            {
                de.DocSize = 0;
                return (true);
            }
            else
            {
                try
                {
                    // calculate the final size
                    if ((string)cbSizeUnit.SelectedItem == "B")
                        de.DocSize = Int32.Parse(tbSize.Text); // in B
                    else if ((string)cbSizeUnit.SelectedItem == "KB")
                        de.DocSize = Int32.Parse(tbSize.Text) * 1024;// in KB
                    else if ((string)cbSizeUnit.SelectedItem == "MB")
                        de.DocSize = Int32.Parse(tbSize.Text) * 1048576;// in MB

                    if (de.DocSize < 0)
                    {
                        MessageBox.Show("Size entry cannot be less than 0. Please enter a valid number above 0.", "Wrong Entry");
                        return (false);
                    }

                    return (true);// DocSize >= 0
                }
                catch (Exception e) // Entry is null, text
                {
                    MessageBox.Show("Invalid Size entry. Please enter a valid number above 0.", "Wrong Entry");
                }
            }
            return (false);
        }

        private bool validateDatePickers(DateTimePicker D1, DateTimePicker D2)
        {
            //validate if EndDate is lees than begin date
            if (D2.Value < D1.Value)
            {
                MessageBox.Show("End date must be more or equal to the begin date.", "Wrong entry");
                return false; // must exit
            }
            return true;
        }

        private bool CheckDateSelection()
        {
            if ((string)cbDateRelation.SelectedItem == "All Dates")
            {
                de.DocDateSelection = DocExtractor.FilterDate.AllDates;
            }
            else if ((string)cbDateRelation.SelectedItem == "Created")
            {
                if (!validateDatePickers(dtBeginDate, dtEndDate)) return false;

                de.DocDateSelection = DocExtractor.FilterDate.SpecificCreatedDate;
                de.DocBeginDate = dtBeginDate.Value;
                de.DocEndDate = dtEndDate.Value;
            }
            else if ((string)cbDateRelation.SelectedItem == "Modified")
            {
                if (!validateDatePickers(dtBeginDate, dtEndDate)) return false;

                de.DocDateSelection = DocExtractor.FilterDate.SpecificModifiedDate;
                de.DocBeginDate = dtBeginDate.Value;
                de.DocEndDate = dtEndDate.Value;
            }

            return true;
        }

        private void CheckTextSelection()
        {
            if ((string)cbFileNameText.SelectedItem == "Any Text")
            {
                de.NameTextSelection = DocExtractor.FilterText.AnyText;
                de.TextinName = "";
            }
            else if ((string)cbFileNameText.SelectedItem == "Specific Text" && tbFileNameText.Text != "")
            {
                de.NameTextSelection = DocExtractor.FilterText.SpecificText;
                de.TextinName = tbFileNameText.Text;
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PerformExit();
        }

        private bool EnsureFolder(string path)
        {
            // empty dir name
            if (path.Length == 0)
            {
                MessageBox.Show("Please set the Output Directory to put the resulted files in.", "Output Directory Missing");
                return false;
            }

            try
            {
                string directoryName = Path.GetDirectoryName(path);

                // directory exist
                if (Directory.Exists(directoryName))
                {
                    // check for existing files and/or folders
                    string[] dirs = Directory.GetDirectories(directoryName);
                    string[] files = Directory.GetFiles(directoryName);
                    if (dirs.Length == 0 && files.Length == 0)
                    {
                        return true; // the directory is empty
                    }
                    else // the directory is not empty
                    {
                        if (MessageBox.Show("Specified dirctory contains files and/or folders. Do you want to continue?", "Existing files/folders..", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            return true; // on Yes
                        }
                        else // on No
                        {
                            return false;
                        }
                    }
                }
                else  // directory does not exist
                {
                    Directory.CreateDirectory(directoryName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error in specified Output Directory");
                return false;
            }
            return true;
        }

        private void rbNoCriteria_CheckedChanged(object sender, EventArgs e)
        {
            // disable criteria options only when selecting 1st radio button
            gbCriteria.Enabled = !rbNoCriteria.Checked;
        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            de.UserDisplayName = (string)cbUsers.SelectedItem;
            de.UserLoginName = de.getUserLoginName(de.UserDisplayName);
            tbauthor.Text = de.UserLoginName;
            changeFocus();
        }
 
        private void cbDocTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbDocTypes.SelectedItem == "Custom")
            {
                lCustomDocType.Enabled = true;
                tbCustomDocType.Enabled = true; 
            }
            else
            {
                lCustomDocType.Enabled = false;
                tbCustomDocType.Enabled = false;
            }
            changeFocus();
        }

        private void cbDateRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbDateRelation.SelectedItem == "All Dates")
            {
                lBeginDate.Enabled = false;
                dtBeginDate.Enabled = false;
                lEndDate.Enabled = false;
                dtEndDate.Enabled = false;
            }
            else
            {
                lBeginDate.Enabled = true;
                dtBeginDate.Enabled = true;
                lEndDate.Enabled = true;
                dtEndDate.Enabled = true;
            }
            changeFocus();
        }

        private void cbFileNameText_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbFileNameText.SelectedItem == "Any Text")
            {
                lSpecificText.Enabled = false;
                tbFileNameText.Enabled = false;
                lTextExamples.Enabled = false;
            }
            else
            {
                lSpecificText.Enabled = true;
                tbFileNameText.Enabled = true;
                lTextExamples.Enabled = true;
            }
            changeFocus();
        }
        
        private void btnOutDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbOutDir.Text = folderBrowserDialog1.SelectedPath + @"\";
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformExit();
        }

        private void PerformExit()
        {
            // dispose objects
            de = null;
            SiteLoginForm = null;
            FileDownloadForm = null;
            myAboutForm = null;

            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show the about form
            myAboutForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            myAboutForm.ShowDialog();
        }

        private void cbSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeFocus();
        }

        private void cbSizeUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeFocus();
        }

        private void cbDownloadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbDownloadType.SelectedItem == "Folders and Files")
                DownloadType = "Files_and_Folders";
            else if ((string)cbDownloadType.SelectedItem == "Files only")
                DownloadType = "Files_only";

            changeFocus();
        }

        private void cbUserRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeFocus();
        }

        private void changeFocus()
        {
            //this.ActiveControl = this.GetNextControl((Control)sender, true);

            this.ActiveControl = this.HiddenControl;
        }

        

               
        
    }
}
