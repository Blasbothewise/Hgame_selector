namespace Hgame_selector
{
    partial class VndbForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VndbForm));
            this.srch_tbx = new System.Windows.Forms.TextBox();
            this.srch_lbl = new System.Windows.Forms.Label();
            this.sub_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // srch_tbx
            // 
            this.srch_tbx.Location = new System.Drawing.Point(42, 8);
            this.srch_tbx.Name = "srch_tbx";
            this.srch_tbx.Size = new System.Drawing.Size(266, 20);
            this.srch_tbx.TabIndex = 43;
            // 
            // srch_lbl
            // 
            this.srch_lbl.AutoSize = true;
            this.srch_lbl.Location = new System.Drawing.Point(7, 11);
            this.srch_lbl.Name = "srch_lbl";
            this.srch_lbl.Size = new System.Drawing.Size(29, 13);
            this.srch_lbl.TabIndex = 44;
            this.srch_lbl.Text = "URL";
            // 
            // sub_btn
            // 
            this.sub_btn.Location = new System.Drawing.Point(42, 34);
            this.sub_btn.Name = "sub_btn";
            this.sub_btn.Size = new System.Drawing.Size(266, 21);
            this.sub_btn.TabIndex = 47;
            this.sub_btn.Text = "Submit";
            this.sub_btn.UseVisualStyleBackColor = true;
            this.sub_btn.Click += new System.EventHandler(this.srch_btn_Click);
            // 
            // VndbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 65);
            this.Controls.Add(this.sub_btn);
            this.Controls.Add(this.srch_lbl);
            this.Controls.Add(this.srch_tbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VndbForm";
            this.Text = "Import VNDB VN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox srch_tbx;
        private System.Windows.Forms.Label srch_lbl;
        private System.Windows.Forms.Button sub_btn;
    }
}