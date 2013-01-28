namespace DocExtractor
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.lDescription = new System.Windows.Forms.Label();
            this.lDeveloper = new System.Windows.Forms.Label();
            this.lDisclaimer = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DocExtractor.Properties.Resources.LoginBanner1;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 81);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(51, 128);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(35, 13);
            this.lTitle.TabIndex = 1;
            this.lTitle.Text = "label1";
            // 
            // lDescription
            // 
            this.lDescription.AutoSize = true;
            this.lDescription.Location = new System.Drawing.Point(51, 176);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(35, 13);
            this.lDescription.TabIndex = 2;
            this.lDescription.Text = "label1";
            // 
            // lDeveloper
            // 
            this.lDeveloper.AutoSize = true;
            this.lDeveloper.Location = new System.Drawing.Point(136, 93);
            this.lDeveloper.Name = "lDeveloper";
            this.lDeveloper.Size = new System.Drawing.Size(35, 13);
            this.lDeveloper.TabIndex = 3;
            this.lDeveloper.Text = "label2";
            // 
            // lDisclaimer
            // 
            this.lDisclaimer.AutoSize = true;
            this.lDisclaimer.Location = new System.Drawing.Point(51, 218);
            this.lDisclaimer.Name = "lDisclaimer";
            this.lDisclaimer.Size = new System.Drawing.Size(35, 13);
            this.lDisclaimer.TabIndex = 4;
            this.lDisclaimer.Text = "label1";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(139, 259);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(162, 37);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(51, 150);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(35, 13);
            this.lVersion.TabIndex = 6;
            this.lVersion.Text = "label1";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 307);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lDisclaimer);
            this.Controls.Add(this.lDeveloper);
            this.Controls.Add(this.lDescription);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About..";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lDescription;
        private System.Windows.Forms.Label lDeveloper;
        private System.Windows.Forms.Label lDisclaimer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lVersion;
    }
}