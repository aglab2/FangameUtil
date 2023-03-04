namespace FangameUtil
{
    partial class Util
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.checkBoxAutoFire = new System.Windows.Forms.CheckBox();
            this.groupBoxAutoFire = new System.Windows.Forms.GroupBox();
            this.labelAutoFireToggle = new System.Windows.Forms.Label();
            this.comboBoxAutoFireSwitch = new System.Windows.Forms.ComboBox();
            this.textBoxAutoFireRelease = new System.Windows.Forms.TextBox();
            this.labelAutoFireRel = new System.Windows.Forms.Label();
            this.textBoxAutoFireHold = new System.Windows.Forms.TextBox();
            this.labelAutoFireHold = new System.Windows.Forms.Label();
            this.checkBoxHoldNumPad = new System.Windows.Forms.CheckBox();
            this.groupBoxSaveBackup = new System.Windows.Forms.GroupBox();
            this.textBoxSaveBackupMaxBackups = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSaveBackupMaxSize = new System.Windows.Forms.Label();
            this.textBoxSaveBackupDir = new System.Windows.Forms.TextBox();
            this.buttonSaveBackupOpen = new System.Windows.Forms.Button();
            this.textBoxSaveBackupMaxFileSize = new System.Windows.Forms.TextBox();
            this.groupBoxAutoFire.SuspendLayout();
            this.groupBoxSaveBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(53, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(148, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // checkBoxAutoFire
            // 
            this.checkBoxAutoFire.AutoSize = true;
            this.checkBoxAutoFire.Location = new System.Drawing.Point(6, 19);
            this.checkBoxAutoFire.Name = "checkBoxAutoFire";
            this.checkBoxAutoFire.Size = new System.Drawing.Size(65, 17);
            this.checkBoxAutoFire.TabIndex = 2;
            this.checkBoxAutoFire.Text = "Enabled";
            this.checkBoxAutoFire.UseVisualStyleBackColor = true;
            this.checkBoxAutoFire.CheckedChanged += new System.EventHandler(this.OnAutoFireChange);
            // 
            // groupBoxAutoFire
            // 
            this.groupBoxAutoFire.Controls.Add(this.labelAutoFireToggle);
            this.groupBoxAutoFire.Controls.Add(this.comboBoxAutoFireSwitch);
            this.groupBoxAutoFire.Controls.Add(this.textBoxAutoFireRelease);
            this.groupBoxAutoFire.Controls.Add(this.labelAutoFireRel);
            this.groupBoxAutoFire.Controls.Add(this.textBoxAutoFireHold);
            this.groupBoxAutoFire.Controls.Add(this.labelAutoFireHold);
            this.groupBoxAutoFire.Controls.Add(this.checkBoxAutoFire);
            this.groupBoxAutoFire.Location = new System.Drawing.Point(15, 38);
            this.groupBoxAutoFire.Name = "groupBoxAutoFire";
            this.groupBoxAutoFire.Size = new System.Drawing.Size(186, 78);
            this.groupBoxAutoFire.TabIndex = 3;
            this.groupBoxAutoFire.TabStop = false;
            this.groupBoxAutoFire.Text = "Auto Fire";
            // 
            // labelAutoFireToggle
            // 
            this.labelAutoFireToggle.AutoSize = true;
            this.labelAutoFireToggle.Location = new System.Drawing.Point(87, 20);
            this.labelAutoFireToggle.Name = "labelAutoFireToggle";
            this.labelAutoFireToggle.Size = new System.Drawing.Size(40, 13);
            this.labelAutoFireToggle.TabIndex = 8;
            this.labelAutoFireToggle.Text = "Toggle";
            // 
            // comboBoxAutoFireSwitch
            // 
            this.comboBoxAutoFireSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAutoFireSwitch.FormattingEnabled = true;
            this.comboBoxAutoFireSwitch.Items.AddRange(new object[] {
            "OFF",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.comboBoxAutoFireSwitch.Location = new System.Drawing.Point(133, 17);
            this.comboBoxAutoFireSwitch.Name = "comboBoxAutoFireSwitch";
            this.comboBoxAutoFireSwitch.Size = new System.Drawing.Size(47, 21);
            this.comboBoxAutoFireSwitch.TabIndex = 7;
            this.comboBoxAutoFireSwitch.SelectionChangeCommitted += new System.EventHandler(this.comboBoxAutoFireSwitch_SelectionChangeCommitted);
            // 
            // textBoxAutoFireRelease
            // 
            this.textBoxAutoFireRelease.Location = new System.Drawing.Point(133, 44);
            this.textBoxAutoFireRelease.Name = "textBoxAutoFireRelease";
            this.textBoxAutoFireRelease.Size = new System.Drawing.Size(47, 20);
            this.textBoxAutoFireRelease.TabIndex = 6;
            this.textBoxAutoFireRelease.Text = "2";
            this.textBoxAutoFireRelease.TextChanged += new System.EventHandler(this.OnAutoFireChange);
            // 
            // labelAutoFireRel
            // 
            this.labelAutoFireRel.AutoSize = true;
            this.labelAutoFireRel.Location = new System.Drawing.Point(104, 47);
            this.labelAutoFireRel.Name = "labelAutoFireRel";
            this.labelAutoFireRel.Size = new System.Drawing.Size(23, 13);
            this.labelAutoFireRel.TabIndex = 5;
            this.labelAutoFireRel.Text = "Rel";
            // 
            // textBoxAutoFireHold
            // 
            this.textBoxAutoFireHold.Location = new System.Drawing.Point(38, 44);
            this.textBoxAutoFireHold.Name = "textBoxAutoFireHold";
            this.textBoxAutoFireHold.Size = new System.Drawing.Size(47, 20);
            this.textBoxAutoFireHold.TabIndex = 4;
            this.textBoxAutoFireHold.Text = "1";
            this.textBoxAutoFireHold.TextChanged += new System.EventHandler(this.OnAutoFireChange);
            // 
            // labelAutoFireHold
            // 
            this.labelAutoFireHold.AutoSize = true;
            this.labelAutoFireHold.Location = new System.Drawing.Point(7, 47);
            this.labelAutoFireHold.Name = "labelAutoFireHold";
            this.labelAutoFireHold.Size = new System.Drawing.Size(29, 13);
            this.labelAutoFireHold.TabIndex = 3;
            this.labelAutoFireHold.Text = "Hold";
            // 
            // checkBoxHoldNumPad
            // 
            this.checkBoxHoldNumPad.AutoSize = true;
            this.checkBoxHoldNumPad.Location = new System.Drawing.Point(15, 230);
            this.checkBoxHoldNumPad.Name = "checkBoxHoldNumPad";
            this.checkBoxHoldNumPad.Size = new System.Drawing.Size(92, 17);
            this.checkBoxHoldNumPad.TabIndex = 7;
            this.checkBoxHoldNumPad.Text = "Hold NumPad";
            this.checkBoxHoldNumPad.UseVisualStyleBackColor = true;
            this.checkBoxHoldNumPad.CheckedChanged += new System.EventHandler(this.OnNumPadChange);
            this.checkBoxHoldNumPad.TextChanged += new System.EventHandler(this.OnAutoFireChange);
            // 
            // groupBoxSaveBackup
            // 
            this.groupBoxSaveBackup.Controls.Add(this.textBoxSaveBackupMaxBackups);
            this.groupBoxSaveBackup.Controls.Add(this.label1);
            this.groupBoxSaveBackup.Controls.Add(this.labelSaveBackupMaxSize);
            this.groupBoxSaveBackup.Controls.Add(this.textBoxSaveBackupDir);
            this.groupBoxSaveBackup.Controls.Add(this.buttonSaveBackupOpen);
            this.groupBoxSaveBackup.Location = new System.Drawing.Point(15, 123);
            this.groupBoxSaveBackup.Name = "groupBoxSaveBackup";
            this.groupBoxSaveBackup.Size = new System.Drawing.Size(186, 101);
            this.groupBoxSaveBackup.TabIndex = 8;
            this.groupBoxSaveBackup.TabStop = false;
            this.groupBoxSaveBackup.Text = "Save Backup";
            // 
            // textBoxSaveBackupMaxBackups
            // 
            this.textBoxSaveBackupMaxBackups.Location = new System.Drawing.Point(127, 71);
            this.textBoxSaveBackupMaxBackups.Name = "textBoxSaveBackupMaxBackups";
            this.textBoxSaveBackupMaxBackups.Size = new System.Drawing.Size(53, 20);
            this.textBoxSaveBackupMaxBackups.TabIndex = 13;
            this.textBoxSaveBackupMaxBackups.Text = "100";
            this.textBoxSaveBackupMaxBackups.TextChanged += new System.EventHandler(this.textBoxSaveBackupMaxBackups_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Max backups to create";
            // 
            // labelSaveBackupMaxSize
            // 
            this.labelSaveBackupMaxSize.AutoSize = true;
            this.labelSaveBackupMaxSize.Location = new System.Drawing.Point(6, 48);
            this.labelSaveBackupMaxSize.Name = "labelSaveBackupMaxSize";
            this.labelSaveBackupMaxSize.Size = new System.Drawing.Size(115, 13);
            this.labelSaveBackupMaxSize.TabIndex = 8;
            this.labelSaveBackupMaxSize.Text = "Max file size to backup";
            // 
            // textBoxSaveBackupDir
            // 
            this.textBoxSaveBackupDir.Location = new System.Drawing.Point(6, 18);
            this.textBoxSaveBackupDir.Name = "textBoxSaveBackupDir";
            this.textBoxSaveBackupDir.Size = new System.Drawing.Size(115, 20);
            this.textBoxSaveBackupDir.TabIndex = 11;
            this.textBoxSaveBackupDir.TextChanged += new System.EventHandler(this.textBoxSaveBackupDir_TextChanged);
            // 
            // buttonSaveBackupOpen
            // 
            this.buttonSaveBackupOpen.Location = new System.Drawing.Point(127, 16);
            this.buttonSaveBackupOpen.Name = "buttonSaveBackupOpen";
            this.buttonSaveBackupOpen.Size = new System.Drawing.Size(53, 23);
            this.buttonSaveBackupOpen.TabIndex = 10;
            this.buttonSaveBackupOpen.Text = "Open";
            this.buttonSaveBackupOpen.UseVisualStyleBackColor = true;
            this.buttonSaveBackupOpen.Click += new System.EventHandler(this.buttonSaveBackupOpen_Click);
            // 
            // textBoxSaveBackupMaxFileSize
            // 
            this.textBoxSaveBackupMaxFileSize.Location = new System.Drawing.Point(142, 168);
            this.textBoxSaveBackupMaxFileSize.Name = "textBoxSaveBackupMaxFileSize";
            this.textBoxSaveBackupMaxFileSize.Size = new System.Drawing.Size(53, 20);
            this.textBoxSaveBackupMaxFileSize.TabIndex = 12;
            this.textBoxSaveBackupMaxFileSize.Text = "4096";
            this.textBoxSaveBackupMaxFileSize.TextChanged += new System.EventHandler(this.textBoxSaveBackupMaxFileSize_TextChanged);
            // 
            // Util
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 278);
            this.Controls.Add(this.textBoxSaveBackupMaxFileSize);
            this.Controls.Add(this.groupBoxSaveBackup);
            this.Controls.Add(this.checkBoxHoldNumPad);
            this.Controls.Add(this.groupBoxAutoFire);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Util";
            this.ShowIcon = false;
            this.Text = "Fangame Util";
            this.groupBoxAutoFire.ResumeLayout(false);
            this.groupBoxAutoFire.PerformLayout();
            this.groupBoxSaveBackup.ResumeLayout(false);
            this.groupBoxSaveBackup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.CheckBox checkBoxAutoFire;
        private System.Windows.Forms.GroupBox groupBoxAutoFire;
        private System.Windows.Forms.Label labelAutoFireHold;
        private System.Windows.Forms.Label labelAutoFireRel;
        private System.Windows.Forms.TextBox textBoxAutoFireHold;
        private System.Windows.Forms.TextBox textBoxAutoFireRelease;
        private System.Windows.Forms.CheckBox checkBoxHoldNumPad;
        private System.Windows.Forms.ComboBox comboBoxAutoFireSwitch;
        private System.Windows.Forms.GroupBox groupBoxSaveBackup;
        private System.Windows.Forms.TextBox textBoxSaveBackupDir;
        private System.Windows.Forms.Button buttonSaveBackupOpen;
        private System.Windows.Forms.Label labelAutoFireToggle;
        private System.Windows.Forms.Label labelSaveBackupMaxSize;
        private System.Windows.Forms.TextBox textBoxSaveBackupMaxFileSize;
        private System.Windows.Forms.TextBox textBoxSaveBackupMaxBackups;
        private System.Windows.Forms.Label label1;
    }
}
