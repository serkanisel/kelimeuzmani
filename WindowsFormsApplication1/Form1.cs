using KelimeUzmani.Entity;
using KelimeUzmani.UnitOfWork.Contract;
using KelimeUzmani.UnitOfWork.UOW;
using System
;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Dosya Adresi Giriniz.");
                return;
            }
            string path = textBox1.Text;
            //DirectoryInfo di = new DirectoryInfo(path);

            IWord iword = new WordBS();

            //FileInfo[] files = di.GetFiles("*.*");

            string contents;
            //for (int i = 0; i < files.Count(); i++)
            //{
            contents = File.ReadAllText(path);

            string[] lines = contents.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            string newString = "";
            int counter = 1;
            Word w = null;
            for (int a = 0; a < lines.Length; a++)
            {

                if (lines[a].Trim().StartsWith("<m"))
                {
                    w = new Word();
                    lines[a] = lines[a].Trim().Replace("<m>", "").Replace("</m>", "");
                    w.WordBody = lines[a];
                    newString += counter.ToString() + " " + lines[a] + "\n";
                }

                if (lines[a].Trim().StartsWith("<b"))
                {

                    lines[a] = lines[a].Trim().Replace("</div>", "");
                    w.Description = lines[a];
                    newString += counter.ToString() + " " + lines[a] + "\n";
                    counter++;
                }

                if (w != null && w.WordBody != null && w.Description != null && w.ID == 0)
                {
                    w = iword.SaveWord(w,(int)comboBox1.SelectedValue);
                }
            }

            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            label1.Text = "";
            string b = "";
            for (int i = 0; i < 31; i++)
            {
                a = 1 << i;
                label1.Text = label1.Text + i.ToString() + " = " + a.ToString() + "  ";
                b += i.ToString() + " = " + a.ToString() + "  ";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IWordList iwordList = new WordListBS();

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = iwordList.GetAllWordList();

        }

    }

}
