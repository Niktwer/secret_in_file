using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Reflection;

namespace secret_true_version
{
    public partial class Form1 : Form
    {
        //set extension secret max befory 10% file
        string[] extension = new string[] { "jpg", "bmp", "avi", "mp4", "gif", "mp3" };


        string folder_d, default_languare,name_base;
        string _7zPath, ver; //путь к 7z.exe
        string args, out_f, con, ex, file_out, def_l;
        int Lx, Ly, Rw, Rh, lan_, dialog,i;
        bool[] file_dir = new bool[4];
        string[] path_file = new string[2];
        
        string[,] status = new string[8, 6];
        string[,] message = new string[8, 6];
        String[,] caption = new string[8, 6];
        string[] rez = new string[8];
        Bitmap[] flag = new Bitmap[8];
        string[] file = new string[2];
        string[] file_s = new string[2];
        string[] ext = new string[1];
        string password_secret = "11";
        string[] folder = new string[] { Properties.Resources.folder, Properties.Resources.folder_out };
        string[] languare = new string[] { "", "en-US", "ru-RU", "fr-FR", "es-ES", "de-DE", "pl-PL", "uk-UA", "ja-JP", "zh-CN" };

        bool ok, pass;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //create_in(folder[0]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EXEStarter asm = new EXEStarter();
            ver = asm.assembly();
            this.Text = Properties.Resources.zag_text + " " + ver;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //default_languare = CultureInfo.CurrentUICulture.Name;

           
            
            lan_def();
            //textBox1.Text = "Localization of Windows language - " + def_l;

            checkBox1.Location = new Point(40, 251);
            //checkBox1.Size = new Size(541, 41);

            pictureBox1.BackColor = Color.Transparent;

            setting();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public Form1(string passwod, string lan_d)
        {
            InitializeComponent();
            string password2 = passwod;
            lan_ = 0;
            default_languare = lan_d;
            //cordinat();
            setting();
            folder_d = Environment.CurrentDirectory + "\\";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            EXEStarter ff = new EXEStarter();
            _7zPath = ff.TypeOs(dt);
            if (_7zPath == null)
            { Application.Exit(); }
            else
            {
                path_file = new string[] { _7zPath, folder_d+Properties.Resources.out_file + dt.ToString("hhmm") + Properties.Resources.file };
                text_rez(0); }


            if (radioButton1.Checked == true)
            {
                //Dedicated file is verifiable on the secret 
                look_secret();
            }

            if (radioButton2.Checked == true)
            {
                //In the selected file creates a "secret" 

                create_secret();
            }

            if (radioButton3.Checked == true)
            {
                // Delete secret
                delete_secret();
            }

            if (radioButton4.Checked == true)
            {
                // Show secret
                show_secret();
            }

            Del_unness();
        }

        private void create_secret()
        {
            string size;
            string[] selected_file = new string[2];
            string[] selected_file_short = new string[2];
            float sizefile;
            EXEStarter ffs = new EXEStarter();

            //0. select file for secret in file
            input_secret:
            file = Select_file(0,false);
            if (file[0] == null)
            { return; }
            else
            {
                if (size_file(file[1])< float.Parse(Properties.Resources.size))
                {
                    selected_file_short[0] = file[0];
                    selected_file[0] = file[1];
                }
                else
                {
                    var mrez = MessageBox.Show(message[7, 1] + file[1]+" ("+ string.Format("{0:0.#}", size_file(file[1]))+" MB)", caption[7, 1] + Properties.Resources.size + " MB.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (mrez == DialogResult.OK)
                    { goto input_secret; }
                    else
                    { return; }
                    
                }
            }

            //1. select the file where the secret will be stored
            repit:
            file = Select_file(1,true);
            if (file[0] == null|| selected_file[0]==file[1])
            { return; }
            else
            {
                selected_file[1] = file[1];
                selected_file_short[1] = file[0];
            }

            // 2. compare selected files
            sizefile = (size_file(selected_file[0])) * float.Parse(Properties.Resources.compare);
            if (sizefile> (size_file(selected_file[1]))) 
            {
                var mrez = MessageBox.Show(message[7, 0] +string.Format("{0:0.#}", sizefile) + " MB (" + selected_file[1]+")", caption[7, 0] , MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mrez == DialogResult.OK)
                { goto repit; }
                else
                { return; }
            }


            //3. Select a place and file name with a secret 
            file_s = Save_file();
            if (file_s[0] == null)
            { return; }

            //4. copyring secret in file to local folder 
            //ffs.copy(@selected_file[0], @folder_d+ selected_file_short[0]);
            ffs.copy(@selected_file[1], @folder_d + selected_file_short[1]);


            //5. Create secret.zip in local folder
            //_7zPath = folder_d + Properties.Resources.file;
            args = Properties.Resources.arg_create + set_password(false) + path_file[1] + " " + selected_file[0];

            textBox1.Text = textBox1.Text + ffs.mess(0, args);
            con = ffs.Start(_7zPath, args.ToString(), true); //запускаем 7z.exe
            textBox1.Text = textBox1.Text + ffs.mess(1, con);
            if (!File.Exists(Properties.Resources.out_file))
            {
                // This statement ensures that the file is created,
                // but the handle is not kept.
                using (FileStream fs = File.Create(Properties.Resources.out_file)) { }

            }
           // size = size_file(Properties.Resources.out_file);



            //3. Select file 
            //file = Select_file(1,true);
            //if (file[0] == null)
            //{ return; }
            //if (ffs.exist_local(file[1], folder_d + file[0]))
            //{

                //4. copyring secret file to local folder 
               // ffs.copy(@file[1], @folder_d + file[0]);
           // }

            // 5.verife in this file contain secret
            //ffs.copy(@scs.FileName,@folder_d + scs.SafeFileName);

            args = "e -tzip -r0 -ssw " + set_password(true) + file[1] + " " + folder_d + Properties.Resources.folder;
            con = Do_7z(args); //запускаем 7z.exe

            //4. IF ok write to texbox
            out_rez(con.Contains(Properties.Resources.ok_password), 2);

            //5. Selected place and name secret file
            

            // copy file for delete
            ffs.copy(@file[1], @folder_d + Properties.Resources.folder + "//" + file_s[1]);




            //6. Made secret file in current folder
            args = Properties.Resources.copy + file[0] + "+" + Properties.Resources.out_file + " " + file_s[1];
            textBox1.Text = textBox1.Text + ffs.mess(0, args);
            con = ffs.Start(Properties.Resources.exe, args, true);//

            textBox1.Text = textBox1.Text + ffs.mess(3, con);



            //7. Testing local secret file in local place
            //_7zPath = Properties.Resources.file;
            args = Properties.Resources.arg_test + Properties.Resources.out_file;

            textBox1.Text = textBox1.Text + ffs.mess(4, args);
            con = ffs.Start(_7zPath, args.ToString(), true); //запускаем 7z.exe
            textBox1.Text = textBox1.Text + ffs.mess(1, con);


            //8. IF ok move in selected place
            ok = con.Contains(Properties.Resources.ok_password);

            if (ok)
            {
                ffs.copy(@folder_d + file_s[1], @out_f);

                textBox1.Text = rez[lan_] + radioButton2.Text + ">: " + label1.Text + " " + file_s[1];
            }
            else
            {
                //File.Delete(@folder_d + file_out);
                textBox1.Text = rez[lan_] + radioButton2.Text + ">: " + label2.Text + " " + file_s[1];
            }

            //9. Delete unnecessary files
            //File.Delete(@folder_d + file_s[1]);

        }

        private void show_secret()
        {
            //1. Select  file with secret
            file = Select_file(0,true);
            if (file[0] == null)
            { return; }

            //2. copyring secret file to local folder
            copy_to_local();

            //3. Testing secret file in local folders

            args = Properties.Resources.arg_test + set_password(true) + file[0];
            con = Do_7z(args);

            //4. IF ok move in local folder
            bool ok = con.Contains(Properties.Resources.ok_password);

            if (ok)
            {
                //5. Exctract secret file in current folder
                args = "x " + file[0] + " " + Properties.Resources.arg_exctract + folder_d + Properties.Resources.folder;
                //textBox1.Text = textBox1.Text + sfs.mess(0, args);
                con = Do_7z(args);

                //    textBox1.Text = textBox1.Text + sfs.mess(3, con);

                //6. Delete unnecessary files
                File.Delete(@folder_d + Properties.Resources.folder + "\\" + file[0]);
                textBox1.Text = rez[lan_] + radioButton4.Text + ">: " + label3.Text + " " + folder_d + Properties.Resources.folder;
            }
            else
            {
                //File.Delete(@folder_d + file_out);
                textBox1.Text = rez[lan_] + radioButton4.Text + ">: " + label4.Text + " " + folder_d + Properties.Resources.folder;
            }


        }
        private void Del_unness()
        {
            foreach (string file in path_file)
            {
                if (System.IO.File.Exists(file))
                {
                    File.Delete(@file);//знищуемо файл
                }
            }
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton3_ButtonClick(object sender, EventArgs e)
        {

        }
        private void tsmi_clear()
        {
            
            TSMI_EA.Checked = false;
            TSMI_RU.Checked = false;
            TSMI_FR.Checked = false;
            TSMI_ES.Checked = false;
            TSMI_DE.Checked = false;
            TSMI_POL.Checked = false;
            TSMI_UA.Checked = false;
            textBox1.Text = "";

        }



        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lan_ = 0;

            ChangeLanguage(default_languare);
            languare_click();
        }

        private void TSMI_EA_Click(object sender, EventArgs e)
        {
            lan_ = 1;
            ChangeLanguage(languare[lan_]);


            toolStripStatusLabel1.Image = Properties.Resources.United_States_of_America.ToBitmap();
            languare_click();
        }

        private void TSMI_DE_Click(object sender, EventArgs e)
        {
            lan_ = 5;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void TSMI_FR_Click(object sender, EventArgs e)
        {
            lan_ = 3;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void TSMI_RU_Click(object sender, EventArgs e)
        {
            lan_ = 2;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            text_rez(2);
            if (radioButton1.Checked == true)
            {
                richTextBox1.Visible = true;
                richTextBox3.Visible = false;
                richTextBox4.Visible = false;
                richTextBox2.Visible = false;
                textBox1.Text = "";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            text_rez(2);
            if (radioButton3.Checked == true)
            {
                richTextBox1.Visible = false;
                richTextBox2.Visible = false;
                richTextBox4.Visible = false;

                richTextBox3.Location = new Point(Lx, Ly);
                richTextBox3.Width = Rw;
                richTextBox3.Height = Rh;
                richTextBox3.Visible = true;
                textBox1.Text = "";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            text_rez(2);
            if (radioButton4.Checked == true)
            {
                richTextBox1.Visible = false;
                richTextBox2.Visible = false;
                richTextBox3.Visible = false;

                richTextBox4.Location = new Point(Lx, Ly);
                richTextBox4.Width = Rw;
                richTextBox4.Height = Rh;
                richTextBox4.Visible = true;
                textBox1.Text = "";
            }
        }

        private void TSMI_POL_Click(object sender, EventArgs e)
        {
            lan_ = 6;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            text_rez(1);
            if (radioButton2.Checked == true)
            {

                checkBox1.Visible = true;

                richTextBox1.Visible = false;
                richTextBox3.Visible = false;
                richTextBox4.Visible = false;

                richTextBox2.Location = new Point(Lx, Ly);
                richTextBox2.Width = Rw;
                richTextBox2.Height = Rh;
                richTextBox2.Visible = true;
                textBox1.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SS_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TSMI_UA_Click(object sender, EventArgs e)
        {
            lan_ = 7;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void TSMI_ES_Click(object sender, EventArgs e)
        {
            lan_ = 4;
            ChangeLanguage(languare[lan_]);
            languare_click();

        }

        private void look_secret()
        {
            //1. select file with secret
            file = Select_file(0,true);
            if (file[0] == null)
            { return; }

            //2. verife contain in file secreting
            args = Properties.Resources.arg_test + set_password(true) + file[1] + " *"  + Properties.Resources.file;
            con = Do_7z(args); //запускаем 7z.exe

            //3. IF ok write to texbox
            out_rez(con.Contains(Properties.Resources.ok_password), 1);
        }


        private void delete_secret()
        {
            //1. Select  file with secret
            file = Select_file(0,true);
            if (file[0] == null)
            { return; }

            //2. copyring secret file to local folder
            copy_to_local();

            //3. Testing secret file in local folders

            //4. IF ok move in local folder
            bool ok = con.Contains(Properties.Resources.ok_password);

            if (ok)
            {
                //5. Exctract secret file in current folder
                args = "x " + file[0] + " " + Properties.Resources.arg_exctract + folder_d + Properties.Resources.folder;
                //textBox1.Text = textBox1.Text + sfs.mess(0, args);
                con = Do_7z(args);

                //    textBox1.Text = textBox1.Text + sfs.mess(3, con);

                //6. Delete unnecessary files
                File.Delete(@folder_d + Properties.Resources.folder + "\\" + file[0]);
                textBox1.Text = rez[lan_] + radioButton4.Text + ">: " + label3.Text + " " + folder_d + Properties.Resources.folder;
            }
            else
            {
                //File.Delete(@folder_d + file_out);
                textBox1.Text = rez[lan_] + radioButton4.Text + ">: " + label4.Text + " " + folder_d + Properties.Resources.folder;
            }

            args = Properties.Resources.arg_test + set_password(true) + file[0];
            con = Do_7z(args);

            //path[2] = folder_d + Properties.Resources.out_file;
        }

        private void create_in(string catalog)
        {
            if (radioButton1.Checked == true || radioButton3.Checked == true)
            { button1.Enabled = true; }

            if (EXEStarter.create_folder(catalog) == false)
            { button1.Enabled = false; }
            else
            {
                String[] file = Directory.GetFiles(folder_d + Properties.Resources.folder, "*.*");
                switch (file.Length)
                {
                    case 0:
                        if (radioButton2.Checked == true)
                            button1.Enabled = true;

                        if (radioButton4.Checked == true)
                            button1.Enabled = true;

                        break;

                    default:
                        if (radioButton2.Checked == true)
                            button1.Enabled = true;

                        if (radioButton4.Checked == true)
                            button1.Enabled = false;

                        break;
                }
            }
        }


        private void ChangeLanguage(string newLanguageString)
        {
            var resources = new ComponentResourceManager(typeof(Form1));
            CultureInfo newCultureInfo = new CultureInfo(newLanguageString);
            //Применяем для каждого контрола на форме новую культуру
            foreach (Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name, newCultureInfo);
            }
            //Отдельно меняем для тайтла самой формы локализацию
            resources.ApplyResources(this, "$this", newCultureInfo);
            //Для элементов статус стрипа устанавливаем также установки локализации
            foreach (var item in SS.Items.Cast<ToolStripItem>())
            //.Where(Item => (Item is toolStripStatusLabel) != false))
            {
                resources.ApplyResources(item, item.Name, newCultureInfo);
            }
            //Устанавливаем текст на кнопке, которая была изображена на скриншоте раньше название локализации
            TSSD.Text = newCultureInfo.NativeName;

            //Устанавливаем флаг на активной локализации (см. функцию ниже)
            SetCurrenLanguageButtonChecked();
        }

        private void SetCurrenLanguageButtonChecked()
        {
            foreach (ToolStripMenuItem languageButton in TSSD.DropDownItems)
            {
                //Если надпись на нашем активном отображаемом языке в ToolStripDropDownButton-е,
                //который был установлен в актуальный перед вызовом функции совпадает с
                //надписью в ToolStripStatusLabel (всплывающие элементы выбора языка)
                //которые относятся к данному  ToolStripDropDownButton-у - отмечаем его Checked
                languageButton.Checked = (languageButton.Text == TSSD.Text);
            }
        }
        private void cordinat()
        {
            radioButton1.Checked = true;
            Lx = richTextBox1.Location.X;
            Ly = richTextBox1.Location.Y;
            Rw = richTextBox1.Width;
            Rh = richTextBox1.Height;

        }

        private void lan_def()
        {
            if (lan_ == 0)
            { switch (default_languare)
                {
                    case "uk-UA":
                        lan_ = 7;
                        break;
                    case "es-ES":
                        lan_ = 4;
                        break;
                    case "pl-PL":
                        lan_ = 6;
                        break;
                    case "ru-RU":
                        lan_ = 2;
                        break;
                    case "fr-FR":
                        lan_ = 3;
                        break;
                    case "de-DE":
                        lan_ = 5;
                        break;
                    case "en-US":
                        lan_ = 1;
                        break;
                    default:
                        lan_ = 1;
                        break;

                }
                ChangeLanguage(languare[lan_]);
                languare_click();
            }

        }

        private void languare_click()
        {
            tsmi_clear();
            toolStripStatusLabel1.Image = flag[lan_];
            TSMI_ES.Checked = true;
            this.Text = this.Text + " " + ver;
            cordinat();
        }
        

        private void setting()
        {

            Del_unness();

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            richTextBox2.Visible = false;
            richTextBox3.Visible = false;
            richTextBox4.Visible = false;

            flag[0] = Properties.Resources.def.ToBitmap();
            flag[1] = Properties.Resources.flag_of_United_States_of_America;
            flag[2] = Properties.Resources.flag_of_Russia;
            flag[3] = Properties.Resources.flag_of_France;
            flag[4] = Properties.Resources.flag_of_Spain;
            flag[5] = Properties.Resources.flag_of_Germany;
            flag[6] = Properties.Resources.flag_of_Poland;
            flag[7] = Properties.Resources.flag_of_Ukraine;


            textBox1.BackColor = Form1.DefaultBackColor;


            status[1, 0] = "Select the file where the secret is kept";
            status[2, 0] = "Выберите файл, где хранится секрет";
            status[3, 0] = "Sélectionnez le fichier où se cache le secret";
            status[4, 0] = "Seleccione el archivo donde se guarda el secreto";
            status[5, 0] = "Wählen Sie die Datei aus, in der das Geheimnis aufbewahrt wird";
            status[6, 0] = "Wybierz plik, w którym przechowywany jest sekret";
            status[7, 0] = "Виберіть файл, де зберігається секрет";

            status[1, 1] = "Select a file in which the secret will be kept";
            status[2, 1] = "Выберите файл, в котором будет храниться секрет";
            status[3, 1] = "Sélectionnez un fichier dans lequel le secret sera conservé";
            status[4, 1] = "Seleccione un archivo en el que se guardará el secreto";
            status[5, 1] = "Wählen Sie eine Datei aus, in der das Geheimnis aufbewahrt wird";
            status[6, 1] = "Wybierz plik, w którym będzie przechowywany tajemnica";
            status[7, 1] = "Виберіть файл, в якому буде зберігатись секрет";

            status[1, 2] = "Choose the name and location of the file where the secret is kept";
            status[2, 2] = "Выберите название и месторасположение файла, где хранится секрет";
            status[3, 2] = "Choisissez le nom et l'emplacement du fichier où le secret est conserv";
            status[4, 2] = "Elija el nombre y la ubicación del archivo donde se guarda el secreto";
            status[5, 2] = "Wählen Sie den Namen und den Ort der Datei, in der das Geheimnis aufbewahrt wird";
            status[6, 2] = "Wybierz nazwę i lokalizację pliku, w którym jest przechowywany tajemni";
            status[7, 2] = "Виберіть назву та місцерозташування файлу, де зберігається секрет";

            message[1, 0] = "";
            message[2, 0] = "";
            message[3, 0] = "";
            message[4, 0] = "";
            message[5, 0] = "";
            message[6, 0] = "";
            message[7, 0] = "Файл, де зберігається секрет, має бути більше - ";

            caption[1, 0] = "";
            caption[2, 0] = "";
            caption[3, 0] = "";
            caption[4, 0] = "";
            caption[5, 0] = "";
            caption[6, 0] = "";
            caption[7, 0] = "Невірний розмір файлу, де буде зберігатись секрет.";


            message[1, 1] = "";
            message[2, 1] = "";
            message[3, 1] = "";
            message[4, 1] = "";
            message[5, 1] = "";
            message[6, 1] = "";
            message[7, 1] = "Невірний розмір секрету в файлі: "; 

            caption[1, 1] = "";
            caption[2, 1] = "";
            caption[3, 1] = "";
            caption[4, 1] = "";
            caption[5, 1] = "";
            caption[6, 1] = "";
            caption[7, 1] = "Розмір файлу-секрету не повинен бути більше - ";

            rez[0] = "Результат операції < ";
            rez[1] = "The result of the operation < ";
            rez[2] = "Результат операции < ";
            rez[3] = "Le résultat de l'opération < ";
            rez[4] = "El resultado de la operación < ";
            rez[5] = "Das Ergebnis der Operation < ";
            rez[6] = "Wynik operacji < ";
            rez[7] = "Результат операції < ";

            //define name 
            //DateTime dt = DateTime.Now;
            //name_base = dt.ToString("hhmm");

            //{ Application.Exit(); }
        }

        private void work_rez()
        {
                    timer1.Enabled = true;
        }

                private string[] Select_file(int dialog,bool u)
                {
                    string ext;
                    OpenFileDialog verife = new OpenFileDialog(); //объект диалога выбора файлов
                    verife.Title = status[lan_, dialog];

            if (u)
            { verife.Filter = extension_true(extension); }
            else
                verife.Filter = "  (*.*)|*.*";
                                    //verife.Filter = " JPG (*.jpg)|*.jpg| BMP (*.bmp)|*.bmp | AVI (*.avi)|*.avi | MP4 (*.mp4)|*.mp4"; //Фильтр файлов
                                    DialogResult result = verife.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        ext = Path.GetExtension(verife.FileName);
                        return new string[] { verife.SafeFileName, verife.FileName };
                    }
                    else
                        return new string[] { null, null };
                }

                private string[] Save_file()
                {
                    SaveFileDialog osd = new SaveFileDialog();
                    osd.Title = status[lan_, 2];
                    ext[0] = file[0].Substring(file[0].Length - 3, 3);
                    osd.Filter = extension_true(ext);
                    osd.FileName = file[0].Substring(0, file[0].Length - 4);
                    //ex.ToUpper() + " (*." + ex.ToLower() + ")|" + "*." + ex;
                    DialogResult result = osd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        out_f = osd.FileName;
                        FileInfo fi = new FileInfo(osd.FileName);
                        file_out = fi.Name;
                        return new string[] { out_f, file_out };
                    }
                    else
                        return new string[] { null, null };
                }


                private string Do_7z(string arg)
                {
                    EXEStarter verife_test = new EXEStarter();
                    return verife_test.Start(_7zPath, args.ToString(), true); //запускаем 7z.exe

                }

                private void out_rez(bool yes, int r)
                {
                    switch (r)
                    {
                        case 1: {
                                if (yes)
                                { textBox1.Text = rez[lan_] + radioButton1.Text + ">: " + label8.Text + " " + file[1]; }
                                else
                                { textBox1.Text = rez[lan_] + radioButton1.Text + ">: " + label9.Text + " " + file[1]; }
                                break; }

                        case 2:
                            {
                                if (yes)
                                { textBox1.Text = rez[lan_] + radioButton2.Text + ">: " + label8.Text + " " + file[1]; }
                                else
                                { textBox1.Text = rez[lan_] + radioButton2.Text + ">: " + label9.Text + " " + file[1]; }
                                break; }
                        case 3: { break; }
                        case 4: { break; }

                    }



                }

                private string set_password(bool password)
                {
                    if (password)
                    { return Properties.Resources.password_begin + file[0].Substring(1) + Properties.Resources.password_end; }
                    else
                    { return Properties.Resources.password_begin + password_secret + Properties.Resources.password_end; }
                }



                private string extension_true(string[] ext_true)
                {
                    string ext_files = "";
                    foreach (string s in ext_true)
                    {
                        //verife.Filter = " JPG (*.jpg)|*.jpg| BMP (*.bmp)|*.bmp | AVI (*.avi)|*.avi | MP4 (*.mp4)|*.mp4"; //Фильтр файлов

                        ext_files = ext_files + (s.ToUpper() + " (*." + s.ToLower() + ")|" + "*." + s + "|");
                    }

                    return ext_files.Substring(0, ext_files.Length - 1);
                }

                private void copy_to_local()
                {
                    EXEStarter sfs = new EXEStarter();
                    if (sfs.exist_local(file[1], folder_d + file[0]))
                    { sfs.copy(file[1], @folder_d + file[0]); }
                }

                private float size_file(string out_file)
                {
                    if (File.Exists(out_file))
                    {
                        FileInfo file_size = new FileInfo(@out_file);

                        //size in Mb 
                        return ((float)file_size.Length / 1024 / 1024);

                    }
                    else
                    {
                        return -1;
                    }

                }

                private void text_rez(int vi)
                {
                    switch (vi)
                    {
                        case 0:
                            {
                                textBox1.Visible = true;
                                checkBox1.Visible = false;
                                return; }
                        case 1:
                            {
                                checkBox1.Visible = true;
                                textBox1.Visible = false;
                                return; }
                        default:
                            {
                                textBox1.Visible = false;
                                checkBox1.Visible = false;
                            } return; }

                }

            }

        }
    

