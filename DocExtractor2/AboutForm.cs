// Project: DocExtractor Utility for SharePoint
// By Eng. Ibrahem A. Ibraheem 2012
// v1.0.0.0

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DocExtractor
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            // populate labels
            lDeveloper.Text = "Eng. Ibraheem AlShiekh Ahmed";
            lDeveloper.ForeColor = Color.Blue;

            lTitle.Text = "DocExtractor Utility for SharePoint";
            lVersion.Text = "Version: 1.0.0.0";
            lDescription.Text = "A mass file downloader to extract all or specific files from a  \n\r" +
                                "SharePoint site or entire site collection to a local directory.";

            lDisclaimer.Text = "Although this software ran through many tests and interacts with \n\r" +
                               "SharePoint system as a read only source, it comes without any warranty."; 
                               
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
