using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //Used for file management

namespace Hgame_selector
{
    public partial class AddForm : Form
    {
        public Form1 Mainform;

        private string tempExtension;

        private Bitmap temp_icon;
        private VN dump;

        public AddForm(Form1 form)
        {
            InitializeComponent();

            Mainform = form;

            nwID_tbx.Text = form.col.getNextID().ToString();

            sizeForm();
        }

        ~AddForm()
        {
            if (temp_icon != null)
            {
                temp_icon.Dispose();
            }

            if (File.Exists(Application.StartupPath + "\\src\\images\\temp" + tempExtension))
            {
                if (temp_icon != null)
                {
                    temp_icon.Dispose();
                }

                File.Delete(Application.StartupPath + "\\src\\images\\temp" + tempExtension);
            }
        }
        
        private void sizeForm()
        {
            int scrn_w = Screen.PrimaryScreen.Bounds.Width, scrn_h = Screen.PrimaryScreen.Bounds.Height;

            this.Width = Convert.ToInt32(scrn_w * 0.6);
            this.Height = Convert.ToInt32(scrn_h * 0.5);

            resizeForm();
        }

        private void resizeForm()
        {
            AdHg_grpbx.Width = this.Width - 32;
            AdHg_grpbx.Height = this.Height - 58;
            AdHg_grpbx.Location = new Point(8, 8);

            int tbx_X = Convert.ToInt32(this.Width / 10);
            int tbx_w = Convert.ToInt32(this.Width * 0.5);
            int tbx_h = Convert.ToInt32(this.Height * 0.05);
            int tbx_btn_w = Convert.ToInt32(this.Width * 0.12);



            //nwHg_img.Width = Convert.ToInt32(this.Width * 0.35);
            //nwHg_img.Height = Convert.ToInt32(this.Height * 0.5);

            nwHg_img.Width = Convert.ToInt32(this.Width * 0.245);
            nwHg_img.Height = Convert.ToInt32(this.Height * 0.35);
            nwHg_img.Location = new Point(tbx_X + tbx_w + tbx_btn_w + 5, 20 + nwHgimg_lbl.Height);

            nwHgimg_lbl.Location = new Point(tbx_X + tbx_w + tbx_btn_w + 5 + ((nwHg_img.Width / 2) - (nwHgimg_lbl.Width / 2)), 20);

            nwID_tbx.Width = tbx_w;
            nwID_tbx.Height = tbx_h;
            nwID_tbx.Location = new Point(tbx_X, 21);

            nwID_lbl.Location = new Point(tbx_X - nwID_lbl.Width, 24);

            btn_DLSITE.Width = tbx_w;
            btn_DLSITE.Location = new Point(tbx_X, 21 + btn_DLSITE.Height);

            btn_VNDB.Width = tbx_w;
            btn_VNDB.Location = new Point(tbx_X, 21 + (btn_VNDB.Height * 2));

            nwNm_tbx.Width = tbx_w;
            nwNm_tbx.Height = tbx_h;
            nwNm_tbx.Location = new Point(tbx_X, 20 + (btn_VNDB.Height * 2) + (tbx_h * 1));

            nwNm_lbl.Location = new Point(tbx_X - nwNm_lbl.Width, 24 + (btn_VNDB.Height * 2) + (tbx_h * 1));

            nwJPNm_tbx.Width = tbx_w;
            nwJPNm_tbx.Height = tbx_h;
            nwJPNm_tbx.Location = new Point(tbx_X, 20 + (btn_VNDB.Height * 2) + (tbx_h * 2));

            nwJPNm_lbl.Location = new Point(tbx_X - nwJPNm_lbl.Width, 24 + (btn_VNDB.Height * 2) + (tbx_h * 2));

            nwExe_tbx.Width = tbx_w;
            nwExe_tbx.Height = tbx_h;
            nwExe_tbx.Location = new Point(tbx_X, 20 + (btn_VNDB.Height * 2) + (tbx_h * 3));

            nwExe_lbl.Location = new Point(tbx_X - nwExe_lbl.Width, 24 + (btn_VNDB.Height * 2) + (tbx_h * 3));

            nwExe_btn.Height = 22;
            nwExe_btn.Width = tbx_btn_w;
            nwExe_btn.Location = new Point(tbx_X + tbx_w, 19 + (btn_VNDB.Height * 2) + (tbx_h * 3));

            nwIcn_tbx.Width = tbx_w;
            nwIcn_tbx.Height = tbx_h;
            nwIcn_tbx.Location = new Point(tbx_X, 20 + (btn_VNDB.Height * 2) + (tbx_h * 4));

            nwIcn_lbl.Location = new Point(tbx_X - nwIcn_lbl.Width, 24 + (btn_VNDB.Height * 2) + (tbx_h * 4));

            nwIcon_btn.Height = 22;
            nwIcon_btn.Width = tbx_btn_w;
            nwIcon_btn.Location = new Point(tbx_X + tbx_w, 19 + (btn_VNDB.Height * 2) + (tbx_h * 4));

            nwDv_tbx.Width = tbx_w;
            nwDv_tbx.Height = tbx_h;
            nwDv_tbx.Location = new Point(tbx_X, 20 + (btn_VNDB.Height * 2) + (tbx_h * 5));

            nwDv_lbl.Location = new Point(tbx_X - nwDv_lbl.Width, 24 + (btn_VNDB.Height * 2) + (tbx_h * 5));

            nwGen_tbx.Width = tbx_w;
            nwGen_tbx.Height = tbx_h * 4;
            nwGen_tbx.Location = new Point(tbx_X, 20 + (btn_VNDB.Height * 2) + (tbx_h * 6));

            nwTag_lbl.Location = new Point(tbx_X - nwTag_lbl.Width, 24 + (btn_VNDB.Height * 2) + (tbx_h * 6));

            nwHg_sub_btn.Width = AdHg_grpbx.Width - 16;
            nwHg_sub_btn.Location = new Point(8, 20 + (tbx_h * 6) + (btn_VNDB.Height * 2) + (tbx_h * 4));
        }

        private void nwExe_btn_Click(object sender, EventArgs e)
        {
            nwExe_tbx.Text = Mainform.getFilePath("exe files (.exe)|*.exe|All files (*.*)|*.*");
        }

        private void nwIcon_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files | *.jpg; *.jpeg; *.png;|All files|*.*";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                //String fileName = Path.GetFileName(path);
                string extension = Path.GetExtension(path);

                if (File.Exists(Application.StartupPath + "\\src\\images\\temp" + extension))
                {
                    if (temp_icon != null)
                    {
                        temp_icon.Dispose();
                    }

                    File.Delete(Application.StartupPath + "\\src\\images\\temp" + extension);
                }

                File.Copy(path, Application.StartupPath + "\\src\\images\\temp" + extension);


                temp_icon = new Bitmap(@Application.StartupPath + "\\src\\images\\temp" + extension);
                nwHg_img.BackgroundImage = temp_icon;


                nwIcn_tbx.Text = Application.StartupPath + "\\src\\images\\" + nwID_tbx.Text + extension;

                tempExtension = extension;
            }
        }

        private void nwHg_sub_btn_Click(object sender, EventArgs e)
        {
            List<string> genres = nwGen_tbx.Text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();

            File.Copy(Application.StartupPath + "\\src\\images\\temp" + tempExtension, nwIcn_tbx.Text);

            nwHg_img.BackgroundImage = null;
            temp_icon.Dispose();

            File.Delete(Application.StartupPath + "\\src\\images\\temp" + tempExtension);

            Mainform.col.AddHgame(new Hgame(Int32.Parse(nwID_tbx.Text), nwNm_tbx.Text, nwJPNm_tbx.Text, nwDv_tbx.Text, nwExe_tbx.Text, Path.GetFileName(nwIcn_tbx.Text), genres));

            Mainform.col.genPool("", "All");
            Mainform.showPage();
            Mainform.WriteCol();

            clearAddForm();
        }

        private void clearAddForm()
        {
            nwID_tbx.Text = Mainform.col.getNextID().ToString();
            nwNm_tbx.Text = string.Empty;
            nwJPNm_tbx.Text = string.Empty;
            nwExe_tbx.Text = string.Empty;
            nwIcn_tbx.Text = string.Empty;
            nwDv_tbx.Text = string.Empty;
            nwGen_tbx.Text = string.Empty;
            nwHg_img.BackgroundImage = null;

            if (temp_icon != null)
            {
                temp_icon.Dispose();
            }
        }

        private void btn_DLSITE_Click(object sender, EventArgs e)
        {
            DlsiteForm dlImport = new DlsiteForm(this);

            dlImport.ShowDialog();
        }

        public void pull_Dlsite_data(string code)
        {
            String url = Mainform.generate_dlsite_url(code);

            string extension = Path.GetExtension(url);

            if (url != null)
            {
                if (File.Exists(Application.StartupPath + "/src/images/temp" + extension))
                {
                    if (temp_icon != null)
                    {
                        temp_icon.Dispose();
                    }

                    File.Delete(Application.StartupPath + "/src/images/temp" + extension);
                }

                Mainform.download_file(url, "src/images/", "temp" + extension);

                while (!File.Exists(Application.StartupPath + "/src/images/temp" + extension))
                {
                    Console.WriteLine(Application.StartupPath + "src/images/temp" + extension);
                }

                temp_icon = new Bitmap(@Application.StartupPath + "/src/images/temp" + extension);
                nwHg_img.BackgroundImage = temp_icon;

                nwIcn_tbx.Text = Application.StartupPath + "/src/images/" + nwID_tbx.Text + extension;

                tempExtension = extension;
            }
        }

        private void btn_VNDB_Click(object sender, EventArgs e)
        {
            VndbForm VNImport = new VndbForm(this);

            VNImport.ShowDialog();
        }

        public void apply_VNDB_data(String url)
        {
            String id = Mainform.VNDB_URL_to_ID(url);

            dump = Mainform.getVN(id);

            if (dump != null)
            {
                nwNm_tbx.Text = dump.title;
                nwJPNm_tbx.Text = dump.original;

                string extension = Path.GetExtension(dump.image);

                if (File.Exists(Application.StartupPath + "/src/images/temp" + extension))
                {
                    if (temp_icon != null)
                    {
                        temp_icon.Dispose();
                    }

                    File.Delete(Application.StartupPath + "/src/images/temp" + extension);
                }

                Mainform.download_file(dump.image, "src/images/", "temp" + extension);

                while (!File.Exists(Application.StartupPath + "/src/images/temp" + extension))
                {
                    Console.WriteLine(Application.StartupPath + "src/images/temp" + extension);
                }

                temp_icon = new Bitmap(@Application.StartupPath + "/src/images/temp" + extension);
                nwHg_img.BackgroundImage = temp_icon;

                nwIcn_tbx.Text = Application.StartupPath + "/src/images/" + nwID_tbx.Text + extension;

                tempExtension = extension;
            }

            dump = null;
        }
    }
}
