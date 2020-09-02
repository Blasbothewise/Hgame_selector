namespace Hgame_selector
{
    partial class ConfigForm
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
            this.usr_tbx = new System.Windows.Forms.TextBox();
            this.usr_lbl = new System.Windows.Forms.Label();
            this.pass_lbl = new System.Windows.Forms.Label();
            this.pass_tbx = new System.Windows.Forms.TextBox();
            this.usCred_Chkbx = new System.Windows.Forms.CheckBox();
            this.connTest_btn = new System.Windows.Forms.Button();
            this.connTest_tbx = new System.Windows.Forms.TextBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usr_tbx
            // 
            this.usr_tbx.Location = new System.Drawing.Point(73, 6);
            this.usr_tbx.Name = "usr_tbx";
            this.usr_tbx.Size = new System.Drawing.Size(100, 20);
            this.usr_tbx.TabIndex = 0;
            // 
            // usr_lbl
            // 
            this.usr_lbl.AutoSize = true;
            this.usr_lbl.Location = new System.Drawing.Point(12, 9);
            this.usr_lbl.Name = "usr_lbl";
            this.usr_lbl.Size = new System.Drawing.Size(55, 13);
            this.usr_lbl.TabIndex = 1;
            this.usr_lbl.Text = "Username";
            // 
            // pass_lbl
            // 
            this.pass_lbl.AutoSize = true;
            this.pass_lbl.Location = new System.Drawing.Point(14, 35);
            this.pass_lbl.Name = "pass_lbl";
            this.pass_lbl.Size = new System.Drawing.Size(53, 13);
            this.pass_lbl.TabIndex = 2;
            this.pass_lbl.Text = "Password";
            // 
            // pass_tbx
            // 
            this.pass_tbx.Location = new System.Drawing.Point(73, 32);
            this.pass_tbx.Name = "pass_tbx";
            this.pass_tbx.Size = new System.Drawing.Size(100, 20);
            this.pass_tbx.TabIndex = 3;
            // 
            // usCred_Chkbx
            // 
            this.usCred_Chkbx.AutoSize = true;
            this.usCred_Chkbx.Location = new System.Drawing.Point(15, 58);
            this.usCred_Chkbx.Name = "usCred_Chkbx";
            this.usCred_Chkbx.Size = new System.Drawing.Size(132, 17);
            this.usCred_Chkbx.TabIndex = 5;
            this.usCred_Chkbx.Text = "Use VDNB credentials";
            this.usCred_Chkbx.UseVisualStyleBackColor = true;
            // 
            // connTest_btn
            // 
            this.connTest_btn.Location = new System.Drawing.Point(15, 80);
            this.connTest_btn.Name = "connTest_btn";
            this.connTest_btn.Size = new System.Drawing.Size(100, 20);
            this.connTest_btn.TabIndex = 6;
            this.connTest_btn.Text = "test connectivity";
            this.connTest_btn.UseVisualStyleBackColor = true;
            this.connTest_btn.Click += new System.EventHandler(this.connTest_btn_Click);
            // 
            // connTest_tbx
            // 
            this.connTest_tbx.ForeColor = System.Drawing.Color.DarkRed;
            this.connTest_tbx.Location = new System.Drawing.Point(121, 80);
            this.connTest_tbx.Name = "connTest_tbx";
            this.connTest_tbx.Size = new System.Drawing.Size(52, 20);
            this.connTest_tbx.TabIndex = 7;
            this.connTest_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(15, 122);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(158, 23);
            this.save_btn.TabIndex = 8;
            this.save_btn.Text = "save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 150);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.connTest_tbx);
            this.Controls.Add(this.connTest_btn);
            this.Controls.Add(this.usCred_Chkbx);
            this.Controls.Add(this.pass_tbx);
            this.Controls.Add(this.pass_lbl);
            this.Controls.Add(this.usr_lbl);
            this.Controls.Add(this.usr_tbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usr_tbx;
        private System.Windows.Forms.Label usr_lbl;
        private System.Windows.Forms.Label pass_lbl;
        private System.Windows.Forms.TextBox pass_tbx;
        private System.Windows.Forms.CheckBox usCred_Chkbx;
        private System.Windows.Forms.Button connTest_btn;
        private System.Windows.Forms.TextBox connTest_tbx;
        private System.Windows.Forms.Button save_btn;
    }
}