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
    public partial class DlsiteForm : Form
    {
        AddForm parentForm;

        public DlsiteForm(AddForm add)
        {
            InitializeComponent();
            this.parentForm = add;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            Code_tbx.Text.Trim();
            parentForm.pull_Dlsite_data(Code_tbx.Text);
            this.Close();
        }
    }
}
