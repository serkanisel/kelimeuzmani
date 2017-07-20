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
            int BelgeKayit = 1 << 0;
            int BelgeSatirKayit = 1 << 1;
            int BelgeOnayla = 1 << 2;
            int BelgeBloke = 1 << 3;
            int BelgeGuncelle = 1 << 4;
            int BelgeSatirGuncelle = 1 << 5;
            int BelgeSil = 1 << 6;
            int BelgeIptal = 1 << 7;
            int BelgeSatirIptal = 1 << 8;
            int BelgeSatirSil = 1 << 9;
            int BelgeSatirRed = 1 << 10;
            int TeminatIptal = 1 << 13;
            int BelgeKapatma = 1 << 14;
            int TransferBildirimFormuKayit = 1 << 15;
            int EFaturaIptal = 1 << 16;
            int BelgeSatirKapatma = 1 << 17;
            int BelgeTopluSatirKayit = 1 << 18;
            int BasvuruKayit = 1 << 19;
            int BasvuruSatirKayit = 1 << 20;
            int TeminatKayit = 1 << 21;
            int EFaturaKayit = 1 << 22;
            int BasvuruGuncelle = 1 << 23;
            int BasvuruIptal = 1 << 24;
            int BasvuruSatirGuncelle = 1 << 25;
            int BasvuruSatirSil = 1 << 26;
            int BelgeTopluKayit = 1 << 27;
            int BasvuruOnayaSun = 1 << 28;
            int BasvuruKabulRedIslemi = 1 << 29;
            int TeminatSil = 1 << 30;
            int TransferBildirimFormuIptal = 1 << 31;

            b = "BelgeKayit =" + (BelgeKayit).ToString() + System.Environment.NewLine;
            b += "BelgeSatirKayit =" + (BelgeSatirKayit ).ToString()+ System.Environment.NewLine;
            b += "BelgeOnayla =" + (BelgeOnayla ).ToString()+ System.Environment.NewLine;
            b += "BelgeBloke =" + (BelgeBloke ).ToString()+ System.Environment.NewLine;
            b += "BelgeGuncelle =" + (BelgeGuncelle ).ToString()+ System.Environment.NewLine;
            b += "BelgeSatirGuncelle =" + (BelgeSatirGuncelle ).ToString()+ System.Environment.NewLine;
            b += "BelgeSil =" + (BelgeSil ).ToString()+ System.Environment.NewLine;
            b += "BelgeIptal = " + (BelgeIptal ).ToString()+ System.Environment.NewLine;
            b += "BelgeSatirIptal =" + (BelgeSatirIptal ).ToString()+ System.Environment.NewLine;
            b += "BelgeSatirSil =" + (BelgeSatirSil ).ToString()+ System.Environment.NewLine;
            b += "BelgeSatirRed =" + (BelgeSatirRed ).ToString()+ System.Environment.NewLine;
            b += "TeminatIptal =" + (TeminatIptal ).ToString()+ System.Environment.NewLine;
            b += "BelgeKapatma" + (BelgeKapatma ).ToString()+ System.Environment.NewLine;
            b += "TransferBildirimFormuKayit =" + (TransferBildirimFormuKayit ).ToString()+ System.Environment.NewLine;
            b += "EFaturaIptal =" + (EFaturaIptal ).ToString()+ System.Environment.NewLine;
            b += "BelgeSatirKapatma =" + (BelgeSatirKapatma ).ToString()+ System.Environment.NewLine;
            b += "BelgeTopluSatirKayit =" + (BelgeTopluSatirKayit ).ToString()+ System.Environment.NewLine;
            b += "BasvuruKayit =" + (BasvuruKayit ).ToString()+ System.Environment.NewLine;
            b += "BasvuruSatirKayit =" + (BasvuruSatirKayit ).ToString()+ System.Environment.NewLine;
            b += "TeminatKayit =" + (TeminatKayit ).ToString()+ System.Environment.NewLine;
            b += "EFaturaKayit =" + (EFaturaKayit ).ToString()+ System.Environment.NewLine;
            b += "BasvuruGuncelle =" + (BasvuruGuncelle ).ToString()+ System.Environment.NewLine;
            b += "BasvuruIptal =" + (BasvuruIptal ).ToString()+ System.Environment.NewLine;
            b += "BasvuruSatirGuncelle =" + (BasvuruSatirGuncelle ).ToString()+ System.Environment.NewLine;
            b += "BasvuruSatirSil =" + (BasvuruSatirSil ).ToString()+ System.Environment.NewLine;
            b += "BelgeTopluKayit =" + (BelgeTopluKayit ).ToString()+ System.Environment.NewLine;
            b += "BasvuruOnayaSun =" + (BasvuruOnayaSun ).ToString()+ System.Environment.NewLine;
            b += "BasvuruKabulRedIslemi =" + (BasvuruKabulRedIslemi ).ToString()+ System.Environment.NewLine;
            b += "TeminatSil =" + (TeminatSil ).ToString()+ System.Environment.NewLine;
            b += "TransferBildirimFormuIptal =" + (TransferBildirimFormuIptal ).ToString()+ System.Environment.NewLine;

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
