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
    public partial class EditForm : Form
    {
        Form1 Mainform;
        private Bitmap tempEdit_icon, editOld_icon;
        private Hgame edit_Hgame;

        private string tempExtension, oldicon_dir;

        public EditForm(Form1 form)
        {
            InitializeComponent();

            Mainform = form;

            sizeForm();
        }

        ~EditForm()
        {
            if (tempEdit_icon != null)
            {
                tempEdit_icon.Dispose();
            }

            if (File.Exists(Application.StartupPath + "\\src\\images\\Edittemp" + tempExtension))
            {
                if (tempEdit_icon != null)
                {
                    tempEdit_icon.Dispose();
                }

                File.Delete(Application.StartupPath + "\\src\\images\\Edittemp" + tempExtension);
            }
        }

        public EditForm(Form1 form, Hgame edit_Hgame)
        {
            InitializeComponent();

            Mainform = form;

            this.edit_Hgame = edit_Hgame;

            oldicon_dir = edit_Hgame.iconName;

            //Populate edit form with hgame data

            EdtHg_srch_tbx.Text = edit_Hgame.id.ToString();

            EdtNm_tbx.Text = edit_Hgame.name;
            EdtJPNm_tbx.Text = edit_Hgame.jp_Name;
            EdtExe_tbx.Text = edit_Hgame.exePath;
            EdtIcn_tbx.Text = Application.StartupPath + "\\src\\images\\" + edit_Hgame.iconName;

            editOld_icon = new Bitmap(@Application.StartupPath + "\\src\\images\\" + edit_Hgame.iconName);
            EdtHg_img.BackgroundImage = editOld_icon;

            EdtDv_tbx.Text = edit_Hgame.dev;

            string genres = "";

            for (int i = 0; i < edit_Hgame.genres.Count; i++)
            {
                if (i != edit_Hgame.genres.Count - 1)
                {
                    genres += edit_Hgame.genres[i] + "\r\n";
                }
                else
                {
                    genres += edit_Hgame.genres[i];
                }

            }

            EdtGen_tbx.Text = genres;

            sizeForm();
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
            EdtHg_grpBx.Width = this.Width - 32;
            EdtHg_grpBx.Height = this.Height - 58;
            EdtHg_grpBx.Location = new Point(8, 8);

            int tbx_X = Convert.ToInt32(this.Width / 10);
            int tbx_w = Convert.ToInt32(this.Width * 0.5);
            int tbx_h = Convert.ToInt32(this.Height * 0.05);
            int tbx_btn_w = Convert.ToInt32(this.Width * 0.12);

            

            //EdtHg_img.Width = Convert.ToInt32(this.Width * 0.35);
            //EdtHg_img.Height = Convert.ToInt32(this.Height * 0.5);

            EdtHg_img.Width = Convert.ToInt32(this.Width * 0.245);
            EdtHg_img.Height = Convert.ToInt32(this.Height * 0.35);
            EdtHg_img.Location = new Point(tbx_X + tbx_w + tbx_btn_w + 5, 20 + EdtHgimg_lbl.Height);

            EdtHgimg_lbl.Location = new Point(tbx_X + tbx_w + tbx_btn_w + 5 + ((EdtHg_img.Width / 2) - (EdtHgimg_lbl.Width / 2)), 20);

            EdtHg_srch_tbx.Width = tbx_w;
            EdtHg_srch_tbx.Height = tbx_h;
            EdtHg_srch_tbx.Location = new Point(tbx_X, 21);

            EdtHg_srch_lbl.Location = new Point(tbx_X - EdtHg_srch_lbl.Width, 24);

            EdtHg_srch_btn.Height = 22;
            EdtHg_srch_btn.Width = tbx_btn_w;
            EdtHg_srch_btn.Location = new Point(tbx_X + tbx_w, 20);

            ChkBx_Edit.Location = new Point(tbx_X, 20 + ChkBx_Edit.Height + 7);

            EdtNm_tbx.Width = tbx_w;
            EdtNm_tbx.Height = tbx_h;
            EdtNm_tbx.Location = new Point(tbx_X, 20 + ChkBx_Edit.Height + (tbx_h * 1));

            EdtNm_lbl.Location = new Point(tbx_X - EdtNm_lbl.Width, 24 + ChkBx_Edit.Height + (tbx_h * 1));

            EdtJPNm_tbx.Width = tbx_w;
            EdtJPNm_tbx.Height = tbx_h;
            EdtJPNm_tbx.Location = new Point(tbx_X, 20 + ChkBx_Edit.Height + (tbx_h * 2));

            EdtJPNm_lbl.Location = new Point(tbx_X - EdtJPNm_lbl.Width, 24 + ChkBx_Edit.Height + (tbx_h * 2));

            EdtExe_tbx.Width = tbx_w;
            EdtExe_tbx.Height = tbx_h;
            EdtExe_tbx.Location = new Point(tbx_X, 20 + ChkBx_Edit.Height + (tbx_h * 3));

            EdtExe_lbl.Location = new Point(tbx_X - EdtExe_lbl.Width, 24 + ChkBx_Edit.Height + (tbx_h * 3));

            edtExe_btn.Height = 22;
            edtExe_btn.Width = tbx_btn_w;
            edtExe_btn.Location = new Point(tbx_X + tbx_w, 20 + ChkBx_Edit.Height + (tbx_h * 3));

            EdtIcn_tbx.Width = tbx_w;
            EdtIcn_tbx.Height = tbx_h;
            EdtIcn_tbx.Location = new Point(tbx_X, 20 + ChkBx_Edit.Height + (tbx_h * 4));

            EdtIcn_lbl.Location = new Point(tbx_X - EdtIcn_lbl.Width, 24 + ChkBx_Edit.Height + (tbx_h * 4));

            edtIcon_btn.Height = 22;
            edtIcon_btn.Width = tbx_btn_w;
            edtIcon_btn.Location = new Point(tbx_X + tbx_w, 20 + ChkBx_Edit.Height + (tbx_h * 4));

            EdtDv_tbx.Width = tbx_w;
            EdtDv_tbx.Height = tbx_h;
            EdtDv_tbx.Location = new Point(tbx_X, 20 + ChkBx_Edit.Height + (tbx_h * 5));

            EdtDv_lbl.Location = new Point(tbx_X - EdtDv_lbl.Width, 24 + ChkBx_Edit.Height + (tbx_h * 5));

            EdtGen_tbx.Width = tbx_w;
            EdtGen_tbx.Height = tbx_h * 4;
            EdtGen_tbx.Location = new Point(tbx_X, 20 + ChkBx_Edit.Height + (tbx_h * 6));

            EdtTag_lbl.Location = new Point(tbx_X - EdtTag_lbl.Width, 24 + ChkBx_Edit.Height + (tbx_h * 6));

            EdtHg_sub_btn.Width = EdtHg_grpBx.Width - 16;
            EdtHg_sub_btn.Location = new Point(8, 20 + ChkBx_Edit.Height + (tbx_h * 6) + (tbx_h * 4));

            ChkBx_Rmv.Location = new Point(8, 20 + ChkBx_Edit.Height + 7 + (tbx_h * 7) + (tbx_h * 4) + ChkBx_Edit.Height + 7);

            EdtHg_rmv_btn.Width = EdtHg_grpBx.Width - 16;
            EdtHg_rmv_btn.Location = new Point(8, 20 + ChkBx_Edit.Height + (tbx_h * 6) + (tbx_h * 4) + EdtHg_sub_btn.Height + ChkBx_Edit.Height + 7);
        }


        private void EdtHg_sub_btn_Click(object sender, EventArgs e)
        {
            int result;

            if (Int32.TryParse(EdtHg_srch_tbx.Text, out result) == true)
            {
                EdtHg_img.BackgroundImage = null;

                if (tempEdit_icon != null)
                {
                    tempEdit_icon.Dispose();
                }

                Mainform.clearPage();


                int ID = Int32.Parse(EdtHg_srch_tbx.Text);
                List<string> genres = EdtGen_tbx.Text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
                Hgame old_toEdit = Mainform.col.GetHgame(ID);

                if (!EdtNm_tbx.Text.Trim().Equals(""))
                {
                    old_toEdit.name = EdtNm_tbx.Text;
                }

                if (!EdtJPNm_tbx.Text.Trim().Equals(""))
                {
                    old_toEdit.jp_Name = EdtJPNm_tbx.Text;
                }

                if (!EdtDv_tbx.Text.Trim().Equals(""))
                {
                    old_toEdit.dev = EdtDv_tbx.Text;
                }

                if (!EdtExe_tbx.Text.Trim().Equals(""))
                {
                    old_toEdit.exePath = EdtExe_tbx.Text;
                }

                if (File.Exists(Application.StartupPath + "\\src\\images\\Edittemp" + tempExtension))
                {
                    if (File.Exists(Application.StartupPath + "\\src\\images\\" + EdtHg_srch_tbx.Text + tempExtension))
                    {
                        File.Delete(Application.StartupPath + "\\src\\images\\" + EdtHg_srch_tbx.Text + tempExtension);
                    }

                    File.Copy(Application.StartupPath + "\\src\\images\\Edittemp" + tempExtension, Application.StartupPath + "\\src\\images\\" + EdtHg_srch_tbx.Text + tempExtension);

                    EdtHg_img.BackgroundImage = null;
                    tempEdit_icon.Dispose();
                    File.Delete(Application.StartupPath + "\\src\\images\\Edittemp" + tempExtension);
                    old_toEdit.iconName = Path.GetFileName(EdtIcn_tbx.Text);
                }
                else
                {
                    EdtHg_img.BackgroundImage = null;
                    if (tempEdit_icon != null)
                    {
                        tempEdit_icon.Dispose();
                    }
                }

                if (genres != null)
                {
                    old_toEdit.genres = genres;
                }

                if (!old_toEdit.iconName.Equals(oldicon_dir))
                {
                    if (File.Exists(Application.StartupPath + "\\src\\images\\" + oldicon_dir))
                    {
                        File.Delete(Application.StartupPath + "\\src\\images\\" + oldicon_dir);
                    }
                }

                Mainform.regen_pool();
                Mainform.showPage();
                
                Mainform.WriteCol(); //Write collection
            }
            else
            {
                //Not an int
                Console.WriteLine("Error ID not valid");
            }

            clearEditForm();
        }

        private void clearEditForm()
        {
            EdtHg_srch_tbx.Text = string.Empty;
            EdtNm_tbx.Text = string.Empty;
            EdtJPNm_tbx.Text = string.Empty;
            EdtExe_tbx.Text = string.Empty;
            EdtIcn_tbx.Text = string.Empty;
            EdtDv_tbx.Text = string.Empty;
            EdtGen_tbx.Text = string.Empty;

            EdtNm_tbx.Enabled = false;
            EdtJPNm_tbx.Enabled = false;
            EdtExe_tbx.Enabled = false;
            EdtIcn_tbx.Enabled = false;
            EdtDv_tbx.Enabled = false;
            EdtGen_tbx.Enabled = false;
            EdtHg_sub_btn.Enabled = false;
            EdtHg_img.BackgroundImage = null;

            if (tempEdit_icon != null)
            {
                tempEdit_icon.Dispose();
            }

            if (editOld_icon != null)
            {
                editOld_icon.Dispose();
            }

            ChkBx_Edit.Checked = false;
        }

        private void edtIcon_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files | *.jpg; *.jpeg; *.png;|All files|*.*";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                String fileName = Path.GetFileName(path);
                string extension = Path.GetExtension(path);

                if (File.Exists(Application.StartupPath + "\\src\\images\\Edittemp" + extension))
                {
                    try
                    {
                        if (tempEdit_icon != null)
                        {
                            tempEdit_icon.Dispose();
                        }

                        File.Delete(Application.StartupPath + "\\src\\images\\Edittemp" + extension);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                File.Copy(path, Application.StartupPath + "\\src\\images\\Edittemp" + extension);

                tempEdit_icon = new Bitmap(@Application.StartupPath + "\\src\\images\\Edittemp" + extension);
                EdtHg_img.BackgroundImage = tempEdit_icon;

                if (editOld_icon != null)
                {
                    editOld_icon.Dispose();
                }

                EdtIcn_tbx.Text = Application.StartupPath + "\\src\\images\\" + EdtHg_srch_tbx.Text + extension;

                tempExtension = extension;
            }
        }

        private void edtExe_btn_Click(object sender, EventArgs e)
        {
            EdtExe_tbx.Text = Mainform.getFilePath("exe files (.exe)|*.exe|All files (*.*)|*.*");
        }

        private void ChkBx_Edit_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBx_Edit.CheckState == CheckState.Checked)
            {
                EdtNm_tbx.Enabled = true;
                EdtJPNm_tbx.Enabled = true;
                EdtExe_tbx.Enabled = true;
                edtExe_btn.Enabled = true;
                EdtIcn_tbx.Enabled = true;
                edtIcon_btn.Enabled = true;
                EdtDv_tbx.Enabled = true;
                EdtGen_tbx.Enabled = true;
                EdtHg_sub_btn.Enabled = true;

                ChkBx_Rmv.Enabled = false;
            }
            else if (ChkBx_Edit.CheckState == CheckState.Unchecked)
            {
                EdtNm_tbx.Enabled = false;
                EdtJPNm_tbx.Enabled = false;
                EdtExe_tbx.Enabled = false;
                edtExe_btn.Enabled = false;
                EdtIcn_tbx.Enabled = false;
                edtIcon_btn.Enabled = false;
                EdtDv_tbx.Enabled = false;
                EdtGen_tbx.Enabled = false;
                EdtHg_sub_btn.Enabled = false;

                ChkBx_Rmv.Enabled = true;
            }
            else
            {

            }
        }

        private void ChkBx_Rmv_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkBx_Rmv.CheckState == CheckState.Checked)
            {
                EdtHg_rmv_btn.Enabled = true;
                ChkBx_Edit.Enabled = false;
            }
            else if (ChkBx_Rmv.CheckState == CheckState.Unchecked)
            {
                ChkBx_Edit.Enabled = true;
                EdtHg_rmv_btn.Enabled = false;
            }
            else
            {

            }
        }

        private void EdtHg_rmv_btn_Click(object sender, EventArgs e)
        {
            int result;

            if (Int32.TryParse(EdtHg_srch_tbx.Text, out result) == true)
            {
                int ID = Int32.Parse(EdtHg_srch_tbx.Text);
                string iconPath = EdtIcn_tbx.Text;

                Mainform.col.RemoveHgame(Mainform.col.GetHgame(ID));

                Mainform.regen_pool();
                Mainform.showPage();

                clearEditForm();

                try
                {
                    if (File.Exists(iconPath))
                    {
                        File.Delete(iconPath);
                    }
                }
                catch (IOException ey)
                {
                    Console.WriteLine(ey);
                }



                Mainform.WriteCol(); //Write collection
            }
        }

        private void EdtHg_srch_btn_Click(object sender, EventArgs e)
        {
            EdtNm_tbx.Text = "";
            EdtExe_tbx.Text = "";
            EdtIcn_tbx.Text = "";
            EdtDv_tbx.Text = "";
            EdtGen_tbx.Text = "";

            if (EdtHg_srch_tbx.Text.Equals(""))
            {
                //Empty
            }
            else
            {
                int result;

                if (Int32.TryParse(EdtHg_srch_tbx.Text, out result) == true)
                {
                    Hgame toEdit = Mainform.col.GetHgame(Int32.Parse(EdtHg_srch_tbx.Text));

                    if (toEdit != null)
                    {
                        EdtNm_tbx.Text = toEdit.name;
                        EdtJPNm_tbx.Text = toEdit.jp_Name;
                        EdtExe_tbx.Text = toEdit.exePath;
                        EdtIcn_tbx.Text = Application.StartupPath + "\\src\\images\\" + toEdit.iconName;

                        editOld_icon = new Bitmap(@Application.StartupPath + "\\src\\images\\" + toEdit.iconName);
                        EdtHg_img.BackgroundImage = editOld_icon;

                        EdtDv_tbx.Text = toEdit.dev;

                        string genres = "";

                        for (int i = 0; i < toEdit.genres.Count; i++)
                        {
                            if (i != toEdit.genres.Count - 1)
                            {
                                genres += toEdit.genres[i] + "\r\n";
                            }
                            else
                            {
                                genres += toEdit.genres[i];
                            }

                        }

                        EdtGen_tbx.Text = genres;
                    }
                    else
                    {
                        //No hgame exists with ID
                    }
                }
                else
                {
                    //Not an int
                }
            }
        }
    }
}
