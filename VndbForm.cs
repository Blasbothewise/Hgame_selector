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
    public partial class VndbForm : Form
    {
        AddForm parentForm;

        public VndbForm(AddForm add)
        {
            InitializeComponent();
            parentForm = add;
        }

        private void srch_btn_Click(object sender, EventArgs e)
        {
            srch_tbx.Text.Trim();

            parentForm.apply_VNDB_data(srch_tbx.Text);

            this.Close();
        }
    }
}
