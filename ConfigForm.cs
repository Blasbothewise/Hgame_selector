using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hgame_selector
{
    public partial class ConfigForm : Form
    {
        Form1 Mainform;

        public ConfigForm(Form1 form)
        {
            InitializeComponent();

            Mainform = form;

            sizeForm();

            usr_tbx.Text = Mainform.conf.User;
            pass_tbx.Text = Mainform.conf.Pass;
            usCred_Chkbx.Checked = Mainform.conf.UseCreds;
        }

        private void sizeForm()
        { 
            
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Boolean result = Mainform.testLogin(usr_tbx.Text, pass_tbx.Text);

            if (result == true)
            {
                connTest_tbx.ForeColor = Color.ForestGreen;
                connTest_tbx.Text = "Success";

                Mainform.conf.User = usr_tbx.Text;
                Mainform.conf.Pass = pass_tbx.Text;

                Mainform.conf.UseCreds = usCred_Chkbx.Checked;
                this.Close();
            }
            else
            {
                connTest_tbx.ForeColor = Color.DarkRed;
                connTest_tbx.Text = "Failed";
            }

        }

        private void connTest_btn_Click(object sender, EventArgs e)
        {
            Boolean result = Mainform.testLogin(usr_tbx.Text, pass_tbx.Text);

            if (result == true)
            {
                connTest_tbx.ForeColor = Color.ForestGreen;
                connTest_tbx.Text = "Success";
            }
            else
            {
                connTest_tbx.ForeColor = Color.DarkRed;
                connTest_tbx.Text = "Failed";
            }
        }

        private void ConfigForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
