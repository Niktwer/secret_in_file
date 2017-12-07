using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Text.RegularExpressions;
using System.IO;

namespace secret_true_version
{
    public partial class Form_begin : Form
    {
        string ver, default_languare, def_l,user;
        string current_label;
        long current_place;
        Bitmap[] flag = new Bitmap[10];
        int lan_;
        string[] languare = new string[] { "", "en-US", "ru-RU", "fr-FR", "es-ES", "de-DE", "pl-PL", "uk-UA", "ja-JP", "zh-CN" };

           

        public Form_begin()
        {
            InitializeComponent();
            Settings();
            
        }

        private void Form_begin_Load(object sender, EventArgs e)
        {
            EXEStarter asm = new EXEStarter();
            ver = asm.assembly();
            //this.Text = Properties.Resources.zag_text + " " + ver;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            default_languare = CultureInfo.CurrentUICulture.Name;
            def_l = CultureInfo.CurrentUICulture.DisplayName;
            lan_def();


            //default_languare = CultureInfo.CurrentUICulture.Name;
            if ((textBox1_begin.Text).Length == 0)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

            string[] u_d = asm.Disk();
           
                
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 fg = new Form1(textBox1_begin.Text, languare[lan_]);

            
            textBox1_begin.Text = "";
            this.Hide();
            
            fg.ShowDialog();
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1_begin.Text).Length==0)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void TSMI_DE_Click(object sender, EventArgs e)
        {
            lan_ = 5;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void TSMI_EA_Click(object sender, EventArgs e)
        {
            lan_ = 1;
            ChangeLanguage(languare[lan_]);
            languare_click();

            
        }

        private void TSMI_RU_Click(object sender, EventArgs e)
        {
            lan_ = 2;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void TSMI_FR_Click(object sender, EventArgs e)
        {
            lan_ = 3;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void TSMI_ES_Click(object sender, EventArgs e)
        {
            lan_ = 4;
            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void TSMI_POL_Click(object sender, EventArgs e)
        {
            lan_ = 6;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void TSMI_UA_Click(object sender, EventArgs e)
        {
            lan_ = 7;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }


        private void Settings()
        {
            flag[0] = Properties.Resources.def.ToBitmap();
            flag[1] = Properties.Resources.flag_of_United_States_of_America;
            flag[2] = Properties.Resources.flag_of_Russia;
            flag[3] = Properties.Resources.flag_of_France;
            flag[4] = Properties.Resources.flag_of_Spain;
            flag[5] = Properties.Resources.flag_of_Germany;
            flag[6] = Properties.Resources.flag_of_Poland;
            flag[7] = Properties.Resources.flag_of_Ukraine;
            flag[8] = Properties.Resources.flag_of_Japan;
            flag[9] = Properties.Resources.flag_of_China;
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
            TSMI_JP.Checked = false;
            TSMI_CH.Checked = false;
            textBox1_begin.Text = "";

        }

        private void ChangeLanguage(string newLanguageString)
        {
            var resources = new ComponentResourceManager(typeof(Form_begin));
            CultureInfo newCultureInfo = new CultureInfo(newLanguageString);
            //Применяем для каждого контрола на форме новую культуру
            foreach (Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name, newCultureInfo);
            }
            //Отдельно меняем для тайтла самой формы локализацию
            resources.ApplyResources(this, "$this", newCultureInfo);
            //Для элементов статус стрипа устанавливаем также установки локализации
            foreach (var item in SS_begin.Items.Cast<ToolStripItem>())
            //.Where(Item => (Item is toolStripStatusLabel) != false))
            {
                resources.ApplyResources(item, item.Name, newCultureInfo);
            }
            //Устанавливаем текст на кнопке, которая была изображена на скриншоте раньше название локализации
            TSSD_begin.Text = newCultureInfo.NativeName;

            //Устанавливаем флаг на активной локализации (см. функцию ниже)
            SetCurrenLanguageButtonChecked();
        }

        private void SetCurrenLanguageButtonChecked()
        {
            foreach (ToolStripMenuItem languageButton in TSSD_begin.DropDownItems)
            {
                //Если надпись на нашем активном отображаемом языке в ToolStripDropDownButton-е,
                //который был установлен в актуальный перед вызовом функции совпадает с
                //надписью в ToolStripStatusLabel (всплывающие элементы выбора языка)
                //которые относятся к данному  ToolStripDropDownButton-у - отмечаем его Checked
                languageButton.Checked = (languageButton.Text == TSSD_begin.Text);
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TSMI_JP_Click(object sender, EventArgs e)
        {
            lan_ = 8;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void TSMI_CH_Click(object sender, EventArgs e)
        {
            lan_ = 9;

            ChangeLanguage(languare[lan_]);
            languare_click();
        }

        private void languare_click()
        {
            tsmi_clear();
            toolStripStatusLabel1_begin.Image = flag[lan_];
            
            this.Text = this.Text + " " + ver;
        }

        private void lan_def()
        {
            if (lan_ == 0)
            {
                switch (default_languare)
                {
                    case "ja-JP":
                        lan_ = 8;
                        break;
                    case "zn-CH":
                        lan_ = 9;
                        break;
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
                languare_click();
                ChangeLanguage(languare[lan_]);
               
            }

        }


    }
}
