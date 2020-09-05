using System;
using Newtonsoft.Json; //Reducing typing significantly
using System.Drawing; //For bitmaps
using System.IO; //For reading and writing JSON 
using System.Collections.Generic; // For list and other things
using System.Linq; //For ToList

using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Net.Sockets; //for tcp
using System.Net; //Used for downloading dlsite images
using System.Net.Security; //SSL


using System.Windows.Forms;

namespace Hgame_selector
{
    public partial class Form1 : Form
    {
        public Config conf;
        public Collection col;
        private Tags tag_col;
        private int page_index = 0;
        private Bitmap pg_1, pg_2, pg_3, pg_4, pg_5, pg_6, pg_7, pg_8, pg_9, pg_10, pg_11, pg_12, pg_13, pg_14, pg_15;
        private TcpClient client;
        private SslStream sslsteam;
        private NetworkStream stream;

        public Form1()
        {

            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            deserialiseJSON();
            col.genPool("","All");

            if (!Directory.Exists(Application.StartupPath + "\\src\\images"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\src\\images");
            }

            showPage();

            openConn();

            if (conf.UseCreds == false)
            {
                login_basic();
            }
            else
            {
                login();
            }
        }
         
        private void login_basic()
        {
            sendCommand("login {\"protocol\":1,\"client\":\"VN_selector\",\"clientver\":0.7}");
        }

        private void login()
        {
            String response = sendCommand("login {\"protocol\":1,\"client\":\"VN_selector\",\"clientver\":0.7,\"username\":\"" + conf.User + "\",\"password\":\"" + conf.Pass + "\"}"); 
        }

        public Boolean testLogin(String usr, String pass)
        {
            closeConn();
            openConn();

            String response = sendCommand("login {\"protocol\":1,\"client\":\"VN_selector\",\"clientver\":0.7,\"username\":\"" + usr + "\",\"password\":\"" + pass + "\"}");

            // Console.WriteLine("~" + response + "~");

            if (response.Equals("ok"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void openConn()
        {

            try
            {

                String host = "api.vndb.org";
                Int32 port = 19534;
                Int32 tls_port = 19535;

                client = new TcpClient();
                client.Connect(host, tls_port);
                stream = client.GetStream();
                sslsteam = new SslStream(stream);

                sslsteam.AuthenticateAsClient("api.vndb.org");
               
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public string sendCommand(String command)
        {

            Byte[] encoded = Encoding.UTF8.GetBytes(command); //Convert message to bytes

            Byte endByte = 0x04; //Byte that tells VNDB that the they have reached the end of the message.

            Byte[] data = new byte[encoded.Length + 1]; //New array of the required length to incorporate end byte.

            Buffer.BlockCopy(encoded, 0, data, 0, encoded.Length); //Copy all bytes from the encoded message to the new array with no offset.

            data[encoded.Length] = endByte; // Add end byte to the end of the new array

            sslsteam.Write(data, 0, data.Length); //Send the new array to VNDB

            Console.WriteLine("Sent: {0}", command);

            data = new Byte[4096];
            String responseData = String.Empty;

            Int32 bytes = sslsteam.Read(data, 0, data.Length);

            responseData = Encoding.UTF8.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            return responseData;
        }

        public string generate_dlsite_url(string code)
        {
            try
            {
                string suffixCode = "";

                string rounded_code = (Math.Ceiling(Convert.ToDouble(code.Substring(2)) / 1000) * 1000).ToString();

                while (rounded_code.Length < 6)
                {
                    rounded_code = "0" + rounded_code;
                }

                while (rounded_code.Length < 6)
                {
                    rounded_code = rounded_code + "0";
                }

                if (code.Substring(0, 2).Equals("RE"))
                {
                    suffixCode = "RJ" + rounded_code;
                    code = "RJ" + code.Substring(2);
                }
                else if (code.Substring(0, 2).Equals("RJ"))
                {
                    suffixCode = "RJ" + rounded_code;
                }
                else
                {
                    return null;
                }

                return "https://img.dlsite.jp/modpub/images2/work/doujin/" + suffixCode + "/" + code + "_img_main.jpg";
            }
            catch
            {
                return null;
            }
        }

        public void download_file(string url, string directory, string filename)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, directory + filename);
            }
        }


        public string VNDB_URL_to_ID(String url)
        {
            return new string(url.Where(c => char.IsDigit(c)).ToArray());
        }

        public VN getVN(String id)
        {
            String strJSON_VN = sendCommand("get vn basic,details (id = " + id + ")");

            strJSON_VN = strJSON_VN.Substring(strJSON_VN.IndexOf('[') + 1);

            strJSON_VN = strJSON_VN.Substring(0, strJSON_VN.LastIndexOf(']'));

            try
            {
                return JsonConvert.DeserializeObject<VN>(strJSON_VN);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
                return null;
            }
        }

        private void closeConn()
        {
            stream.Close();
            client.Close();
        }

        public void search(string srchTerm, string srchType)
        {

            col.genPool(srchTerm, srchType);
            page_index = 0;
            page_lbl.Text = "" + 0 + "";
            col.genPage(page_index);
            showPage();

            srch_tbx.Text = string.Empty;
        }

        private void deserialiseJSON()
        {
            if (!Directory.Exists(Application.StartupPath + "\\src"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\src");
            }

            //Collection

            if (!File.Exists(Application.StartupPath + "\\src\\HgameCollection.json"))
            {

                using (StreamWriter r = new StreamWriter(Application.StartupPath + "\\src\\HgameCollection.json"))
                {
                    r.WriteLine("{");
                    r.WriteLine("   \"Total\" : 1,");
                    r.WriteLine("   \"Last_Index\" : 1,");
                    r.WriteLine("   \"Hgames\" : [");
                    r.WriteLine("    ");
                    r.WriteLine("   ]");
                    r.WriteLine("}");

                }
            }

            string strJSON_col = string.Empty;

            using (StreamReader r = new StreamReader(Application.StartupPath + "\\src\\HgameCollection.json"))
            {
                strJSON_col = r.ReadToEnd();
            }

            try
            {
                col = JsonConvert.DeserializeObject<Collection>(strJSON_col);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }

            //Config

            if (!File.Exists(Application.StartupPath + "\\src\\Config.json"))
            {
                using (StreamWriter r = new StreamWriter(Application.StartupPath + "\\src\\Config.json"))
                {
                    r.WriteLine("{");
                    r.WriteLine("   \"User\" : \"\",");
                    r.WriteLine("   \"Pass\" : \"\",");
                    r.WriteLine("   \"UseCreds\" : false");
                    r.WriteLine("}");
                }
            }

            string strJSON_conf = string.Empty;

            using (StreamReader r = new StreamReader(Application.StartupPath + "\\src\\Config.json"))
            {
                strJSON_conf = r.ReadToEnd();
            }

            try
            {
                conf = JsonConvert.DeserializeObject<Config>(strJSON_conf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }

            
            //Tags

        }

        public void showPage()
        {

            if (page_index < 0)
            {
                page_index = 0;
                col.genPage(0);
            }
            else if (page_index > col.get_Last_Index())
            {
                page_index = col.get_Last_Index();
                col.genPage(col.get_Last_Index());
            }
            else
            {
                col.genPage(page_index);
            }


            clearPage();


            Button[] btnArr = { Col_opt_1_btn, Col_opt_2_btn, Col_opt_3_btn, Col_opt_4_btn, Col_opt_5_btn, Col_opt_6_btn, Col_opt_7_btn, Col_opt_8_btn, Col_opt_9_btn, Col_opt_10_btn, Col_opt_11_btn, Col_opt_12_btn, Col_opt_13_btn, Col_opt_14_btn, Col_opt_15_btn };

            for (int i = 0; i < col.GetPage().Count; i++)
            {

                if (i == 0)
                {
                    pg_1 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_1;
                }
                else if (i == 1)
                {
                    pg_2 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_2;
                }
                else if (i == 2)
                {
                    pg_3 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_3;
                }
                else if (i == 3)
                {
                    pg_4 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_4;
                }
                else if (i == 4)
                {
                    pg_5 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_5;
                }
                else if (i == 5)
                {
                    pg_6 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_6;
                }
                else if (i == 6)
                {
                    pg_7 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_7;
                }
                else if (i == 7)
                {
                    pg_8 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_8;
                }
                else if (i == 8)
                {
                    pg_9 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_9;
                }
                else if (i == 9)
                {
                    pg_10 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_10;
                }
                else if (i == 10)
                {
                    pg_11 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_11;
                }
                else if (i == 11)
                {
                    pg_12 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_12;
                }
                else if (i == 12)
                {
                    pg_13 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_13;
                }
                else if (i == 13)
                {
                    pg_14 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_14;
                }
                else if (i == 14)
                {
                    pg_15 = new Bitmap(@Application.StartupPath + "\\src\\images\\" + col.GetPage()[i].iconName);
                    btnArr[i].BackgroundImage = pg_15;
                }
            }

            page_lbl.Text = page_index.ToString();

            if (page_index == 0)
            {
                Pge_start_btn.Enabled = false;
                Pge_lft_btn.Enabled = false;
                pge_rt_btn.Enabled = true;
                Pge_end_btn.Enabled = true;
            }
            else if (page_index == col.get_Last_Index())
            {
                Pge_start_btn.Enabled = true;
                Pge_lft_btn.Enabled = true;
                pge_rt_btn.Enabled = false;
                Pge_end_btn.Enabled = false;
            }
            else
            {
                Pge_start_btn.Enabled = true;
                Pge_lft_btn.Enabled = true;
                pge_rt_btn.Enabled = true;
                Pge_end_btn.Enabled = true;
            }
        }

        public void clearPage()
        {
            Button[] btnArr = { Col_opt_1_btn, Col_opt_2_btn, Col_opt_3_btn, Col_opt_4_btn, Col_opt_5_btn, Col_opt_6_btn, Col_opt_7_btn, Col_opt_8_btn, Col_opt_9_btn, Col_opt_10_btn, Col_opt_11_btn, Col_opt_12_btn, Col_opt_13_btn, Col_opt_14_btn, Col_opt_15_btn };

            for (int i = 0; i < 15; i++)
            {
                btnArr[i].BackgroundImage = null;
            }

            if (pg_1 != null)
            {
                pg_1.Dispose();
            }

            if (pg_2 != null)
            {
                pg_2.Dispose();
            }

            if (pg_3 != null)
            {
                pg_3.Dispose();
            }

            if (pg_4 != null)
            {
                pg_4.Dispose();
            }

            if (pg_5 != null)
            {
                pg_5.Dispose();
            }

            if (pg_6 != null)
            {
                pg_6.Dispose();
            }

            if (pg_7 != null)
            {
                pg_7.Dispose();
            }

            if (pg_8 != null)
            {
                pg_8.Dispose();
            }

            if (pg_9 != null)
            {
                pg_9.Dispose();
            }

            if (pg_10 != null)
            {
                pg_10.Dispose();
            }

            if (pg_11 != null)
            {
                pg_11.Dispose();
            }

            if (pg_12 != null)
            {
                pg_12.Dispose();
            }

            if (pg_13 != null)
            {
                pg_13.Dispose();
            }

            if (pg_14 != null)
            {
                pg_14.Dispose();
            }

            if (pg_15 != null)
            {
                pg_15.Dispose();
            }

        }

        private void srch_btn_Click(object sender, EventArgs e)
        {
            search(srch_tbx.Text, srch_typ_Cbox.Text);
        }

        private void srch_tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search(srch_tbx.Text, srch_typ_Cbox.Text);
            }
        }

        private void Pge_start_btn_Click(object sender, EventArgs e)
        {
            page_index = 0;
            showPage();
        }

        private void Pge_lft_btn_Click(object sender, EventArgs e)
        {
            page_index--;
            showPage();
        }

        private void pge_rt_btn_Click(object sender, EventArgs e)
        {
            page_index++;
            showPage();
        }

        private void Pge_end_btn_Click(object sender, EventArgs e)
        {
            page_index = col.get_Last_Index();
            showPage();
        }

        private void shw_ev_btn_Click(object sender, EventArgs e)
        {
            search("", "All");
        }

        public void WriteCol()
        {
            File.WriteAllText(@Application.StartupPath + "\\src\\HgameCollection.json", JsonConvert.SerializeObject(col, Formatting.Indented));
        }

        private void Form1_Load(object sender, EventArgs e) //On close form
        {

        }
        public String getFilePath(string dialogFilter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = dialogFilter;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }

            return null;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Col_Bx.Width = Convert.ToInt32(this.Width - 42);
            Col_Bx.Height = Convert.ToInt32(this.Height - 78);

            int w = Convert.ToInt32(Col_Bx.Width * 0.175), h = Convert.ToInt32(this.Height * 0.25);
            int w_5 = this.Width / 5; //form width divided by 5.
            int h_4 = this.Height / 4; //form height divided by 4.
            int button_width = Convert.ToInt32(w / 2);

            Col_opt_1_btn.Width = Convert.ToInt32(w);
            Col_opt_1_btn.Height = Convert.ToInt32(h);
            Col_opt_1_btn.Location = new Point(6,40);

            Col_opt_2_btn.Width = Convert.ToInt32(w);
            Col_opt_2_btn.Height = Convert.ToInt32(h);
            Col_opt_2_btn.Location = new Point((w_5 * 1), 40);

            Col_opt_3_btn.Width = Convert.ToInt32(w);
            Col_opt_3_btn.Height = Convert.ToInt32(h);
            Col_opt_3_btn.Location = new Point((w_5 * 2), 40);

            Col_opt_4_btn.Width = Convert.ToInt32(w);
            Col_opt_4_btn.Height = Convert.ToInt32(h);
            Col_opt_4_btn.Location = new Point((w_5 * 3), 40);

            Col_opt_5_btn.Width = Convert.ToInt32(w);
            Col_opt_5_btn.Height = Convert.ToInt32(h);
            Col_opt_5_btn.Location = new Point((w_5 * 4), 40);

            Col_opt_6_btn.Width = Convert.ToInt32(w);
            Col_opt_6_btn.Height = Convert.ToInt32(h);
            Col_opt_6_btn.Location = new Point(6, 40 + (h_4 * 1));

            Col_opt_7_btn.Width = Convert.ToInt32(w);
            Col_opt_7_btn.Height = Convert.ToInt32(h);
            Col_opt_7_btn.Location = new Point((w_5 * 1), 40 + (h_4 * 1));

            Col_opt_8_btn.Width = Convert.ToInt32(w);
            Col_opt_8_btn.Height = Convert.ToInt32(h);
            Col_opt_8_btn.Location = new Point((w_5 * 2), 40 + (h_4 * 1));

            Col_opt_9_btn.Width = Convert.ToInt32(w);
            Col_opt_9_btn.Height = Convert.ToInt32(h);
            Col_opt_9_btn.Location = new Point((w_5 * 3), 40 + (h_4 * 1));


            Col_opt_10_btn.Width = Convert.ToInt32(w);
            Col_opt_10_btn.Height = Convert.ToInt32(h);
            Col_opt_10_btn.Location = new Point((w_5 * 4), 40 + (h_4 * 1));

            Col_opt_11_btn.Width = Convert.ToInt32(w);
            Col_opt_11_btn.Height = Convert.ToInt32(h);
            Col_opt_11_btn.Location = new Point(6, 40 + (h_4 * 2));

            Col_opt_12_btn.Width = Convert.ToInt32(w);
            Col_opt_12_btn.Height = Convert.ToInt32(h);
            Col_opt_12_btn.Location = new Point((w_5 * 1), 40 + (h_4 * 2));

            Col_opt_13_btn.Width = Convert.ToInt32(w);
            Col_opt_13_btn.Height = Convert.ToInt32(h);
            Col_opt_13_btn.Location = new Point((w_5 * 2), 40 + (h_4 * 2));

            Col_opt_14_btn.Width = Convert.ToInt32(w);
            Col_opt_14_btn.Height = Convert.ToInt32(h);
            Col_opt_14_btn.Location = new Point((w_5 * 3), 40 + (h_4 * 2));

            Col_opt_15_btn.Width = Convert.ToInt32(w);
            Col_opt_15_btn.Height = Convert.ToInt32(h);
            Col_opt_15_btn.Location = new Point((w_5 * 4), 40 + (h_4 * 2));

            Pge_start_btn.Width = button_width;
            Pge_start_btn.Height = Col_Bx.Height - ((h * 3) + 46);
            Pge_start_btn.Location = new Point(6, 40 + (h_4 * 3));
            Pge_lft_btn.Width = button_width;
            Pge_lft_btn.Height = Col_Bx.Height - ((h * 3) + 46);
            Pge_lft_btn.Location = new Point((6 + w) - Pge_lft_btn.Width, 40 + (h_4 * 3));

            if(Convert.ToInt32(Pge_lft_btn.Height * 0.9) != 0)
            {
                page_lbl.Font = new Font(page_lbl.Font.Name, Convert.ToInt32(Pge_lft_btn.Height * 0.9), page_lbl.Font.Style, page_lbl.Font.Unit);
            }

            
            page_lbl.Location = new Point((Col_Bx.Width / 2) - (page_lbl.Width / 2), (Col_Bx.Height - (Pge_lft_btn.Height / 2)) - (page_lbl.Height / 2));

            pge_rt_btn.Width = button_width;
            pge_rt_btn.Height = Col_Bx.Height - ((h * 3) + 46);
            pge_rt_btn.Location = new Point((w_5 * 4), 40 + (h_4 * 3));
            Pge_end_btn.Width = button_width;
            Pge_end_btn.Height = Col_Bx.Height - ((h * 3) + 46);
            Pge_end_btn.Location = new Point(((w_5 * 4) + w) - pge_rt_btn.Width, 40 + (h_4 * 3));
        }

        private void execute_exe(int Hgameindex)
        {
            if (col.GetPage().Count > Hgameindex)
            {
                Process.Start(col.GetPage()[Hgameindex].exePath);
            }
        }

        private void edit_hgame()
        {
            EditForm edit = new EditForm(this);
            edit.ShowDialog();
        }

        private void edit_hgame(int page_index) //Override for when hgame is supplied
        {
            try
            {

                Hgame edit_Hgame = col.GetPage()[page_index];



                EditForm edit = new EditForm(this, edit_Hgame);

                edit.ShowDialog();
            
            }
            catch
            { 
            
            }
        }

        private void add_hgame()
        {
            AddForm add = new AddForm(this);
            add.ShowDialog();
        }

        private void Conf_tlStpmnuitm_Click(object sender, EventArgs e)
        {
            ConfigForm conf = new ConfigForm(this);
            conf.ShowDialog();
        }

        private void addHgm_tlStpmnuitm_Click(object sender, EventArgs e)
        {
            add_hgame();
        }

        private void edtHgm_tlStpmnuitm_Click(object sender, EventArgs e)
        {
            edit_hgame();
        }

        private void rmvHgm_tlStpmnuitm_Click(object sender, EventArgs e)
        {
            RemoveForm rmv = new RemoveForm(this);
            rmv.ShowDialog();
        }

        #region COLLECTION BUTTONS

        private void Col_opt_1_btn_Click(object sender, EventArgs e)
        {
            execute_exe(0);
        }

        private void Col_opt_1_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(0);
            }
        }

        private void Col_opt_2_btn_Click(object sender, EventArgs e)
        {
            execute_exe(1);
        }

        private void Col_opt_2_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(1);
            }
        }

        private void Col_opt_3_btn_Click(object sender, EventArgs e)
        {
            execute_exe(2);
        }

        private void Col_opt_3_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(2);
            }
        }

        private void Col_opt_4_btn_Click(object sender, EventArgs e)
        {
            execute_exe(3);
        }

        private void Col_opt_4_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(3);
            }
        }

        private void Col_opt_5_btn_Click(object sender, EventArgs e)
        {
            execute_exe(4);
        }

        private void Col_opt_5_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(4);
            }
        }

        private void Col_opt_6_btn_Click(object sender, EventArgs e)
        {
            execute_exe(5);
        }

        private void Col_opt_6_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(5);
            }
        }

        private void Col_opt_7_btn_Click(object sender, EventArgs e)
        {
            execute_exe(6);
        }

        private void Col_opt_7_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(6);
            }
        }

        private void Col_opt_8_btn_Click(object sender, EventArgs e)
        {
            execute_exe(7);
        }

        private void Col_opt_8_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(7);
            }
        }

        private void VNDBtagArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open file dialog
        }

        private void Col_opt_9_btn_Click(object sender, EventArgs e)
        {
            execute_exe(8);
        }

        private void Col_opt_9_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(8);
            }
        }

        private void Col_opt_10_btn_Click(object sender, EventArgs e)
        {
            execute_exe(9);
        }

        private void Col_opt_10_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(9);
            }
        }

        private void Col_opt_11_btn_Click(object sender, EventArgs e)
        {
            execute_exe(10);
        }

        private void Col_opt_11_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(10);
            }
        }

        private void Col_opt_12_btn_Click(object sender, EventArgs e)
        {
            execute_exe(11);
        }

        private void Col_opt_12_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(11);
            }
        }

        private void Col_opt_13_btn_Click(object sender, EventArgs e)
        {
            execute_exe(12);
        }

        private void Col_opt_13_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(12);
            }
        }

        private void Col_opt_14_btn_Click(object sender, EventArgs e)
        {
            execute_exe(13);
        }

        private void Col_opt_14_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(13);
            }
        }

        private void Col_opt_15_btn_Click(object sender, EventArgs e)
        {
            execute_exe(14);
        }

        private void Col_opt_15_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                edit_hgame(14);
            }
        }

        #endregion
    }
}
