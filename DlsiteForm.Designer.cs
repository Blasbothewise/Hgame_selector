namespace Hgame_selector
{
    partial class DlsiteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlsiteForm));
            this.label1 = new System.Windows.Forms.Label();
            this.Code_tbx = new System.Windows.Forms.TextBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RJ/RE code";
            // 
            // Code_tbx
            // 
            this.Code_tbx.Location = new System.Drawing.Point(77, 10);
            this.Code_tbx.Name = "Code_tbx";
            this.Code_tbx.Size = new System.Drawing.Size(143, 20);
            this.Code_tbx.TabIndex = 1;
            // 
            // submit_btn
            // 
            this.submit_btn.Location = new System.Drawing.Point(77, 36);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(143, 23);
            this.submit_btn.TabIndex = 2;
            this.submit_btn.Text = "submit";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // DlsiteForm
            // 
            this.AcceptButton = this.submit_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 68);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.Code_tbx);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlsiteForm";
            this.Text = "Import DLsite info";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DlsiteForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Code_tbx;
        private System.Windows.Forms.Button submit_btn;
    }
}