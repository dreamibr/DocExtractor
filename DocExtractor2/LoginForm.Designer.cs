namespace DocExtractor
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbWebApps = new System.Windows.Forms.ComboBox();
            this.cbSiteCollections = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HiddenControl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(190, 332);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(134, 44);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Next";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 332);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(134, 44);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Web App. Name:";
            // 
            // cbWebApps
            // 
            this.cbWebApps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWebApps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWebApps.ForeColor = System.Drawing.Color.Blue;
            this.cbWebApps.FormattingEnabled = true;
            this.cbWebApps.Location = new System.Drawing.Point(26, 127);
            this.cbWebApps.Name = "cbWebApps";
            this.cbWebApps.Size = new System.Drawing.Size(209, 23);
            this.cbWebApps.TabIndex = 8;
            this.cbWebApps.SelectedIndexChanged += new System.EventHandler(this.cbWebApps_SelectedIndexChanged);
            // 
            // cbSiteCollections
            // 
            this.cbSiteCollections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSiteCollections.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSiteCollections.ForeColor = System.Drawing.Color.Blue;
            this.cbSiteCollections.FormattingEnabled = true;
            this.cbSiteCollections.Location = new System.Drawing.Point(25, 196);
            this.cbSiteCollections.Name = "cbSiteCollections";
            this.cbSiteCollections.Size = new System.Drawing.Size(261, 23);
            this.cbSiteCollections.TabIndex = 9;
            this.cbSiteCollections.SelectedIndexChanged += new System.EventHandler(this.cbSiteCollections_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select Site Collection Url:";
            // 
            // HiddenControl
            // 
            this.HiddenControl.AutoSize = true;
            this.HiddenControl.Location = new System.Drawing.Point(283, 9);
            this.HiddenControl.Name = "HiddenControl";
            this.HiddenControl.Size = new System.Drawing.Size(41, 13);
            this.HiddenControl.TabIndex = 53;
            this.HiddenControl.Text = "Hidden";
            this.HiddenControl.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPopulate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbSiteCollections);
            this.groupBox2.Controls.Add(this.cbWebApps);
            this.groupBox2.Location = new System.Drawing.Point(12, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 246);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            // 
            // btnPopulate
            // 
            this.btnPopulate.BackColor = System.Drawing.SystemColors.Control;
            this.btnPopulate.Location = new System.Drawing.Point(76, 28);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(159, 45);
            this.btnPopulate.TabIndex = 0;
            this.btnPopulate.Text = "Start";
            this.btnPopulate.UseVisualStyleBackColor = false;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.HiddenControl);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbWebApps;
        private System.Windows.Forms.ComboBox cbSiteCollections;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label HiddenControl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPopulate;
    }
}