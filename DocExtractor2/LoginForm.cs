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

namespace DocExtractor
{
    public partial class LoginForm : Form
    {
        public string SPSiteCollectionURL;
        public System.Net.NetworkCredential UserCredentials;
        private enum LoginFormFlag
        {
            Close_Continue,
            Close_Exit
        };
        private LoginFormFlag CloseFlag;
        private DocExtractor deLogin;


        public LoginForm()
        {
            InitializeComponent();

            CloseFlag = LoginFormFlag.Close_Exit;
            SPSiteCollectionURL = "";
            UserCredentials = new System.Net.NetworkCredential();
            deLogin = new DocExtractor();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Text = "IBR DocExtractor Utility for SharePoint";

            // disable controls that will be enabled by Start button
            cbWebApps.Enabled = false;
            cbSiteCollections.Enabled = false;
            btnLogin.Enabled = false;

            this.ActiveControl = this.btnPopulate;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ProcessLoginValues();
        }

        private void ProcessLoginValues()
        {
            SPSiteCollectionURL = (string)cbSiteCollections.SelectedItem;
            
            // return back to MainForm
            CloseFlag = LoginFormFlag.Close_Continue; this.Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close login form according to flag
            if (CloseFlag == LoginFormFlag.Close_Continue)
                this.DialogResult = System.Windows.Forms.DialogResult.OK; // on valid entry
            else if (CloseFlag == LoginFormFlag.Close_Exit)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel; // on exit
        }

        private void cbWebApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            // when user selects a Web App, its site collections are retreived
            cbSiteCollections.DataSource = deLogin.getSiteCollectionsInWebApp((string)cbWebApps.SelectedItem);

            changeFocus();
        }
 
        private void cbSiteCollections_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeFocus();
        }

        private void changeFocus()
        {
            //this.ActiveControl = this.GetNextControl((Control)sender, true);

            this.ActiveControl = this.HiddenControl;
        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            // shows wait cursor while populating comboboxes of Web Apps and Site Colls
            System.Windows.Forms.Cursor currentCurser = this.Cursor;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                cbWebApps.DataSource = deLogin.getAvailableWebAppsOnMachine();
                // here cbSiteCollections will get populated in an event of cbWebApps item selection

                cbWebApps.Enabled = true;
                cbSiteCollections.Enabled = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("An error occured. \n\rPlease make sure that current user is a Farm Administrator.", "Error");
            }
            finally
            { 
                this.Cursor = currentCurser;
            }
            

            // only enable 'Next' button only when valid Site Coll. selection made
            string s = (string)cbSiteCollections.SelectedItem;
            if (s != null && s != "")
            {
                btnLogin.Enabled = true;
            }

            btnPopulate.Text = "Refresh";
        }


    }
}
