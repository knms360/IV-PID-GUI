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
using System.Diagnostics;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.Http;
using System.Security.Policy;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            autosaveconfig();
        }

        //batimage
        string Title = "IV-PID-GUI";
        string batName = "IvPidlaunchtmp";
        string inputName = "IvPidsendcmd";
        string configName = "config";
        string targeteng = "iv-pid_modded_eng";
        string targetesp = "iv-pid_modded_esp";
        string targetjpn = "iv-pid_modded_jpn";
        string target = "";

        //other
        int openfileFilterIndex = 1;
        int loading = 1;

        //language
        int language = 0;

        string endofresults = "End of results.";
        string missingerror = " file is lost";
        string failederror = " file creation failed";
        string deleteerror = " file delete failed";
        string failedgene = "Failed to generate";
        string donemessage = "Done";
        string donebutnovalid = "Done. But No valid PID found.\nIt may be solved by increasing the amount to get data.";
        string novalid = "No valid PID found.";
        string unexpectederror = "An unexpected error occurred";
        string to = "~";
        string noexportdata = "No export data.";

        //string IVPID = "IV→PID";
        //string minIVHPPID = "Min IV+HP→PID";
        //string minIVIDSIDPID = "Min IV+ID+SID→★PID";
        //string minIVHPIDSIDshinyPID = "Min IV+ID+SID→★PID";
        //string IVIDSIDshinyPID = "IV+ID+SID→chained ★PID";
        //string PIDIV = "PID→IV";
        //string shinyPIDIDSID = "★PID+ID→SID";
        string IVPID = "IV --> PID";
        string minIVHPPID = "Minimum IV + HP --> PID";
        string minIVIDSIDPID = "Minimum IV + ID + SID --> shiny PID";
        string minIVHPIDSIDshinyPID = "Minimum IV + HP + ID + SID --> shiny PID";
        string IVIDSIDshinyPID = "IV + ID + SID --> chained shiny PID";
        string PIDIV = "PID --> IV";
        string shinyPIDIDSID = "Shiny PID + ID --> SID";
        string PIDIDSIDshinySID = "PID + ID + SID --> Shiny SID";

        string option = "Option";

        string number = "No.";
        string pid = "PID";
        string method = "Method";
        string ability = "Ability";
        string hp = "HP";
        string at = "Atk";
        string df = "Def";
        string spa = "SpA";
        string spd = "SpD";
        string spe = "Spe";
        string nature = "Nature";
        string gender = "Gender Value";
        string hidpow = "Hidden Power";
        string hpvalue = "HP Power";

        string abilityfirst = "First";
        string abilitysecond = "Second";

        string generate = "Generate";
        string hexpid = "Hex PID";
        string gbamethods = "Test GBA methods?";
        string evenrareone = "Even rare ones?\n(The author does not know\nwhether they are possible\r\nand GUI author too)\n";
        string attack = "Attack";
        string defense = "Defense";
        string specialA = "Special Attack";
        string specialD = "Special Defense";
        string speed = "Speed";
        string amount = "Amount to get data(higher is slower)";
        string random = "Random IV";
        string setalliv = "Set all IV";
        string setallde = "Set all =/<";

        string any = "any";
        string hardy = "Hardy";
        string lonely = "Lonely";
        string brave = "Brave";
        string adamant = "Adamant";
        string naughty = "Naughty";
        string bold = "Bold";
        string docile = "Docile";
        string relaxed = "Relaxed";
        string impish = "Impish";
        string lax = "Lax";
        string timid = "Timid";
        string hasty = "Hasty";
        string serious = "Serious";
        string jolly = "Jolly";
        string naive = "Naive";
        string modest = "Modest";
        string mild = "Mild";
        string quiet = "Quiet";
        string bashful = "Bashful";
        string rash = "Rash";
        string calm = "Calm";
        string gentle = "Gentle";
        string sassy = "Sassy";
        string careful = "Careful";
        string quirky = "Quirky";

        string fighting = "Fighting";
        string flying = "Flying";
        string poison = "Poison";
        string ground = "Ground";
        string rock = "Rock";
        string bug = "Bug";
        string ghost = "Ghost";
        string steel = "Steel";
        string fire = "Fire";
        string water = "Water";
        string grass = "Grass";
        string electric = "Electric";
        string psychic = "Psychic";
        string ice = "Ice";
        string dragon = "Dragon";
        string dark = "Dark";

        string hptype = "HP Type";
        string hppower = "Minimum HP Power";

        string shinypid = "Shiny PID";
        string sid = "SID";
        string shinysid = "Shiny SID";

        string trainerid = "Trainer ID";
        string secretid = "Secret ID";
        string hexinput = "Hex input?";

        string Export = "Export to CSV";

        string DisableDone = "Disable Done message";
        string DisableLoad = "Skip Config load(Reset Config)";
        string CollectNo = "No. in correct order";
        string languagelabel = "Language";

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 14;

            dataGridView1.Columns[0].HeaderText = number;
            dataGridView1.Columns[1].HeaderText = pid;
            dataGridView1.Columns[2].HeaderText = method;
            dataGridView1.Columns[3].HeaderText = gender;
            dataGridView1.Columns[4].HeaderText = nature;
            dataGridView1.Columns[5].HeaderText = ability;
            dataGridView1.Columns[6].HeaderText = hp;
            dataGridView1.Columns[7].HeaderText = at;
            dataGridView1.Columns[8].HeaderText = df;
            dataGridView1.Columns[9].HeaderText = spa;
            dataGridView1.Columns[10].HeaderText = spd;
            dataGridView1.Columns[11].HeaderText = spe;
            dataGridView1.Columns[12].HeaderText = hidpow;
            dataGridView1.Columns[13].HeaderText = hpvalue;
            dataGridView1.Columns[0].Width = 25;
            dataGridView1.Columns[1].Width = 67;
            dataGridView1.Columns[2].Width = 57;
            dataGridView1.Columns[3].Width = 45;
            dataGridView1.Columns[4].Width = 54;
            dataGridView1.Columns[5].Width = 45;
            dataGridView1.Columns[6].Width = 29;
            dataGridView1.Columns[7].Width = 29;
            dataGridView1.Columns[8].Width = 29;
            dataGridView1.Columns[9].Width = 29;
            dataGridView1.Columns[10].Width = 29;
            dataGridView1.Columns[11].Width = 29;
            dataGridView1.Columns[12].Width = 70;
            dataGridView1.Columns[13].Width = 40;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;
            comboBox8.Enabled = false;
            button3.Enabled = false;
            comboBox10.Enabled = false;
            comboBox10.SelectedIndex = 0;
            comboBox1.Items.Add(any);
            comboBox1.Items.Add(abilityfirst);
            comboBox1.Items.Add(abilitysecond);
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add(any);
            comboBox2.Items.Add(hardy);
            comboBox2.Items.Add(lonely);
            comboBox2.Items.Add(brave);
            comboBox2.Items.Add(adamant);
            comboBox2.Items.Add(naughty);
            comboBox2.Items.Add(bold);
            comboBox2.Items.Add(docile);
            comboBox2.Items.Add(relaxed);
            comboBox2.Items.Add(impish);
            comboBox2.Items.Add(lax);
            comboBox2.Items.Add(timid);
            comboBox2.Items.Add(hasty);
            comboBox2.Items.Add(serious);
            comboBox2.Items.Add(jolly);
            comboBox2.Items.Add(naive);
            comboBox2.Items.Add(modest);
            comboBox2.Items.Add(mild);
            comboBox2.Items.Add(quiet);
            comboBox2.Items.Add(bashful);
            comboBox2.Items.Add(rash);
            comboBox2.Items.Add(calm);
            comboBox2.Items.Add(gentle);
            comboBox2.Items.Add(sassy);
            comboBox2.Items.Add(careful);
            comboBox2.Items.Add(quirky);
            comboBox2.SelectedIndex = 0;
            comboBox9.Items.Add(any);
            comboBox9.Items.Add(fighting);
            comboBox9.Items.Add(flying);
            comboBox9.Items.Add(poison);
            comboBox9.Items.Add(ground);
            comboBox9.Items.Add(rock);
            comboBox9.Items.Add(bug);
            comboBox9.Items.Add(ghost);
            comboBox9.Items.Add(steel);
            comboBox9.Items.Add(fire);
            comboBox9.Items.Add(water);
            comboBox9.Items.Add(grass);
            comboBox9.Items.Add(electric);
            comboBox9.Items.Add(psychic);
            comboBox9.Items.Add(ice);
            comboBox9.Items.Add(dragon);
            comboBox9.Items.Add(dark);
            comboBox9.SelectedIndex = 0;
            checkBox1.Text = hexpid;
            checkBox2.Text = gbamethods;
            checkBox3.Text = evenrareone;
            label1.Text = hp;
            label2.Text = attack;
            label3.Text = defense;
            label4.Text = specialA;
            label5.Text = specialD;
            label6.Text = speed;
            label7.Text = amount;
            label8.Text = ability;
            label9.Text = nature;
            checkBox4.Checked = true;
            panel5.Location = new Point(571, 57);
            panel1.Location = new Point(22, 59);
            panel2.Location = new Point(571, 122);
            panel3.Location = new Point(254, 59);
            panel4.Location = new Point(409, 59);
            panel3.Visible = false;
            panel4.Visible = false;
            Size = new Size(816, 556);
            tabPage1.Text = IVPID;
            tabPage2.Text = minIVHPPID;
            tabPage3.Text = minIVIDSIDPID;
            tabPage4.Text = minIVHPIDSIDshinyPID;
            tabPage5.Text = IVIDSIDshinyPID;
            tabPage6.Text = PIDIV;
            tabPage7.Text = shinyPIDIDSID;
            tabPage8.Text = option;
            button1.Text = random;
            button2.Text = setalliv;
            button3.Text = setallde;
            gene.Text = generate;
            checkBox4.Text = any;
            label11.Text = hptype;
            label12.Text = hppower;
            label10.Text = "";
            label15.Text = pid;
            label16.Text = shinypid;
            label29.Text = pid;
            gene2.Text = generate;
            label17.Text = sid;
            label30.Text = shinysid;
            label13.Text = trainerid;
            label14.Text = secretid;
            gene3.Text = generate;
            checkBox5.Text = hexinput;
            checkBox6.Text = hexinput;
            checkBox11.Text = hexinput;
            button4.Text = Export;
            checkBox7.Text = DisableDone;
            checkBox8.Text = DisableLoad;
            checkBox9.Text = CollectNo;
            label22.Text = languagelabel;
            textBox8.Text = inputName;
            textBox7.Text = batName;
            textBox9.Text = targeteng;
            textBox10.Text = targetesp;
            textBox11.Text = targetjpn;
            if (File.Exists(configName + ".txt"))
            {
                StreamReader load = new StreamReader(configName + ".txt", Encoding.GetEncoding("Shift_JIS"));

                string disablechecker = load.ReadLine();
                checkBox8.Checked = Convert.ToBoolean(disablechecker);
                if (disablechecker == "False")
                {
                    numericUpDown1.Value = Convert.ToInt32(load.ReadLine());
                    numericUpDown2.Value = Convert.ToInt32(load.ReadLine());
                    numericUpDown3.Value = Convert.ToInt32(load.ReadLine());
                    numericUpDown4.Value = Convert.ToInt32(load.ReadLine());
                    numericUpDown5.Value = Convert.ToInt32(load.ReadLine());
                    numericUpDown6.Value = Convert.ToInt32(load.ReadLine());
                    comboBox3.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    comboBox4.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    comboBox5.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    comboBox6.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    comboBox7.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    comboBox8.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    numericUpDown7.Value = Convert.ToInt32(load.ReadLine());
                    comboBox10.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    comboBox2.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    comboBox1.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    comboBox9.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    textBox1.Text = load.ReadLine();
                    checkBox4.Checked = Convert.ToBoolean(load.ReadLine());
                    textBox2.Text = load.ReadLine();
                    textBox3.Text = load.ReadLine();
                    textBox4.Text = load.ReadLine();
                    textBox5.Text = load.ReadLine();
                    textBox12.Text = load.ReadLine();
                    checkBox5.Checked = Convert.ToBoolean(load.ReadLine());
                    checkBox6.Checked = Convert.ToBoolean(load.ReadLine());
                    checkBox11.Checked = Convert.ToBoolean(load.ReadLine());
                    checkBox2.Checked = Convert.ToBoolean(load.ReadLine());
                    checkBox3.Checked = Convert.ToBoolean(load.ReadLine());
                    checkBox1.Checked = Convert.ToBoolean(load.ReadLine());
                    numericUpDown8.Value = Convert.ToInt32(load.ReadLine());
                    tabControl1.SelectedIndex = Convert.ToInt32(load.ReadLine());
                    language = Convert.ToInt32(load.ReadLine());
                    openfileFilterIndex = Convert.ToInt32(load.ReadLine());
                    batName = load.ReadLine();
                    inputName = load.ReadLine();
                    targeteng = load.ReadLine();
                    targetesp = load.ReadLine();
                    targetjpn = load.ReadLine();
                    checkBox7.Checked = Convert.ToBoolean(load.ReadLine());
                    checkBox9.Checked = Convert.ToBoolean(load.ReadLine());
                    int width = Convert.ToInt32(load.ReadLine());
                    int height = Convert.ToInt32(load.ReadLine());
                    Size = new Size(width, height);
                    dataGridView1.Columns[0].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[1].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[2].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[3].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[4].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[5].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[6].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[7].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[8].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[9].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[10].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[11].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[12].Width = Convert.ToInt32(load.ReadLine());
                    dataGridView1.Columns[13].Width = Convert.ToInt32(load.ReadLine());
                }
                load.Close();
            }
            if (language == 0)
            {
                languageeng();
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
            else if (language == 1)
            {
                languageesp();
                radioButton1.Checked = false;
                radioButton2.Checked = true;
                radioButton3.Checked = false;
            }
            else if (language == 2)
            {
                languagejpn();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = true;
            }
            refreshform();
            loading = 0;
        }

        private void autosaveconfig()
        {
            StreamWriter output = new System.IO.StreamWriter(configName + ".txt", false, System.Text.Encoding.GetEncoding("shift_jis"));
            output.WriteLine(checkBox8.Checked);
            output.WriteLine(numericUpDown1.Value);
            output.WriteLine(numericUpDown2.Value);
            output.WriteLine(numericUpDown3.Value);
            output.WriteLine(numericUpDown4.Value);
            output.WriteLine(numericUpDown5.Value);
            output.WriteLine(numericUpDown6.Value);
            output.WriteLine(comboBox3.SelectedIndex);
            output.WriteLine(comboBox4.SelectedIndex);
            output.WriteLine(comboBox5.SelectedIndex);
            output.WriteLine(comboBox6.SelectedIndex);
            output.WriteLine(comboBox7.SelectedIndex);
            output.WriteLine(comboBox8.SelectedIndex);
            output.WriteLine(numericUpDown7.Value);
            output.WriteLine(comboBox10.SelectedIndex);
            output.WriteLine(comboBox2.SelectedIndex);
            output.WriteLine(comboBox1.SelectedIndex);
            output.WriteLine(comboBox9.SelectedIndex);
            output.WriteLine(textBox1.Text);
            output.WriteLine(checkBox4.Checked);
            output.WriteLine(textBox2.Text);
            output.WriteLine(textBox3.Text);
            output.WriteLine(textBox4.Text);
            output.WriteLine(textBox5.Text);
            output.WriteLine(textBox12.Text);
            output.WriteLine(checkBox5.Checked);
            output.WriteLine(checkBox6.Checked);
            output.WriteLine(checkBox11.Checked);
            output.WriteLine(checkBox2.Checked);
            output.WriteLine(checkBox3.Checked);
            output.WriteLine(checkBox1.Checked);
            output.WriteLine(numericUpDown8.Value);
            output.WriteLine(tabControl1.SelectedIndex);
            output.WriteLine(language);
            output.WriteLine(openfileFilterIndex);
            output.WriteLine(batName);
            output.WriteLine(inputName);
            output.WriteLine(targeteng);
            output.WriteLine(targetesp);
            output.WriteLine(targetjpn);
            output.WriteLine(checkBox7.Checked);
            output.WriteLine(checkBox9.Checked);
            output.WriteLine(Size.Width);
            output.WriteLine(Size.Height);
            output.WriteLine(dataGridView1.Columns[0].Width);
            output.WriteLine(dataGridView1.Columns[1].Width);
            output.WriteLine(dataGridView1.Columns[2].Width);
            output.WriteLine(dataGridView1.Columns[3].Width);
            output.WriteLine(dataGridView1.Columns[4].Width);
            output.WriteLine(dataGridView1.Columns[5].Width);
            output.WriteLine(dataGridView1.Columns[6].Width);
            output.WriteLine(dataGridView1.Columns[7].Width);
            output.WriteLine(dataGridView1.Columns[8].Width);
            output.WriteLine(dataGridView1.Columns[9].Width);
            output.WriteLine(dataGridView1.Columns[10].Width);
            output.WriteLine(dataGridView1.Columns[11].Width);
            output.WriteLine(dataGridView1.Columns[12].Width);
            output.WriteLine(dataGridView1.Columns[13].Width);

            output.Close();
        }

        private void refreshform()
        {
            int temp2 = comboBox2.SelectedIndex;
            int temp1 = comboBox1.SelectedIndex;
            int temp9 = comboBox9.SelectedIndex;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox9.Items.Clear();
            dataGridView1.ColumnCount = 14;

            dataGridView1.Columns[0].HeaderText = number;
            dataGridView1.Columns[1].HeaderText = pid;
            dataGridView1.Columns[2].HeaderText = method;
            dataGridView1.Columns[3].HeaderText = gender;
            dataGridView1.Columns[4].HeaderText = nature;
            dataGridView1.Columns[5].HeaderText = ability;
            dataGridView1.Columns[6].HeaderText = hp;
            dataGridView1.Columns[7].HeaderText = at;
            dataGridView1.Columns[8].HeaderText = df;
            dataGridView1.Columns[9].HeaderText = spa;
            dataGridView1.Columns[10].HeaderText = spd;
            dataGridView1.Columns[11].HeaderText = spe;
            dataGridView1.Columns[12].HeaderText = hidpow;
            dataGridView1.Columns[13].HeaderText = hpvalue;
            comboBox1.Items.Add(any);
            comboBox1.Items.Add(abilityfirst);
            comboBox1.Items.Add(abilitysecond);
            comboBox1.SelectedIndex = temp1;
            comboBox2.Items.Add(any);
            comboBox2.Items.Add(hardy);
            comboBox2.Items.Add(lonely);
            comboBox2.Items.Add(brave);
            comboBox2.Items.Add(adamant);
            comboBox2.Items.Add(naughty);
            comboBox2.Items.Add(bold);
            comboBox2.Items.Add(docile);
            comboBox2.Items.Add(relaxed);
            comboBox2.Items.Add(impish);
            comboBox2.Items.Add(lax);
            comboBox2.Items.Add(timid);
            comboBox2.Items.Add(hasty);
            comboBox2.Items.Add(serious);
            comboBox2.Items.Add(jolly);
            comboBox2.Items.Add(naive);
            comboBox2.Items.Add(modest);
            comboBox2.Items.Add(mild);
            comboBox2.Items.Add(quiet);
            comboBox2.Items.Add(bashful);
            comboBox2.Items.Add(rash);
            comboBox2.Items.Add(calm);
            comboBox2.Items.Add(gentle);
            comboBox2.Items.Add(sassy);
            comboBox2.Items.Add(careful);
            comboBox2.Items.Add(quirky);
            comboBox2.SelectedIndex = temp2;
            comboBox9.Items.Add(any);
            comboBox9.Items.Add(fighting);
            comboBox9.Items.Add(flying);
            comboBox9.Items.Add(poison);
            comboBox9.Items.Add(ground);
            comboBox9.Items.Add(rock);
            comboBox9.Items.Add(bug);
            comboBox9.Items.Add(ghost);
            comboBox9.Items.Add(steel);
            comboBox9.Items.Add(fire);
            comboBox9.Items.Add(water);
            comboBox9.Items.Add(grass);
            comboBox9.Items.Add(electric);
            comboBox9.Items.Add(psychic);
            comboBox9.Items.Add(ice);
            comboBox9.Items.Add(dragon);
            comboBox9.Items.Add(dark);
            comboBox9.SelectedIndex = temp9;
            checkBox1.Text = hexpid;
            checkBox2.Text = gbamethods;
            checkBox3.Text = evenrareone;
            label1.Text = hp;
            label2.Text = attack;
            label3.Text = defense;
            label4.Text = specialA;
            label5.Text = specialD;
            label6.Text = speed;
            label7.Text = amount;
            label8.Text = ability;
            label9.Text = nature;
            tabPage1.Text = IVPID;
            tabPage2.Text = minIVHPPID;
            tabPage3.Text = minIVIDSIDPID;
            tabPage4.Text = minIVHPIDSIDshinyPID;
            tabPage5.Text = IVIDSIDshinyPID;
            tabPage6.Text = PIDIV;
            tabPage7.Text = shinyPIDIDSID;
            tabPage9.Text = PIDIDSIDshinySID;
            tabPage8.Text = option;
            button1.Text = random;
            button2.Text = setalliv;
            button3.Text = setallde;
            gene.Text = generate;
            checkBox4.Text = any;
            label11.Text = hptype;
            label12.Text = hppower;
            label10.Text = "";
            label15.Text = pid;
            label16.Text = shinypid;
            label29.Text = pid;
            gene2.Text = generate;
            label17.Text = sid;
            label30.Text = shinysid;
            label13.Text = trainerid;
            label14.Text = secretid;
            gene3.Text = generate;
            checkBox5.Text = hexinput;
            checkBox6.Text = hexinput;
            checkBox11.Text = hexinput;
            button4.Text = Export;
            checkBox7.Text = DisableDone;
            checkBox8.Text = DisableLoad;
            checkBox9.Text = CollectNo;
            label22.Text = languagelabel;
            textBox8.Text = inputName;
            textBox7.Text = batName;
            textBox9.Text = targeteng;
            textBox10.Text = targetesp;
            textBox11.Text = targetjpn;
        }

        private void loadconfig()
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = false;
                panel4.Visible = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                button3.Enabled = false;
                comboBox10.Enabled = false;
                textBox3.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = false;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;
                comboBox8.Enabled = true;
                button3.Enabled = true;
                comboBox10.Enabled = true;
                textBox3.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = false;
                panel4.Visible = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;
                comboBox8.Enabled = true;
                button3.Enabled = true;
                comboBox10.Enabled = true;
                textBox3.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;
                comboBox8.Enabled = true;
                button3.Enabled = true;
                comboBox10.Enabled = true;
                textBox3.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = false;
                panel4.Visible = true;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                button3.Enabled = false;
                comboBox10.Enabled = false;
                textBox3.Enabled = true;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
                panel4.Visible = false;
                panel4.Visible = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                button3.Enabled = false;
                comboBox10.Enabled = false;
                textBox3.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = true;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                button3.Enabled = false;
                comboBox10.Enabled = false;
                textBox3.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
            }
            else if (tabControl1.SelectedIndex == 7)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = true;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                button3.Enabled = false;
                comboBox10.Enabled = false;
                textBox3.Enabled = true;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
            }
            else if (tabControl1.SelectedIndex == 8)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                button3.Enabled = false;
                comboBox10.Enabled = false;
                textBox3.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
            if (checkBox2.Checked == true)
            {
                if (checkBox2.Enabled == false)
                {
                    checkBox3.Enabled = false;
                }
                else
                {
                    checkBox3.Enabled = true;
                }
            }
            else
            {
                checkBox3.Enabled = false;
            }
        }

        private void gene_Click(object sender, EventArgs e)
        {
            autosaveconfig();
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "00000";
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "00000";
            }
            if (textBox4.Text == "")
            {
                if (checkBox5.Checked == true)
                {
                    textBox4.Text = "00000000";
                }
                else
                {
                    textBox4.Text = "0";
                }
            }
            if (textBox5.Text == "")
            {
                if (checkBox6.Checked == true)
                {
                    textBox5.Text = "00000000";
                }
                else
                {
                    textBox5.Text = "0";
                }
            }
            if (textBox12.Text == "")
            {
                if (checkBox11.Checked == true)
                {
                    textBox12.Text = "00000000";
                }
                else
                {
                    textBox12.Text = "0";
                }
            }
            label10.Text = "";
            int Error = 0;
            string batfileName = batName + @".bat";
            string inputfileName = inputName + @".txt";
            dataGridView1.Rows.Clear();

            int number = 0;
            long pid = 0;
            string method = "";
            string ability = "";
            int hp = 0;
            int at = 0;
            int df = 0;
            int spa = 0;
            int spd = 0;
            int spe = 0;
            string nature = "";
            int gender = 0;
            string hidpow = "";
            int hpvalue = 0;

            StreamWriter input = new System.IO.StreamWriter(batfileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
            input.WriteLine("@echo off");
            input.WriteLine("title " + batName);
            input.WriteLine(target + " < " + inputfileName);
            input.Close();
            if (!File.Exists(batfileName))
            {
                MessageBox.Show(batName + failederror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error = 1;
            }

            if (tabControl1.SelectedIndex == 0)
            {

                StreamWriter inputdata = new System.IO.StreamWriter(inputfileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
                inputdata.WriteLine("1");
                inputdata.WriteLine((int)numericUpDown1.Value);
                inputdata.WriteLine((int)numericUpDown2.Value);
                inputdata.WriteLine((int)numericUpDown3.Value);
                inputdata.WriteLine((int)numericUpDown4.Value);
                inputdata.WriteLine((int)numericUpDown5.Value);
                inputdata.WriteLine((int)numericUpDown6.Value);
                inputdata.WriteLine(comboBox2.SelectedIndex - 1);
                if (comboBox1.SelectedIndex == 0)
                {
                    inputdata.WriteLine("n");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    inputdata.WriteLine("1");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    inputdata.WriteLine("2");
                }
                if (checkBox2.Checked == true)
                {
                    inputdata.WriteLine("y");
                    if (checkBox3.Checked == true)
                    {
                        inputdata.WriteLine("y");
                    }
                    else
                    {
                        inputdata.WriteLine("n");
                    }
                }
                else
                {
                    inputdata.WriteLine("n");
                }
                for (int i = 2; i <= numericUpDown8.Value / 3; i++)
                {
                    inputdata.WriteLine("-");
                }
                inputdata.WriteLine("0");
                inputdata.Close();
                if (!File.Exists(inputfileName))
                {
                    MessageBox.Show(inputName + failederror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                System.Diagnostics.Process gene = new System.Diagnostics.Process();
                //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
                gene.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
                //出力を読み取れるようにする
                gene.StartInfo.UseShellExecute = false;
                gene.StartInfo.RedirectStandardOutput = true;
                gene.StartInfo.RedirectStandardInput = false;

                gene.StartInfo.RedirectStandardError = true;
                //OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
                //ウィンドウを表示しないようにする
                //gene.StartInfo.CreateNoWindow = true;
                //コマンドラインを指定（"/c"は実行後閉じるために必要）
                gene.StartInfo.Arguments = @"/c " + batfileName;
                //起動
                gene.Start();
                //出力を読み取る
                string results = gene.StandardOutput.ReadToEnd();
                string cserror = gene.StandardError.ReadToEnd();
                //プロセス終了まで待機する
                //WaitForExitはReadToEndの後である必要がある
                //(親プロセス、子プロセスでブロック防止のため)
                gene.WaitForExit();
                gene.Close();
                //出力された結果を表示
                Debug.WriteLine(results);
                Debug.WriteLine(cserror);

                if (File.Exists(batfileName))
                {
                    FileInfo batDel = new FileInfo(batfileName);
                    // ファイルを削除する
                    batDel.Delete();
                    if (File.Exists(batfileName))
                    {
                        MessageBox.Show(batName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(batName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                if (File.Exists(inputfileName))
                {
                    FileInfo inputDel = new FileInfo(inputfileName);
                    // ファイルを削除する
                    inputDel.Delete();
                    if (File.Exists(inputfileName))
                    {
                        MessageBox.Show(inputName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(inputName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
                if (cserror == "")
                {
                    if (results != "")
                    {
                        //TextBox1に入力されている文字列から一行ずつ読み込む
                        //文字列(TextBox1に入力された文字列)からStringReaderインスタンスを作成
                        StringReader rs = new StringReader(results);
                        //ストリームの末端まで繰り返す
                        while (rs.Peek() > -1)
                        {
                            //一行読み込んで表示する
                            string blankcheck = rs.ReadLine();
                            if (blankcheck != "")
                            {
                                if (blankcheck == "End of results. ")
                                {
                                    label10.Text = endofresults;
                                }
                                else if (blankcheck == "No valid PID found. ")
                                {
                                    MessageBox.Show(novalid, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    label10.Text = novalid;
                                    Error = 1;
                                }
                                else if (Regex.IsMatch(blankcheck, @"^[0-9]+$"))
                                {
                                    number = int.Parse(blankcheck);
                                    pid = long.Parse(rs.ReadLine());
                                    method = rs.ReadLine();
                                    ability = rs.ReadLine();
                                    hp = int.Parse(rs.ReadLine());
                                    at = int.Parse(rs.ReadLine());
                                    df = int.Parse(rs.ReadLine());
                                    spa = int.Parse(rs.ReadLine());
                                    spd = int.Parse(rs.ReadLine());
                                    spe = int.Parse(rs.ReadLine());
                                    nature = rs.ReadLine();
                                    gender = int.Parse(rs.ReadLine());
                                    hidpow = rs.ReadLine();
                                    hpvalue = int.Parse(rs.ReadLine());
                                    if (checkBox1.Checked == true)
                                    {
                                        dataGridView1.Rows.Add(number, Convert.ToString(pid, 16).ToUpper(), method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                    }
                                    else
                                    {
                                        dataGridView1.Rows.Add(number, pid, method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(unexpectederror + "\n" + results, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Error = 1;
                                    break;
                                }
                            }
                        }
                        rs.Close();
                    }
                    else
                    {
                        MessageBox.Show(failedgene, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(unexpectederror + "\n" + cserror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                StreamWriter inputdata = new System.IO.StreamWriter(inputfileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
                inputdata.WriteLine("2");
                inputdata.WriteLine((int)numericUpDown1.Value);
                inputdata.WriteLine((int)numericUpDown2.Value);
                inputdata.WriteLine((int)numericUpDown3.Value);
                inputdata.WriteLine((int)numericUpDown4.Value);
                inputdata.WriteLine((int)numericUpDown5.Value);
                inputdata.WriteLine((int)numericUpDown6.Value);
                inputdata.WriteLine(comboBox2.SelectedIndex - 1);
                if (comboBox1.SelectedIndex == 0)
                {
                    inputdata.WriteLine("n");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    inputdata.WriteLine("1");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    inputdata.WriteLine("2");
                }
                if (checkBox2.Checked == true)
                {
                    inputdata.WriteLine("y");
                    if (checkBox3.Checked == true)
                    {
                        inputdata.WriteLine("y");
                    }
                    else
                    {
                        inputdata.WriteLine("n");
                    }
                }
                else
                {
                    inputdata.WriteLine("n");
                }
                inputdata.WriteLine(comboBox9.SelectedIndex - 1);
                if (checkBox4.Checked == true)
                {
                    inputdata.WriteLine("-1");
                }
                else
                {
                    inputdata.WriteLine(textBox1.Text);
                }
                for (int i = 2; i <= numericUpDown8.Value / 3; i++)
                {
                    inputdata.WriteLine("-");
                }
                inputdata.WriteLine("0");
                inputdata.Close();
                if (!File.Exists(inputfileName))
                {
                    MessageBox.Show(inputName + failederror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                System.Diagnostics.Process gene = new System.Diagnostics.Process();
                //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
                gene.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
                //出力を読み取れるようにする
                gene.StartInfo.UseShellExecute = false;
                gene.StartInfo.RedirectStandardOutput = true;
                gene.StartInfo.RedirectStandardInput = false;

                gene.StartInfo.RedirectStandardError = true;
                //OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
                //ウィンドウを表示しないようにする
                //gene.StartInfo.CreateNoWindow = true;
                //コマンドラインを指定（"/c"は実行後閉じるために必要）
                gene.StartInfo.Arguments = @"/c " + batfileName;
                //起動
                gene.Start();
                //出力を読み取る
                string results = gene.StandardOutput.ReadToEnd();
                string cserror = gene.StandardError.ReadToEnd();
                //プロセス終了まで待機する
                //WaitForExitはReadToEndの後である必要がある
                //(親プロセス、子プロセスでブロック防止のため)
                gene.WaitForExit();
                gene.Close();
                //出力された結果を表示
                Debug.WriteLine(results);
                Debug.WriteLine(cserror);

                if (File.Exists(batfileName))
                {
                    FileInfo batDel = new FileInfo(batfileName);
                    // ファイルを削除する
                    batDel.Delete();
                    if (File.Exists(batfileName))
                    {
                        MessageBox.Show(batName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(batName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                if (File.Exists(inputfileName))
                {
                    FileInfo inputDel = new FileInfo(inputfileName);
                    // ファイルを削除する
                    inputDel.Delete();
                    if (File.Exists(inputfileName))
                    {
                        MessageBox.Show(inputName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(inputName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
                //use results
                if (cserror == "")
                {
                    if (results != "")
                    {
                        //TextBox1に入力されている文字列から一行ずつ読み込む
                        //文字列(TextBox1に入力された文字列)からStringReaderインスタンスを作成
                        StringReader rs = new StringReader(results);
                        //ストリームの末端まで繰り返す
                        while (rs.Peek() > -1)
                        {
                            //一行読み込んで表示する
                            string blankcheck = rs.ReadLine();
                            if (blankcheck != "")
                            {
                                if (blankcheck == "End of results. ")
                                {
                                    label10.Text = endofresults;
                                }
                                else if (blankcheck == "No valid PID found. ")
                                {
                                    MessageBox.Show(novalid, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    label10.Text = novalid;
                                    Error = 1;
                                }
                                else if (Regex.IsMatch(blankcheck, @"^[0-9]+$"))
                                {
                                    number = int.Parse(blankcheck);
                                    pid = long.Parse(rs.ReadLine());
                                    method = rs.ReadLine();
                                    ability = rs.ReadLine();
                                    hp = int.Parse(rs.ReadLine());
                                    at = int.Parse(rs.ReadLine());
                                    df = int.Parse(rs.ReadLine());
                                    spa = int.Parse(rs.ReadLine());
                                    spd = int.Parse(rs.ReadLine());
                                    spe = int.Parse(rs.ReadLine());
                                    nature = rs.ReadLine();
                                    gender = int.Parse(rs.ReadLine());
                                    hidpow = rs.ReadLine();
                                    hpvalue = int.Parse(rs.ReadLine());

                                    int ifnotequal = 0;
                                    if (comboBox3.SelectedIndex == 0)
                                    {
                                        if (numericUpDown1.Value != hp)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox4.SelectedIndex == 0)
                                    {
                                        if (numericUpDown2.Value != at)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox5.SelectedIndex == 0)
                                    {
                                        if (numericUpDown3.Value != df)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox6.SelectedIndex == 0)
                                    {
                                        if (numericUpDown4.Value != spa)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox7.SelectedIndex == 0)
                                    {
                                        if (numericUpDown5.Value != spd)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox8.SelectedIndex == 0)
                                    {
                                        if (numericUpDown6.Value != spe)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (ifnotequal != 1)
                                    {
                                        if (checkBox1.Checked == true)
                                        {
                                            dataGridView1.Rows.Add(number, Convert.ToString(pid, 16).ToUpper(), method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                        }
                                        else
                                        {
                                            dataGridView1.Rows.Add(number, pid, method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                        }
                                    }
                                }
                                else
                                {
                                    int num = 0;
                                    string dot = "";
                                    string[] spliter = results.Split('\n');
                                    if (spliter.Length <= 5)
                                    {
                                        num = spliter.Length;
                                        dot = "";
                                    }
                                    else
                                    {
                                        num = 5;
                                        dot = "...";
                                    }
                                    string[] getmessage = new string[num];
                                    Array.Copy(spliter, 0, getmessage, 0, num);
                                    MessageBox.Show(unexpectederror + "\n" + string.Join("\n", getmessage) + dot, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Error = 1;
                                    break;
                                }
                            }
                        }
                        rs.Close();
                    }
                    else
                    {
                        MessageBox.Show(failedgene, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(unexpectederror + "\n" + cserror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                StreamWriter inputdata = new System.IO.StreamWriter(inputfileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
                inputdata.WriteLine("3");
                inputdata.WriteLine((int)numericUpDown1.Value);
                inputdata.WriteLine((int)numericUpDown2.Value);
                inputdata.WriteLine((int)numericUpDown3.Value);
                inputdata.WriteLine((int)numericUpDown4.Value);
                inputdata.WriteLine((int)numericUpDown5.Value);
                inputdata.WriteLine((int)numericUpDown6.Value);
                inputdata.WriteLine(comboBox2.SelectedIndex - 1);
                if (comboBox1.SelectedIndex == 0)
                {
                    inputdata.WriteLine("n");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    inputdata.WriteLine("1");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    inputdata.WriteLine("2");
                }
                if (checkBox2.Checked == true)
                {
                    inputdata.WriteLine("y");
                    if (checkBox3.Checked == true)
                    {
                        inputdata.WriteLine("y");
                    }
                    else
                    {
                        inputdata.WriteLine("n");
                    }
                }
                else
                {
                    inputdata.WriteLine("n");
                }
                inputdata.WriteLine(textBox2.Text);
                inputdata.WriteLine(textBox3.Text);
                for (int i = 2; i <= numericUpDown8.Value / 3; i++)
                {
                    inputdata.WriteLine("-");
                }
                inputdata.WriteLine("0");
                inputdata.Close();
                if (!File.Exists(inputfileName))
                {
                    MessageBox.Show(inputName + failederror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                System.Diagnostics.Process gene = new System.Diagnostics.Process();
                //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
                gene.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
                //出力を読み取れるようにする
                gene.StartInfo.UseShellExecute = false;
                gene.StartInfo.RedirectStandardOutput = true;
                gene.StartInfo.RedirectStandardInput = false;

                gene.StartInfo.RedirectStandardError = true;
                //OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
                //ウィンドウを表示しないようにする
                //gene.StartInfo.CreateNoWindow = true;
                //コマンドラインを指定（"/c"は実行後閉じるために必要）
                gene.StartInfo.Arguments = @"/c " + batfileName;
                //起動
                gene.Start();
                //出力を読み取る
                string results = gene.StandardOutput.ReadToEnd();
                string cserror = gene.StandardError.ReadToEnd();
                //プロセス終了まで待機する
                //WaitForExitはReadToEndの後である必要がある
                //(親プロセス、子プロセスでブロック防止のため)
                gene.WaitForExit();
                gene.Close();
                //出力された結果を表示
                Debug.WriteLine(results);
                Debug.WriteLine(cserror);

                if (File.Exists(batfileName))
                {
                    FileInfo batDel = new FileInfo(batfileName);
                    // ファイルを削除する
                    batDel.Delete();
                    if (File.Exists(batfileName))
                    {
                        MessageBox.Show(batName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(batName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                if (File.Exists(inputfileName))
                {
                    FileInfo inputDel = new FileInfo(inputfileName);
                    // ファイルを削除する
                    inputDel.Delete();
                    if (File.Exists(inputfileName))
                    {
                        MessageBox.Show(inputName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(inputName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
                //use results
                if (cserror == "")
                {
                    if (results != "")
                    {
                        //TextBox1に入力されている文字列から一行ずつ読み込む
                        //文字列(TextBox1に入力された文字列)からStringReaderインスタンスを作成
                        StringReader rs = new StringReader(results);
                        //ストリームの末端まで繰り返す
                        while (rs.Peek() > -1)
                        {
                            //一行読み込んで表示する
                            string blankcheck = rs.ReadLine();
                            if (blankcheck != "")
                            {
                                if (blankcheck == "End of results. ")
                                {
                                    label10.Text = endofresults;
                                }
                                else if (blankcheck == "No valid PID found. ")
                                {
                                    MessageBox.Show(novalid, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    label10.Text = novalid;
                                    Error = 1;
                                }
                                else if (Regex.IsMatch(blankcheck, @"^[0-9]+$"))
                                {
                                    number = int.Parse(blankcheck);
                                    pid = long.Parse(rs.ReadLine());
                                    method = rs.ReadLine();
                                    ability = rs.ReadLine();
                                    hp = int.Parse(rs.ReadLine());
                                    at = int.Parse(rs.ReadLine());
                                    df = int.Parse(rs.ReadLine());
                                    spa = int.Parse(rs.ReadLine());
                                    spd = int.Parse(rs.ReadLine());
                                    spe = int.Parse(rs.ReadLine());
                                    nature = rs.ReadLine();
                                    gender = int.Parse(rs.ReadLine());
                                    hidpow = rs.ReadLine();
                                    hpvalue = int.Parse(rs.ReadLine());

                                    int ifnotequal = 0;
                                    if (comboBox3.SelectedIndex == 0)
                                    {
                                        if (numericUpDown1.Value != hp)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox4.SelectedIndex == 0)
                                    {
                                        if (numericUpDown2.Value != at)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox5.SelectedIndex == 0)
                                    {
                                        if (numericUpDown3.Value != df)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox6.SelectedIndex == 0)
                                    {
                                        if (numericUpDown4.Value != spa)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox7.SelectedIndex == 0)
                                    {
                                        if (numericUpDown5.Value != spd)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox8.SelectedIndex == 0)
                                    {
                                        if (numericUpDown6.Value != spe)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (ifnotequal != 1)
                                    {
                                        if (checkBox1.Checked == true)
                                        {
                                            dataGridView1.Rows.Add(number, Convert.ToString(pid, 16).ToUpper(), method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                        }
                                        else
                                        {
                                            dataGridView1.Rows.Add(number, pid, method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                        }
                                    }
                                }
                                else
                                {
                                    int num = 0;
                                    string dot = "";
                                    string[] spliter = results.Split('\n');
                                    if (spliter.Length <= 5)
                                    {
                                        num = spliter.Length;
                                        dot = "";
                                    }
                                    else
                                    {
                                        num = 5;
                                        dot = "...";
                                    }
                                    string[] getmessage = new string[num];
                                    Array.Copy(spliter, 0, getmessage, 0, num);
                                    MessageBox.Show(unexpectederror + "\n" + string.Join("\n", getmessage) + dot, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Error = 1;
                                    break;
                                }
                            }
                        }
                        rs.Close();
                    }
                    else
                    {
                        MessageBox.Show(failedgene, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(unexpectederror + "\n" + cserror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                StreamWriter inputdata = new System.IO.StreamWriter(inputfileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
                inputdata.WriteLine("4");
                inputdata.WriteLine((int)numericUpDown1.Value);
                inputdata.WriteLine((int)numericUpDown2.Value);
                inputdata.WriteLine((int)numericUpDown3.Value);
                inputdata.WriteLine((int)numericUpDown4.Value);
                inputdata.WriteLine((int)numericUpDown5.Value);
                inputdata.WriteLine((int)numericUpDown6.Value);
                inputdata.WriteLine(comboBox2.SelectedIndex - 1);
                if (comboBox1.SelectedIndex == 0)
                {
                    inputdata.WriteLine("n");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    inputdata.WriteLine("1");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    inputdata.WriteLine("2");
                }
                if (checkBox2.Checked == true)
                {
                    inputdata.WriteLine("y");
                    if (checkBox3.Checked == true)
                    {
                        inputdata.WriteLine("y");
                    }
                    else
                    {
                        inputdata.WriteLine("n");
                    }
                }
                else
                {
                    inputdata.WriteLine("n");
                }
                inputdata.WriteLine(comboBox9.SelectedIndex - 1);
                if (checkBox4.Checked == true)
                {
                    inputdata.WriteLine("-1");
                }
                else
                {
                    inputdata.WriteLine(textBox1.Text);
                }
                inputdata.WriteLine(textBox2.Text);
                inputdata.WriteLine(textBox3.Text);
                for (int i = 2; i <= numericUpDown8.Value / 3; i++)
                {
                    inputdata.WriteLine("-");
                }
                inputdata.WriteLine("0");
                inputdata.Close();
                if (!File.Exists(inputfileName))
                {
                    MessageBox.Show(inputName + failederror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
                System.Diagnostics.Process gene = new System.Diagnostics.Process();
                //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
                gene.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
                //出力を読み取れるようにする
                gene.StartInfo.UseShellExecute = false;
                gene.StartInfo.RedirectStandardOutput = true;
                gene.StartInfo.RedirectStandardInput = false;

                gene.StartInfo.RedirectStandardError = true;
                //OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
                //ウィンドウを表示しないようにする
                //gene.StartInfo.CreateNoWindow = true;
                //コマンドラインを指定（"/c"は実行後閉じるために必要）
                gene.StartInfo.Arguments = @"/c " + batfileName;
                //起動
                gene.Start();
                //出力を読み取る
                string results = gene.StandardOutput.ReadToEnd();
                string cserror = gene.StandardError.ReadToEnd();
                //プロセス終了まで待機する
                //WaitForExitはReadToEndの後である必要がある
                //(親プロセス、子プロセスでブロック防止のため)
                gene.WaitForExit();
                gene.Close();
                //出力された結果を表示
                Debug.WriteLine(results);
                Debug.WriteLine(cserror);

                if (File.Exists(batfileName))
                {
                    FileInfo batDel = new FileInfo(batfileName);
                    // ファイルを削除する
                    batDel.Delete();
                    if (File.Exists(batfileName))
                    {
                        MessageBox.Show(batName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(batName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                if (File.Exists(inputfileName))
                {
                    FileInfo inputDel = new FileInfo(inputfileName);
                    // ファイルを削除する
                    inputDel.Delete();
                    if (File.Exists(inputfileName))
                    {
                        MessageBox.Show(inputName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(inputName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
                //use results
                if (cserror == "")
                {
                    if (results != "")
                    {
                        //TextBox1に入力されている文字列から一行ずつ読み込む
                        //文字列(TextBox1に入力された文字列)からStringReaderインスタンスを作成
                        StringReader rs = new StringReader(results);
                        //ストリームの末端まで繰り返す
                        while (rs.Peek() > -1)
                        {
                            //一行読み込んで表示する
                            string blankcheck = rs.ReadLine();
                            if (blankcheck != "")
                            {
                                if (blankcheck == "End of results. ")
                                {
                                    label10.Text = endofresults;
                                }
                                else if (blankcheck == "No valid PID found. ")
                                {
                                    MessageBox.Show(novalid, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    label10.Text = novalid;
                                    Error = 1;
                                }
                                else if (Regex.IsMatch(blankcheck, @"^[0-9]+$"))
                                {
                                    number = int.Parse(blankcheck);
                                    pid = long.Parse(rs.ReadLine());
                                    method = rs.ReadLine();
                                    ability = rs.ReadLine();
                                    hp = int.Parse(rs.ReadLine());
                                    at = int.Parse(rs.ReadLine());
                                    df = int.Parse(rs.ReadLine());
                                    spa = int.Parse(rs.ReadLine());
                                    spd = int.Parse(rs.ReadLine());
                                    spe = int.Parse(rs.ReadLine());
                                    nature = rs.ReadLine();
                                    gender = int.Parse(rs.ReadLine());
                                    hidpow = rs.ReadLine();
                                    hpvalue = int.Parse(rs.ReadLine());

                                    int ifnotequal = 0;
                                    if (comboBox3.SelectedIndex == 0)
                                    {
                                        if (numericUpDown1.Value != hp)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox4.SelectedIndex == 0)
                                    {
                                        if (numericUpDown2.Value != at)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox5.SelectedIndex == 0)
                                    {
                                        if (numericUpDown3.Value != df)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox6.SelectedIndex == 0)
                                    {
                                        if (numericUpDown4.Value != spa)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox7.SelectedIndex == 0)
                                    {
                                        if (numericUpDown5.Value != spd)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (comboBox8.SelectedIndex == 0)
                                    {
                                        if (numericUpDown6.Value != spe)
                                        {
                                            ifnotequal = 1;
                                        }
                                    }
                                    if (ifnotequal != 1)
                                    {
                                        if (checkBox1.Checked == true)
                                        {
                                            dataGridView1.Rows.Add(number, Convert.ToString(pid, 16).ToUpper(), method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                        }
                                        else
                                        {
                                            dataGridView1.Rows.Add(number, pid, method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                        }
                                    }
                                }
                                else
                                {
                                    int num = 0;
                                    string dot = "";
                                    string[] spliter = results.Split('\n');
                                    if (spliter.Length <= 5)
                                    {
                                        num = spliter.Length;
                                        dot = "";
                                    }
                                    else
                                    {
                                        num = 5;
                                        dot = "...";
                                    }
                                    string[] getmessage = new string[num];
                                    Array.Copy(spliter, 0, getmessage, 0, num);
                                    MessageBox.Show(unexpectederror + "\n" + string.Join("\n", getmessage) + dot, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Error = 1;
                                    break;
                                }
                            }
                        }
                        rs.Close();
                    }
                    else
                    {
                        MessageBox.Show(failedgene, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(unexpectederror + "\n" + cserror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                StreamWriter inputdata = new System.IO.StreamWriter(inputfileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
                inputdata.WriteLine("5");
                inputdata.WriteLine((int)numericUpDown1.Value);
                inputdata.WriteLine((int)numericUpDown2.Value);
                inputdata.WriteLine((int)numericUpDown3.Value);
                inputdata.WriteLine((int)numericUpDown4.Value);
                inputdata.WriteLine((int)numericUpDown5.Value);
                inputdata.WriteLine((int)numericUpDown6.Value);
                inputdata.WriteLine(comboBox2.SelectedIndex - 1);
                if (comboBox1.SelectedIndex == 0)
                {
                    inputdata.WriteLine("n");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    inputdata.WriteLine("1");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    inputdata.WriteLine("2");
                }
                inputdata.WriteLine(textBox2.Text);
                inputdata.WriteLine(textBox3.Text);
                for (int i = 2; i <= numericUpDown8.Value / 3; i++)
                {
                    inputdata.WriteLine("-");
                }
                inputdata.WriteLine("0");
                inputdata.Close();
                if (!File.Exists(inputfileName))
                {
                    MessageBox.Show(inputName + failederror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                System.Diagnostics.Process gene = new System.Diagnostics.Process();
                //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
                gene.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
                //出力を読み取れるようにする
                gene.StartInfo.UseShellExecute = false;
                gene.StartInfo.RedirectStandardOutput = true;
                gene.StartInfo.RedirectStandardInput = false;

                gene.StartInfo.RedirectStandardError = true;
                //OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
                //ウィンドウを表示しないようにする
                //gene.StartInfo.CreateNoWindow = true;
                //コマンドラインを指定（"/c"は実行後閉じるために必要）
                gene.StartInfo.Arguments = @"/c " + batfileName;
                //起動
                gene.Start();
                //出力を読み取る
                string results = gene.StandardOutput.ReadToEnd();
                string cserror = gene.StandardError.ReadToEnd();
                //プロセス終了まで待機する
                //WaitForExitはReadToEndの後である必要がある
                //(親プロセス、子プロセスでブロック防止のため)
                gene.WaitForExit();
                gene.Close();
                //出力された結果を表示
                Debug.WriteLine(results);
                Debug.WriteLine(cserror);

                if (File.Exists(batfileName))
                {
                    FileInfo batDel = new FileInfo(batfileName);
                    // ファイルを削除する
                    batDel.Delete();
                    if (File.Exists(batfileName))
                    {
                        MessageBox.Show(batName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(batName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                if (File.Exists(inputfileName))
                {
                    FileInfo inputDel = new FileInfo(inputfileName);
                    // ファイルを削除する
                    inputDel.Delete();
                    if (File.Exists(inputfileName))
                    {
                        MessageBox.Show(inputName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(inputName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
                if (cserror == "")
                {
                    if (results != "")
                    {
                        //TextBox1に入力されている文字列から一行ずつ読み込む
                        //文字列(TextBox1に入力された文字列)からStringReaderインスタンスを作成
                        StringReader rs = new StringReader(results);
                        //ストリームの末端まで繰り返す
                        while (rs.Peek() > -1)
                        {
                            //一行読み込んで表示する
                            string blankcheck = rs.ReadLine();
                            if (blankcheck != "")
                            {
                                if (blankcheck == "End of results. ")
                                {
                                    label10.Text = endofresults;
                                }
                                else if (blankcheck == "No valid PID found. ")
                                {
                                    MessageBox.Show(novalid, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    label10.Text = novalid;
                                    Error = 1;
                                }
                                else if (Regex.IsMatch(blankcheck, @"^[0-9]+$"))
                                {
                                    number = int.Parse(blankcheck);
                                    pid = long.Parse(rs.ReadLine());
                                    method = rs.ReadLine();
                                    ability = rs.ReadLine();
                                    hp = int.Parse(rs.ReadLine());
                                    at = int.Parse(rs.ReadLine());
                                    df = int.Parse(rs.ReadLine());
                                    spa = int.Parse(rs.ReadLine());
                                    spd = int.Parse(rs.ReadLine());
                                    spe = int.Parse(rs.ReadLine());
                                    nature = rs.ReadLine();
                                    gender = int.Parse(rs.ReadLine());
                                    hidpow = rs.ReadLine();
                                    hpvalue = int.Parse(rs.ReadLine());
                                    if (checkBox1.Checked == true)
                                    {
                                        dataGridView1.Rows.Add(number, Convert.ToString(pid, 16).ToUpper(), method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                    }
                                    else
                                    {
                                        dataGridView1.Rows.Add(number, pid, method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(unexpectederror + "\n" + results, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Error = 1;
                                    break;
                                }
                            }
                        }
                        rs.Close();
                    }
                    else
                    {
                        MessageBox.Show(failedgene, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(unexpectederror + "\n" + cserror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                StreamWriter inputdata = new System.IO.StreamWriter(inputfileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
                inputdata.WriteLine("6");
                if (checkBox5.Checked == true)
                {
                    inputdata.WriteLine(Convert.ToInt64(textBox4.Text, 16));
                }
                else
                {
                    inputdata.WriteLine(textBox4.Text);
                }
                if (checkBox2.Checked == true)
                {
                    inputdata.WriteLine("y");
                    if (checkBox3.Checked == true)
                    {
                        inputdata.WriteLine("y");
                    }
                    else
                    {
                        inputdata.WriteLine("n");
                    }
                }
                else
                {
                    inputdata.WriteLine("n");
                }
                for (int i = 2; i <= numericUpDown8.Value / 3; i++)
                {
                    inputdata.WriteLine("-");
                }
                inputdata.WriteLine("0");
                inputdata.Close();
                if (!File.Exists(inputfileName))
                {
                    MessageBox.Show(inputName + failederror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                System.Diagnostics.Process gene = new System.Diagnostics.Process();
                //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
                gene.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
                //出力を読み取れるようにする
                gene.StartInfo.UseShellExecute = false;
                gene.StartInfo.RedirectStandardOutput = true;
                gene.StartInfo.RedirectStandardInput = false;

                gene.StartInfo.RedirectStandardError = true;
                //OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
                //ウィンドウを表示しないようにする
                //gene.StartInfo.CreateNoWindow = true;
                //コマンドラインを指定（"/c"は実行後閉じるために必要）
                gene.StartInfo.Arguments = @"/c " + batfileName;
                //起動
                gene.Start();
                //出力を読み取る
                string results = gene.StandardOutput.ReadToEnd();
                string cserror = gene.StandardError.ReadToEnd();
                //プロセス終了まで待機する
                //WaitForExitはReadToEndの後である必要がある
                //(親プロセス、子プロセスでブロック防止のため)
                gene.WaitForExit();
                gene.Close();
                //出力された結果を表示
                Debug.WriteLine(results);
                Debug.WriteLine(cserror);

                if (File.Exists(batfileName))
                {
                    FileInfo batDel = new FileInfo(batfileName);
                    // ファイルを削除する
                    batDel.Delete();
                    if (File.Exists(batfileName))
                    {
                        MessageBox.Show(batName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(batName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                if (File.Exists(inputfileName))
                {
                    FileInfo inputDel = new FileInfo(inputfileName);
                    // ファイルを削除する
                    inputDel.Delete();
                    if (File.Exists(inputfileName))
                    {
                        MessageBox.Show(inputName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(inputName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
                if (cserror == "")
                {
                    if (results != "")
                    {
                        //TextBox1に入力されている文字列から一行ずつ読み込む
                        //文字列(TextBox1に入力された文字列)からStringReaderインスタンスを作成
                        StringReader rs = new StringReader(results);
                        //ストリームの末端まで繰り返す
                        while (rs.Peek() > -1)
                        {
                            //一行読み込んで表示する
                            string blankcheck = rs.ReadLine();
                            if (blankcheck != "")
                            {
                                if (blankcheck == "End of results. ")
                                {
                                    label10.Text = endofresults;
                                }
                                else if (blankcheck == "No valid PID found. ")
                                {
                                    MessageBox.Show(novalid, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    label10.Text = novalid;
                                    Error = 1;
                                }
                                else if (Regex.IsMatch(blankcheck, @"^[0-9]+$"))
                                {
                                    number = int.Parse(blankcheck);
                                    pid = long.Parse(rs.ReadLine());
                                    method = rs.ReadLine();
                                    ability = rs.ReadLine();
                                    hp = int.Parse(rs.ReadLine());
                                    at = int.Parse(rs.ReadLine());
                                    df = int.Parse(rs.ReadLine());
                                    spa = int.Parse(rs.ReadLine());
                                    spd = int.Parse(rs.ReadLine());
                                    spe = int.Parse(rs.ReadLine());
                                    nature = rs.ReadLine();
                                    gender = int.Parse(rs.ReadLine());
                                    hidpow = rs.ReadLine();
                                    hpvalue = int.Parse(rs.ReadLine());
                                    if (checkBox1.Checked == true)
                                    {
                                        dataGridView1.Rows.Add(number, Convert.ToString(pid, 16).ToUpper(), method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                    }
                                    else
                                    {
                                        dataGridView1.Rows.Add(number, pid, method, gender, nature, ability, hp, at, df, spa, spd, spe, hidpow, hpvalue);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(unexpectederror + "\n" + results, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Error = 1;
                                    break;
                                }
                            }
                        }
                        rs.Close();
                    }
                    else
                    {
                        MessageBox.Show(failedgene, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(unexpectederror + "\n" + cserror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                StreamWriter inputdata = new System.IO.StreamWriter(inputfileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
                inputdata.WriteLine("7");
                if (checkBox6.Checked == true)
                {
                    inputdata.WriteLine(Convert.ToInt64(textBox5.Text, 16));
                }
                else
                {
                    inputdata.WriteLine(textBox5.Text);
                }
                inputdata.WriteLine(textBox2.Text);
                inputdata.WriteLine("0");
                inputdata.Close();
                if (!File.Exists(inputfileName))
                {
                    MessageBox.Show(inputName + failederror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                System.Diagnostics.Process gene = new System.Diagnostics.Process();
                //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
                gene.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
                //出力を読み取れるようにする
                gene.StartInfo.UseShellExecute = false;
                gene.StartInfo.RedirectStandardOutput = true;
                gene.StartInfo.RedirectStandardInput = false;

                gene.StartInfo.RedirectStandardError = true;
                //OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
                //ウィンドウを表示しないようにする
                //gene.StartInfo.CreateNoWindow = true;
                //コマンドラインを指定（"/c"は実行後閉じるために必要）
                gene.StartInfo.Arguments = @"/c " + batfileName;
                //起動
                gene.Start();
                //出力を読み取る
                string results = gene.StandardOutput.ReadToEnd();
                string cserror = gene.StandardError.ReadToEnd();
                //プロセス終了まで待機する
                //WaitForExitはReadToEndの後である必要がある
                //(親プロセス、子プロセスでブロック防止のため)
                gene.WaitForExit();
                gene.Close();
                //出力された結果を表示
                Debug.WriteLine(results);
                Debug.WriteLine(cserror);

                if (File.Exists(batfileName))
                {
                    FileInfo batDel = new FileInfo(batfileName);
                    // ファイルを削除する
                    batDel.Delete();
                    if (File.Exists(batfileName))
                    {
                        MessageBox.Show(batName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(batName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }

                if (File.Exists(inputfileName))
                {
                    FileInfo inputDel = new FileInfo(inputfileName);
                    // ファイルを削除する
                    inputDel.Delete();
                    if (File.Exists(inputfileName))
                    {
                        MessageBox.Show(inputName + deleteerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(inputName + missingerror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
                if (cserror == "")
                {
                    if (results != "")
                    {
                        //TextBox1に入力されている文字列から一行ずつ読み込む
                        //文字列(TextBox1に入力された文字列)からStringReaderインスタンスを作成
                        StringReader rs = new StringReader(results);

                        string sidcheck = rs.ReadLine();
                        if (sidcheck == "")
                        {
                            MessageBox.Show(failedgene, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Error = 1;
                        }
                        else if (Regex.IsMatch(Convert.ToString(sidcheck[0]), @"^[0-9]+$"))
                        {
                            textBox6.Text = sidcheck + to + rs.ReadLine();
                        }
                        else
                        {
                            MessageBox.Show(unexpectederror + "\n" + results, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Error = 1;
                        }
                        rs.Close();
                    }
                    else
                    {
                        MessageBox.Show(unexpectederror + "\n" + results, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error = 1;
                    }
                }
                else
                {
                    MessageBox.Show(unexpectederror + "\n" + cserror, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error = 1;
                }
            }
            else if (tabControl1.SelectedIndex == 7)
            {
                string PID2 = "";
                string HID = "";
                string LID = "";
                string NSID = "";
                if (checkBox11.Checked == true)
                {
                    PID2 = new string('0', 8 - textBox12.Text.Length) + textBox12.Text;
                    //MessageBox.Show(PID2);
                    HID = PID2.Substring(0, 4);
                    LID = PID2.Substring(4, 4);
                }
                else
                {
                    PID2 = new string('0', 8 - Convert.ToString(Convert.ToInt64(textBox12.Text), 16).Length) + Convert.ToString(Convert.ToInt64(textBox12.Text), 16);
                    //MessageBox.Show(PID2);
                    HID = PID2.Substring(0, 4);
                    LID = PID2.Substring(4, 4);
                }
                string TID = textBox2.Text;
                string SID = textBox3.Text;
                HID = Convert.ToString(Convert.ToInt32(HID, 16), 2);
                LID = Convert.ToString(Convert.ToInt32(LID, 16), 2);
                TID = Convert.ToString(Convert.ToInt32(TID), 2);
                SID = Convert.ToString(Convert.ToInt32(SID), 2);
                HID = new string('0', 16 - HID.Length) + HID;
                LID = new string('0', 16 - LID.Length) + LID;
                TID = new string('0', 16 - TID.Length) + TID;
                SID = new string('0', 16 - SID.Length) + SID;
                //MessageBox.Show(HID + "\n" + LID + "\n" + TID + "\n" + SID);
                for (int i = 0; i < 13; i++)
                {
                    //MessageBox.Show(HID.Substring(i, 1) + "\n" + LID.Substring(i, 1) + "\n" + TID.Substring(i, 1) + "\n" + SID.Substring(i, 1));
                    int plus = Convert.ToInt32(HID.Substring(i, 1)) + Convert.ToInt32(LID.Substring(i, 1)) + Convert.ToInt32(TID.Substring(i, 1));
                    if ( plus == 2 || plus == 0 )
                    {
                        NSID += "0";
                    }
                    else if (plus == 3 || plus == 1)
                    {
                        NSID += "1";
                    }
                }
                NSID += SID.Substring(13, 3);
                //MessageBox.Show(HID + "\n" + LID + "\n" + TID + "\n" + NSID);
                textBox13.Text = new string('0', 5 - Convert.ToString(Convert.ToInt32(NSID, 2)).Length) + Convert.ToString(Convert.ToInt32(NSID, 2)).ToLower();
            }
            if (checkBox9.Checked == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1[0, i].Value = i + 1;
                }
            }
            if (Error == 0)
            {
                if (tabControl1.SelectedIndex == 1 || tabControl1.SelectedIndex == 2 || tabControl1.SelectedIndex == 3)
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show(donebutnovalid, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (checkBox7.Checked != true)
                        {
                            MessageBox.Show(donemessage, Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else
                {
                    if (Error == 0)
                    {
                        if (checkBox7.Checked != true)
                        {
                            MessageBox.Show(donemessage, Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random RndIV = new System.Random();
            numericUpDown1.Value = RndIV.Next(1, 31);
            numericUpDown2.Value = RndIV.Next(1, 31);
            numericUpDown3.Value = RndIV.Next(1, 31);
            numericUpDown4.Value = RndIV.Next(1, 31);
            numericUpDown5.Value = RndIV.Next(1, 31);
            numericUpDown6.Value = RndIV.Next(1, 31);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = numericUpDown7.Value;
            numericUpDown2.Value = numericUpDown7.Value;
            numericUpDown3.Value = numericUpDown7.Value;
            numericUpDown4.Value = numericUpDown7.Value;
            numericUpDown5.Value = numericUpDown7.Value;
            numericUpDown6.Value = numericUpDown7.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 1; i <= dataGridView1.Rows.Count; i++)
                {
                    dataGridView1[1, i - 1].Value = Convert.ToString((long)dataGridView1[1, i - 1].Value, 16).ToUpper();
                }
            }
            else
            {
                for (int i = 1; i <= dataGridView1.Rows.Count; i++)
                {
                    dataGridView1[1, i - 1].Value = Convert.ToInt64((string)dataGridView1[1, i - 1].Value, 16);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Regex.Replace(textBox1.Text, @"[^0-9]", "");
            if (textBox1.Text != "")
            {
                if (Convert.ToInt32(textBox1.Text) > 70)
                {
                    textBox1.Text = "70";
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = comboBox10.SelectedIndex;
            comboBox4.SelectedIndex = comboBox10.SelectedIndex;
            comboBox5.SelectedIndex = comboBox10.SelectedIndex;
            comboBox6.SelectedIndex = comboBox10.SelectedIndex;
            comboBox7.SelectedIndex = comboBox10.SelectedIndex;
            comboBox8.SelectedIndex = comboBox10.SelectedIndex;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = Regex.Replace(textBox2.Text, @"[^0-9]", "");
            if (textBox2.Text != "")
            {
                if (Convert.ToInt32(textBox2.Text) > 65535)
                {
                    textBox2.Text = "65535";
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = Regex.Replace(textBox3.Text, @"[^0-9]", "");
            if (textBox3.Text != "")
            {
                if (Convert.ToInt32(textBox3.Text) > 65535)
                {
                    textBox3.Text = "65535";
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                textBox4.Text = Regex.Replace(textBox4.Text, @"[^0-9^a-f^A-F]", "");
            }
            else
            {
                textBox4.Text = Regex.Replace(textBox4.Text, @"[^0-9]", "");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                textBox5.Text = Regex.Replace(textBox5.Text, @"[^0-9^a-f^A-F]", "");
            }
            else
            {
                textBox5.Text = Regex.Replace(textBox5.Text, @"[^0-9]", "");
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                textBox12.Text = Regex.Replace(textBox12.Text, @"[^0-9^a-f^A-F]", "");
            }
            else
            {
                textBox12.Text = Regex.Replace(textBox12.Text, @"[^0-9]", "");
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (loading == 0)
            {
                if (checkBox5.Checked == true)
                {
                    if (textBox4.Text != "")
                    {
                        textBox4.Text = Convert.ToString(Convert.ToInt64(textBox4.Text), 16);
                    }
                    textBox4.MaxLength = 8;
                }
                else
                {
                    if (textBox4.Text != "")
                    {
                        textBox4.Text = Convert.ToString(Convert.ToInt64(textBox4.Text, 16));
                    }
                    textBox4.MaxLength = 10;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox3.Enabled = true;
            }
            else
            {
                checkBox3.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (loading == 0)
            {
                if (checkBox6.Checked == true)
                {
                    if (textBox5.Text != "")
                    {
                        textBox5.Text = Convert.ToString(Convert.ToInt64(textBox5.Text), 16);
                    }
                    textBox5.MaxLength = 8;
                }
                else
                {
                    if (textBox5.Text != "")
                    {
                        textBox5.Text = Convert.ToString(Convert.ToInt64(textBox5.Text, 16));
                    }
                    textBox5.MaxLength = 10;
                }
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (loading == 0)
            {
                if (checkBox11.Checked == true)
                {
                    if (textBox12.Text != "")
                    {
                        textBox12.Text = Convert.ToString(Convert.ToInt64(textBox12.Text), 16);
                    }
                    textBox12.MaxLength = 8;
                }
                else
                {
                    if (textBox12.Text != "")
                    {
                        textBox12.Text = Convert.ToString(Convert.ToInt64(textBox12.Text, 16));
                    }
                    textBox12.MaxLength = 10;
                }
            }
        }
        private void radioButtonlanguage_CheckedChanged(object sender, EventArgs e)
        {
            autosaveconfig();
            if (radioButton1.Checked == true)
            {
                language = 0;
                languageeng();
            }
            else if (radioButton2.Checked == true)
            {
                language = 1;
                languageesp();
            }
            else if (radioButton3.Checked == true)
            {
                language = 2;
                languagejpn();
            }
            refreshform();
        }

        private void languageeng()
        {
            target = targeteng + ".exe";

            endofresults = "End of results.";
            missingerror = " file is lost";
            failederror = " file creation failed";
            deleteerror = " file delete failed";
            failedgene = "Failed to generate";
            donemessage = "Done";
            donebutnovalid = "Done. But No valid PID found.\nIt may be solved by increasing the amount to get data.";
            novalid = "No valid PID found.";
            unexpectederror = "An unexpected error occurred";
            to = "~";

            IVPID = "IV --> PID";
            minIVHPPID = "Minimum IV + HP --> PID";
            minIVIDSIDPID = "Minimum IV + ID + SID --> shiny PID";
            minIVHPIDSIDshinyPID = "Minimum IV + HP + ID + SID --> shiny PID";
            IVIDSIDshinyPID = "IV + ID + SID --> chained shiny PID";
            PIDIV = "PID --> IV";
            shinyPIDIDSID = "Shiny PID + ID --> SID";
            PIDIDSIDshinySID = "PID + ID + SID --> Shiny SID";
            option = "Option";

            number = "No.";
            pid = "PID";
            method = "Method";
            ability = "Ability";
            hp = "HP";
            at = "Atk";
            df = "Def";
            spa = "SpA";
            spd = "SpD";
            spe = "Spe";
            nature = "Nature";
            gender = "Gender Value";
            hidpow = "Hidden Power";
            hpvalue = "HP Power";

            abilityfirst = "First";
            abilitysecond = "Second";

            generate = "Generate";
            hexpid = "Hex PID";
            gbamethods = "Test GBA methods?";
            evenrareone = "Even rare ones?\n(The author does not know\nwhether they are possible\r\nand GUI author too)\n";
            attack = "Attack";
            defense = "Defense";
            specialA = "Special Attack";
            specialD = "Special Defense";
            speed = "Speed";
            amount = "Amount to get data(higher is slower)";
            random = "Random IV";
            setalliv = "Set all IV";
            setallde = "Set all =/<";

            any = "any";
            hardy = "Hardy";
            lonely = "Lonely";
            brave = "Brave";
            adamant = "Adamant";
            naughty = "Naughty";
            bold = "Bold";
            docile = "Docile";
            relaxed = "Relaxed";
            impish = "Impish";
            lax = "Lax";
            timid = "Timid";
            hasty = "Hasty";
            serious = "Serious";
            jolly = "Jolly";
            naive = "Naive";
            modest = "Modest";
            mild = "Mild";
            quiet = "Quiet";
            bashful = "Bashful";
            rash = "Rash";
            calm = "Calm";
            gentle = "Gentle";
            sassy = "Sassy";
            careful = "Careful";
            quirky = "Quirky";

            fighting = "Fighting";
            flying = "Flying";
            poison = "Poison";
            ground = "Ground";
            rock = "Rock";
            bug = "Bug";
            ghost = "Ghost";
            steel = "Steel";
            fire = "Fire";
            water = "Water";
            grass = "Grass";
            electric = "Electric";
            psychic = "Psychic";
            ice = "Ice";
            dragon = "Dragon";
            dark = "Dark";

            hptype = "HP Type";
            hppower = "Minimum HP Power";

            shinypid = "Shiny PID";
            sid = "SID";
            shinysid = "Shiny SID";

            trainerid = "Trainer ID";
            secretid = "Secret ID";
            hexinput = "Hex input?";

            Export = "Export to CSV";

            DisableDone = "Disable Done message";
            DisableLoad = "Skip Config load(Reset Config)";
            CollectNo = "No. in correct order";

            languagelabel = "Language";
        }

        private void languageesp()
        {
            target = targetesp + ".exe";

            endofresults = "Fin de los resultados";
            missingerror = " el archivo se pierde";
            failederror = " la creación del archivo falló";
            deleteerror = " la eliminación del archivo falló";
            failedgene = "Error al generar";
            donemessage = "Hecho";
            donebutnovalid = "Hecho. Pero No se encontraron PID válidos.\nPuede solucionarse aumentando la cantidad para obtener datos.";
            novalid = "No se encontraron PID válidos";
            unexpectederror = "ocurrió un error inesperado";
            to = "~";

            IVPID = "IV --> PID";
            minIVHPPID = "IV mínimos + HP --> PID";
            minIVIDSIDPID = "IV mínimos + ID + SID --> PID shiny";
            minIVHPIDSIDshinyPID = "IV mínimos + HP + ID + SID --> PID shiny";
            IVIDSIDshinyPID = "IV + ID + SID --> PID shiny de PokéRadar";
            PIDIV = "PID --> IV";
            shinyPIDIDSID = "PID shiny + ID --> SID";
            PIDIDSIDshinySID = "PID + ID + SID --> shiny SID";
            option = "opção";

            number = "Nº";
            pid = "PID";
            method = "método";
            ability = "habilidad";
            hp = "PS";
            at = "Ata";
            df = "Def";
            spa = "AtE";
            spd = "DfE";
            spe = "Vel";
            nature = "naturaleza";
            gender = "Valor de género";
            hidpow = "Poder Oculto";
            hpvalue = "mínima de HP";

            abilityfirst = "primera";
            abilitysecond = "segunda";

            generate = "Generar";
            hexpid = "Hex PID";
            gbamethods = "¿Incluir métodos de GBA?";
            evenrareone = "¿También los más raros?\n(El autor desconoce\nsi son posibles\ny el autor de la GUI también)";
            attack = "Ataque";
            defense = "Defensa";
            specialA = "Ataque Especial";
            specialD = "Defensa Especial";
            speed = "Velocidad";
            amount = "Cantidad para obtener datos (más alto es más lento)";
            random = "Aleatorio IV";
            setalliv = "Establecer IV";
            setallde = "Establecer =/<";

            any = "importa";
            hardy = "Fuerte";
            lonely = "Huraña";
            brave = "Audaz";
            adamant = "Firme";
            naughty = "Pícara";
            bold = "Osada";
            docile = "Dócil";
            relaxed = "Plácida";
            impish = "Agitada";
            lax = "Floja";
            timid = "Miedosa";
            hasty = "Activa";
            serious = "Seria";
            jolly = "Alegre";
            naive = "Ingenua";
            modest = "Modesta";
            mild = "Afable";
            quiet = "Mansa";
            bashful = "Tímida";
            rash = "Alocada";
            calm = "Serena";
            gentle = "Amable";
            sassy = "Grosera";
            careful = "Cauta";
            quirky = "Rara";

            fighting = "Lucha";
            flying = "Volador";
            poison = "Veneno";
            ground = "Tierra";
            rock = "Roca";
            bug = "Bicho";
            ghost = "Fantasma";
            steel = "Acero";
            fire = "Fuego";
            water = "Agua";
            grass = "Planta";
            electric = "Eléctrico";
            psychic = "Psíquico";
            ice = "Hielo";
            dragon = "Dragón";
            dark = "Siniestro";

            hptype = "tipo de HP";
            hppower = "Potencia mínima de HP";

            shinypid = "Shiny PID";
            sid = "SID";
            shinysid = "Shiny SID";

            trainerid = "ID de entrenador";
            secretid = "ID secreto de entrenador";
            hexinput = "¿Entrada Hex?";

            Export = "Exportar a CSV";

            DisableDone = "Deshabilitar mensaje de Hecho";
            DisableLoad = "Saltar configuración de carga(Restablecer configuración)";
            CollectNo = "Nº en orden correcto";

            languagelabel = "Lenguaje";
        }

        private void languagejpn()
        {
            target = targetjpn + ".exe";

            endofresults = "これ以上はありません。";
            missingerror = " ファイルを見失いました。";
            failederror = " ファイルを生成できませんでした。";
            deleteerror = " ファイルを削除できませんでした。";
            failedgene = "生成失敗";
            donemessage = "完了";
            donebutnovalid = "完了しましたが、一致する性格値が見つかりませんでした。\n取得するデータ数を多くすれば解決する可能性があります。";
            novalid = "一致する性格値が見つかりません。";
            unexpectederror = "予期しないエラーが発生しました。";
            to = "～";

            IVPID = "個体値→性格値";
            minIVHPPID = "最小個体値+めざパ→性格値";
            minIVIDSIDPID = "最小個体値+表ID+裏ID→色違い性格値";
            minIVHPIDSIDshinyPID = "最小個体値+めざパ+表ID+裏ID→色違い性格値";
            IVIDSIDshinyPID = "個体値+表ID+裏ID→連続捕獲色違い性格値";
            PIDIV = "性格値→個体値";
            shinyPIDIDSID = "色違い性格値+表ID→裏ID推測";
            PIDIDSIDshinySID = "性格値+表ID+裏ID→色違い裏ID";
            option = "設定";

            number = "番号";
            pid = "性格値";
            method = "アルゴリズム";
            ability = "特性";
            hp = "HP";
            at = "攻撃";
            df = "防御";
            spa = "特攻";
            spd = "特防";
            spe = "素早さ";
            nature = "せいかく";
            gender = "性別値";
            hidpow = "めざパ";
            hpvalue = "威力";

            abilityfirst = "1番目";
            abilitysecond = "2番目";

            generate = "生成";
            hexpid = "16進数で性格値を生成";
            gbamethods = "GBAアルゴリズムを検証";
            evenrareone = "レアな性格値を生成?\n(可能かどうかは作者\nにはわかりません。\nそしてGUI作者も)";
            attack = "こうげき";
            defense = "ぼうぎょ";
            specialA = "とくこう";
            specialD = "とくぼう";
            speed = "すばやさ";
            amount = "取得するデータ数(高いと生成速度低下)";
            random = "ランダムIV";
            setalliv = "一括設定 IV";
            setallde = "一括設定 =/<";

            any = "指定なし";
            hardy = "がんばりや";
            lonely = "さみしがり";
            brave = "ゆうかん";
            adamant = "いじっぱり";
            naughty = "やんちゃ";
            bold = "ずぶとい";
            docile = "すなお";
            relaxed = "のんき";
            impish = "わんぱく";
            lax = "のうてんき";
            timid = "おくびょう";
            hasty = "せっかち";
            serious = "まじめ";
            jolly = "ようき";
            naive = "むじゃき";
            modest = "ひかえめ";
            mild = "おっとり";
            quiet = "れいせい";
            bashful = "てれや";
            rash = "うっかりや";
            calm = "おだやか";
            gentle = "おとなしい";
            sassy = "なまいき";
            careful = "しんちょう";
            quirky = "きまぐれ";

            fighting = "かくとう";
            flying = "ひこう";
            poison = "どく";
            ground = "じめん";
            rock = "いわ";
            bug = "むし";
            ghost = "ゴースト";
            steel = "はがね";
            fire = "ほのお";
            water = "みず";
            grass = "くさ";
            electric = "でんき";
            psychic = "エスパー";
            ice = "こおり";
            dragon = "ドラゴン";
            dark = "あく";

            hptype = "めざめるパワータイプ";
            hppower = "最小めざめるパワー威力";

            shinypid = "色違い性格値";
            sid = "裏ID";
            shinysid = "色違い裏ID";

            trainerid = "トレーナーID";
            secretid = "隠しトレーナーID";
            hexinput = "16進数の性格値？";

            Export = "CSVに出力";

            DisableDone = "完了メッセージを表示しない";
            DisableLoad = "設定を読み込まない(設定初期化)";
            CollectNo = "正しい番号順にする";

            languagelabel = "言語";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // メッセージ文字列
            DateTime dt = DateTime.Now;

            if (dataGridView1.RowCount <= 0)
            {
                MessageBox.Show(noexportdata, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog ExportCSV = new SaveFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ExportCSV.FileName = Title + "_" + dt.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv";
            //はじめに表示されるフォルダを指定する
            ExportCSV.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ExportCSV.Filter = "CSV file(*.csv)|*.csv|All Files(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ExportCSV.FilterIndex = openfileFilterIndex;
            //タイトルを設定する
            ExportCSV.Title = Title;
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ExportCSV.RestoreDirectory = true;
            //既に存在するファイル名を指定したとき警告する
            //デフォルトでTrueなので指定する必要はない
            ExportCSV.OverwritePrompt = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ExportCSV.CheckPathExists = true;

            //ダイアログを表示する
            if (ExportCSV.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            openfileFilterIndex = ExportCSV.FilterIndex;
            autosaveconfig();
            // 出力先
            string FILE_PATH = ExportCSV.FileName;
            //const string FILE_PATH = @"d:\sample.csv";

            // Shift-JISの上書きモードでファイルを開く
            using (StreamWriter sw = new StreamWriter(FILE_PATH, false, System.Text.Encoding.Default))
            {
                // ワーク文字列言
                string s = "";

                // ヘッダー出力
                // 行ループ
                for (int iCol = 0; iCol < dataGridView1.Columns.Count; iCol++)
                {
                    // ヘッダーの値を取得する
                    String sCell = dataGridView1.Columns[iCol].HeaderCell.Value.ToString();

                    // 2列目以降ならワーク文字列に「,」を追加する
                    if (iCol > 0)
                    {
                        s += ",";
                    }

                    // ワーク文字列にセルの値を追加する
                    s += quoteCommaCheck(sCell);
                }
                // ワーク文字列をファイルに出力する
                sw.WriteLine(s);

                // 追加行を除く行数を求める
                int maxRowsCount = dataGridView1.Rows.Count;
                if (dataGridView1.AllowUserToAddRows)
                {
                    // 追加行が含まれているので、そのカウントを除く
                    maxRowsCount = maxRowsCount - 1;
                }

                // データ出力
                // 行ループ
                for (int iRow = 0; iRow < maxRowsCount; iRow++)
                {
                    // ワーク文字初期化
                    s = "";

                    // 列ループ
                    for (int iCol = 0; iCol < dataGridView1.Columns.Count; iCol++)
                    {
                        // セルの値を取得する
                        String sCell = dataGridView1[iCol, iRow].Value.ToString();

                        // 2列目以降ならワーク文字列に「,」を追加する
                        if (iCol > 0)
                        {
                            s += ",";
                        }

                        // ワーク文字列にセルの値を追加する
                        s += quoteCommaCheck(sCell);

                    }
                    // ワーク文字列をファイルに出力する
                    sw.WriteLine(s);
                }
            }
            MessageBox.Show(donemessage, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string quoteCommaCheck(string sCell)
        {
            const string QUOTE = @""""; // 「"」
            const string COMMA = @",";  // 「,」

            // OR検索用文字列
            string[] a = new string[] { QUOTE, COMMA };

            // セルの値に「”」か「,」が含まれていないか判定する
            if (a.Any(sCell.Contains))
            {
                // 「"」を「"」で囲む
                sCell = sCell.Replace(QUOTE, QUOTE + QUOTE);

                // セルの値を「"」で囲む
                sCell = QUOTE + sCell + QUOTE;
            }
            return sCell;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            inputName = textBox8.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            batName = textBox7.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            targeteng = textBox9.Text;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            targetesp = textBox10.Text;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            targetjpn = textBox11.Text;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                panel6.Visible = true;
            }
            else
            {
                panel6.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "Patched.pk3";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "Decrypted PKM File (*pk3)|*.pk3|All Files (*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 0;
            //タイトルを設定する
            ofd.Title = Title;
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //OKボタンがクリックされたとき、選択されたファイル名を表示する
            Console.WriteLine(ofd.FileName);
            byte[] binaryRead = File.ReadAllBytes(ofd.FileName);

            for (int i = 0; i < binaryRead.Length; i++)
            {
                Console.Write("0x{0:X2}, ", binaryRead[i]);
            }

        }
    }
}
