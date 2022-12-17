namespace FangameUtil
{
    partial class Util
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.checkBoxAutoFire = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAutoFireRelease = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAutoFireHold = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxHoldNumPad = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAutoFireRelease);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxAutoFireHold);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxAutoFire);
            this.groupBox1.Location = new System.Drawing.Point(15, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 72);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Fire";
            // 
            // textBoxAutoFireRelease
            // 
            this.textBoxAutoFireRelease.Location = new System.Drawing.Point(133, 40);
            this.textBoxAutoFireRelease.Name = "textBoxAutoFireRelease";
            this.textBoxAutoFireRelease.Size = new System.Drawing.Size(47, 20);
            this.textBoxAutoFireRelease.TabIndex = 6;
            this.textBoxAutoFireRelease.TextChanged += new System.EventHandler(this.OnAutoFireChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rel";
            // 
            // textBoxAutoFireHold
            // 
            this.textBoxAutoFireHold.Location = new System.Drawing.Point(38, 40);
            this.textBoxAutoFireHold.Name = "textBoxAutoFireHold";
            this.textBoxAutoFireHold.Size = new System.Drawing.Size(47, 20);
            this.textBoxAutoFireHold.TabIndex = 4;
            this.textBoxAutoFireHold.TextChanged += new System.EventHandler(this.OnAutoFireChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hold";
            // 
            // checkBoxHoldNumPad
            // 
            this.checkBoxHoldNumPad.AutoSize = true;
            this.checkBoxHoldNumPad.Location = new System.Drawing.Point(21, 116);
            this.checkBoxHoldNumPad.Name = "checkBoxHoldNumPad";
            this.checkBoxHoldNumPad.Size = new System.Drawing.Size(92, 17);
            this.checkBoxHoldNumPad.TabIndex = 7;
            this.checkBoxHoldNumPad.Text = "Hold NumPad";
            this.checkBoxHoldNumPad.UseVisualStyleBackColor = true;
            this.checkBoxHoldNumPad.CheckedChanged += new System.EventHandler(this.OnNumPadChange);
            this.checkBoxHoldNumPad.TextChanged += new System.EventHandler(this.OnAutoFireChange);
            // 
            // Util
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 150);
            this.Controls.Add(this.checkBoxHoldNumPad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Name = "Util";
            this.Text = "Fangame Util";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.CheckBox checkBoxAutoFire;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAutoFireHold;
        private System.Windows.Forms.TextBox textBoxAutoFireRelease;
        private System.Windows.Forms.CheckBox checkBoxHoldNumPad;
    }
}
