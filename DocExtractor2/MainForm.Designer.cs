namespace DocExtractor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cbSites = new System.Windows.Forms.ComboBox();
            this.btnResults = new System.Windows.Forms.Button();
            this.cbDocTypes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.tbCustomDocType = new System.Windows.Forms.TextBox();
            this.lCustomDocType = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.tbauthor = new System.Windows.Forms.TextBox();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.lEndDate = new System.Windows.Forms.Label();
            this.dtBeginDate = new System.Windows.Forms.DateTimePicker();
            this.lBeginDate = new System.Windows.Forms.Label();
            this.gbCriteria = new System.Windows.Forms.GroupBox();
            this.cbSizeUnit = new System.Windows.Forms.ComboBox();
            this.lSpecificText = new System.Windows.Forms.Label();
            this.cbFileNameText = new System.Windows.Forms.ComboBox();
            this.lTextExamples = new System.Windows.Forms.Label();
            this.tbFileNameText = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDateRelation = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbUserRelation = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rbNoCriteria = new System.Windows.Forms.RadioButton();
            this.rbSetCriteria = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label19 = new System.Windows.Forms.Label();
            this.btnOutDir = new System.Windows.Forms.Button();
            this.tbOutDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDownloadType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HiddenControl = new System.Windows.Forms.Label();
            this.gbCriteria.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSites
            // 
            this.cbSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSites.FormattingEnabled = true;
            this.cbSites.Location = new System.Drawing.Point(120, 26);
            this.cbSites.Name = "cbSites";
            this.cbSites.Size = new System.Drawing.Size(207, 21);
            this.cbSites.TabIndex = 3;
            this.cbSites.SelectedIndexChanged += new System.EventHandler(this.cbSites_SelectedIndexChanged);
            // 
            // btnResults
            // 
            this.btnResults.BackColor = System.Drawing.SystemColors.Control;
            this.btnResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResults.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnResults.Image = ((System.Drawing.Image)(resources.GetObject("btnResults.Image")));
            this.btnResults.Location = new System.Drawing.Point(649, 609);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(240, 73);
            this.btnResults.TabIndex = 4;
            this.btnResults.UseVisualStyleBackColor = false;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // cbDocTypes
            // 
            this.cbDocTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocTypes.FormattingEnabled = true;
            this.cbDocTypes.Location = new System.Drawing.Point(126, 160);
            this.cbDocTypes.Name = "cbDocTypes";
            this.cbDocTypes.Size = new System.Drawing.Size(202, 21);
            this.cbDocTypes.TabIndex = 6;
            this.cbDocTypes.SelectedIndexChanged += new System.EventHandler(this.cbDocTypes_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Size >";
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(162, 215);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(84, 20);
            this.tbSize.TabIndex = 8;
            // 
            // tbCustomDocType
            // 
            this.tbCustomDocType.Location = new System.Drawing.Point(397, 160);
            this.tbCustomDocType.Name = "tbCustomDocType";
            this.tbCustomDocType.Size = new System.Drawing.Size(84, 20);
            this.tbCustomDocType.TabIndex = 7;
            // 
            // lCustomDocType
            // 
            this.lCustomDocType.AutoSize = true;
            this.lCustomDocType.Location = new System.Drawing.Point(346, 162);
            this.lCustomDocType.Name = "lCustomDocType";
            this.lCustomDocType.Size = new System.Drawing.Size(45, 13);
            this.lCustomDocType.TabIndex = 21;
            this.lCustomDocType.Text = "Custom:";
            // 
            // cbUsers
            // 
            this.cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(120, 78);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(223, 21);
            this.cbUsers.TabIndex = 4;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.cbUsers_SelectedIndexChanged);
            // 
            // tbauthor
            // 
            this.tbauthor.Enabled = false;
            this.tbauthor.Location = new System.Drawing.Point(120, 105);
            this.tbauthor.Name = "tbauthor";
            this.tbauthor.Size = new System.Drawing.Size(223, 20);
            this.tbauthor.TabIndex = 23;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(534, 272);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtEndDate.TabIndex = 11;
            // 
            // lEndDate
            // 
            this.lEndDate.AutoSize = true;
            this.lEndDate.Location = new System.Drawing.Point(503, 274);
            this.lEndDate.Name = "lEndDate";
            this.lEndDate.Size = new System.Drawing.Size(26, 13);
            this.lEndDate.TabIndex = 2;
            this.lEndDate.Text = "And";
            // 
            // dtBeginDate
            // 
            this.dtBeginDate.Location = new System.Drawing.Point(296, 272);
            this.dtBeginDate.Name = "dtBeginDate";
            this.dtBeginDate.Size = new System.Drawing.Size(200, 20);
            this.dtBeginDate.TabIndex = 10;
            // 
            // lBeginDate
            // 
            this.lBeginDate.AutoSize = true;
            this.lBeginDate.Location = new System.Drawing.Point(241, 274);
            this.lBeginDate.Name = "lBeginDate";
            this.lBeginDate.Size = new System.Drawing.Size(49, 13);
            this.lBeginDate.TabIndex = 0;
            this.lBeginDate.Text = "Between";
            // 
            // gbCriteria
            // 
            this.gbCriteria.Controls.Add(this.cbSizeUnit);
            this.gbCriteria.Controls.Add(this.lSpecificText);
            this.gbCriteria.Controls.Add(this.cbFileNameText);
            this.gbCriteria.Controls.Add(this.lTextExamples);
            this.gbCriteria.Controls.Add(this.tbFileNameText);
            this.gbCriteria.Controls.Add(this.label12);
            this.gbCriteria.Controls.Add(this.label2);
            this.gbCriteria.Controls.Add(this.cbDateRelation);
            this.gbCriteria.Controls.Add(this.dtEndDate);
            this.gbCriteria.Controls.Add(this.lEndDate);
            this.gbCriteria.Controls.Add(this.dtBeginDate);
            this.gbCriteria.Controls.Add(this.label17);
            this.gbCriteria.Controls.Add(this.lBeginDate);
            this.gbCriteria.Controls.Add(this.label16);
            this.gbCriteria.Controls.Add(this.tbSize);
            this.gbCriteria.Controls.Add(this.label4);
            this.gbCriteria.Controls.Add(this.label15);
            this.gbCriteria.Controls.Add(this.tbCustomDocType);
            this.gbCriteria.Controls.Add(this.lCustomDocType);
            this.gbCriteria.Controls.Add(this.cbDocTypes);
            this.gbCriteria.Controls.Add(this.cbUserRelation);
            this.gbCriteria.Controls.Add(this.label14);
            this.gbCriteria.Controls.Add(this.tbauthor);
            this.gbCriteria.Controls.Add(this.cbUsers);
            this.gbCriteria.Controls.Add(this.cbSites);
            this.gbCriteria.Location = new System.Drawing.Point(70, 177);
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.Size = new System.Drawing.Size(767, 367);
            this.gbCriteria.TabIndex = 34;
            this.gbCriteria.TabStop = false;
            // 
            // cbSizeUnit
            // 
            this.cbSizeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSizeUnit.FormattingEnabled = true;
            this.cbSizeUnit.Location = new System.Drawing.Point(252, 214);
            this.cbSizeUnit.Name = "cbSizeUnit";
            this.cbSizeUnit.Size = new System.Drawing.Size(57, 21);
            this.cbSizeUnit.TabIndex = 45;
            this.cbSizeUnit.SelectedIndexChanged += new System.EventHandler(this.cbSizeUnit_SelectedIndexChanged);
            // 
            // lSpecificText
            // 
            this.lSpecificText.AutoSize = true;
            this.lSpecificText.Location = new System.Drawing.Point(327, 326);
            this.lSpecificText.Name = "lSpecificText";
            this.lSpecificText.Size = new System.Drawing.Size(48, 13);
            this.lSpecificText.TabIndex = 44;
            this.lSpecificText.Text = "Specific:";
            // 
            // cbFileNameText
            // 
            this.cbFileNameText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFileNameText.FormattingEnabled = true;
            this.cbFileNameText.Location = new System.Drawing.Point(202, 323);
            this.cbFileNameText.Name = "cbFileNameText";
            this.cbFileNameText.Size = new System.Drawing.Size(107, 21);
            this.cbFileNameText.TabIndex = 12;
            this.cbFileNameText.SelectedIndexChanged += new System.EventHandler(this.cbFileNameText_SelectedIndexChanged);
            // 
            // lTextExamples
            // 
            this.lTextExamples.AutoSize = true;
            this.lTextExamples.Location = new System.Drawing.Point(597, 326);
            this.lTextExamples.Name = "lTextExamples";
            this.lTextExamples.Size = new System.Drawing.Size(157, 13);
            this.lTextExamples.TabIndex = 42;
            this.lTextExamples.Text = "Examples: report, 2012, agenda";
            // 
            // tbFileNameText
            // 
            this.tbFileNameText.Location = new System.Drawing.Point(381, 323);
            this.tbFileNameText.Name = "tbFileNameText";
            this.tbFileNameText.Size = new System.Drawing.Size(210, 20);
            this.tbFileNameText.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(55, 326);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(141, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Select Text included in Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Select Site:";
            // 
            // cbDateRelation
            // 
            this.cbDateRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDateRelation.FormattingEnabled = true;
            this.cbDateRelation.Location = new System.Drawing.Point(126, 271);
            this.cbDateRelation.Name = "cbDateRelation";
            this.cbDateRelation.Size = new System.Drawing.Size(101, 21);
            this.cbDateRelation.TabIndex = 9;
            this.cbDateRelation.SelectedIndexChanged += new System.EventHandler(this.cbDateRelation_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(57, 272);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "Select Date:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(56, 218);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Select Size:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(56, 162);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Select Type:";
            // 
            // cbUserRelation
            // 
            this.cbUserRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserRelation.FormattingEnabled = true;
            this.cbUserRelation.Location = new System.Drawing.Point(361, 78);
            this.cbUserRelation.Name = "cbUserRelation";
            this.cbUserRelation.Size = new System.Drawing.Size(116, 21);
            this.cbUserRelation.TabIndex = 5;
            this.cbUserRelation.SelectedIndexChanged += new System.EventHandler(this.cbUserRelation_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Select User:";
            // 
            // rbNoCriteria
            // 
            this.rbNoCriteria.AutoSize = true;
            this.rbNoCriteria.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNoCriteria.Location = new System.Drawing.Point(48, 46);
            this.rbNoCriteria.Name = "rbNoCriteria";
            this.rbNoCriteria.Size = new System.Drawing.Size(126, 23);
            this.rbNoCriteria.TabIndex = 1;
            this.rbNoCriteria.TabStop = true;
            this.rbNoCriteria.Text = "Get Everything:";
            this.rbNoCriteria.UseVisualStyleBackColor = true;
            this.rbNoCriteria.CheckedChanged += new System.EventHandler(this.rbNoCriteria_CheckedChanged);
            // 
            // rbSetCriteria
            // 
            this.rbSetCriteria.AutoSize = true;
            this.rbSetCriteria.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSetCriteria.Location = new System.Drawing.Point(48, 135);
            this.rbSetCriteria.Name = "rbSetCriteria";
            this.rbSetCriteria.Size = new System.Drawing.Size(129, 23);
            this.rbSetCriteria.TabIndex = 2;
            this.rbSetCriteria.TabStop = true;
            this.rbSetCriteria.Text = "Specify Criteria:";
            this.rbSetCriteria.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(67, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(371, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Get all files from all sites, of all sizes, types, and dates and created by all u" +
                "sers";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 24);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(46, 644);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 13);
            this.label19.TabIndex = 41;
            this.label19.Text = "Output Directory:";
            // 
            // btnOutDir
            // 
            this.btnOutDir.Location = new System.Drawing.Point(545, 634);
            this.btnOutDir.Name = "btnOutDir";
            this.btnOutDir.Size = new System.Drawing.Size(61, 33);
            this.btnOutDir.TabIndex = 43;
            this.btnOutDir.Text = "Browse";
            this.btnOutDir.UseVisualStyleBackColor = true;
            this.btnOutDir.Click += new System.EventHandler(this.btnOutDir_Click);
            // 
            // tbOutDir
            // 
            this.tbOutDir.AcceptsReturn = true;
            this.tbOutDir.Location = new System.Drawing.Point(139, 641);
            this.tbOutDir.Name = "tbOutDir";
            this.tbOutDir.Size = new System.Drawing.Size(400, 20);
            this.tbOutDir.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Get only the files that meet the given conditions";
            // 
            // cbDownloadType
            // 
            this.cbDownloadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDownloadType.FormattingEnabled = true;
            this.cbDownloadType.Location = new System.Drawing.Point(182, 584);
            this.cbDownloadType.Name = "cbDownloadType";
            this.cbDownloadType.Size = new System.Drawing.Size(131, 21);
            this.cbDownloadType.TabIndex = 50;
            this.cbDownloadType.SelectedIndexChanged += new System.EventHandler(this.cbDownloadType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 587);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Choose what to download:";
            // 
            // HiddenControl
            // 
            this.HiddenControl.AutoSize = true;
            this.HiddenControl.Location = new System.Drawing.Point(859, 37);
            this.HiddenControl.Name = "HiddenControl";
            this.HiddenControl.Size = new System.Drawing.Size(41, 13);
            this.HiddenControl.TabIndex = 52;
            this.HiddenControl.Text = "Hidden";
            this.HiddenControl.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 702);
            this.Controls.Add(this.HiddenControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDownloadType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbOutDir);
            this.Controls.Add(this.btnOutDir);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rbSetCriteria);
            this.Controls.Add(this.rbNoCriteria);
            this.Controls.Add(this.gbCriteria);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbCriteria.ResumeLayout(false);
            this.gbCriteria.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSites;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.ComboBox cbDocTypes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.TextBox tbCustomDocType;
        private System.Windows.Forms.Label lCustomDocType;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.TextBox tbauthor;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label lEndDate;
        private System.Windows.Forms.DateTimePicker dtBeginDate;
        private System.Windows.Forms.Label lBeginDate;
        private System.Windows.Forms.GroupBox gbCriteria;
        private System.Windows.Forms.RadioButton rbNoCriteria;
        private System.Windows.Forms.RadioButton rbSetCriteria;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbUserRelation;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbDateRelation;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileNameText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lTextExamples;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnOutDir;
        private System.Windows.Forms.TextBox tbOutDir;
        private System.Windows.Forms.ComboBox cbFileNameText;
        private System.Windows.Forms.Label lSpecificText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSizeUnit;
        private System.Windows.Forms.ComboBox cbDownloadType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HiddenControl;
    }
}

