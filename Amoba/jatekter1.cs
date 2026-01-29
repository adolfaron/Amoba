using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amoba
{

    public partial class jatekter1 : Form
    {
        const int meret = 30;
        PictureBox[,] cellak = new PictureBox[meret, meret];
        List<string> kepek = new List<string> { "img/ures.png", "img/kor.png","img/x.png" };
        int kiJon = 0;
        //1 kor
        //2 x
        int jatekosSzam = 2;
        public jatekter1()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            Text = "Amóba";
            for (int sor = 0; sor < meret; sor++)
            {
                for (int oszlop = 0; oszlop < meret; oszlop++)
                {
                    cellak[sor, oszlop] = new PictureBox();
                    PictureBox cella =cellak[sor, oszlop];
                    cella.Size = new Size(20, 20);
                    cella.BackColor = Color.LightGray;
                    cella.Location = new Point(oszlop * (cella.Size.Width + 3) + 12, sor * (cella.Size.Height + 3) + 12);
                        this.Controls.Add(cella);
                    cella.Click += new EventHandler(cekkaKatt);
                    cella.SizeMode = PictureBoxSizeMode.StretchImage;
                    cella.Tag = $"{sor}_{oszlop}_0";
                }
            }
            kiJon = 1;
        }

        private void cekkaKatt(object sender, EventArgs e)
        {
            PictureBox kattintott = sender as PictureBox;
            int sor = Convert.ToInt32(kattintott.Tag.ToString().Split('_')[0]);
            int oszlop = Convert.ToInt32(kattintott.Tag.ToString().Split('_')[1]);
            int ertek = Convert.ToInt32(kattintott.Tag.ToString().Split('_')[2]);
            if (ertek != 0)
                return;
            kattintott.Image = Image.FromFile(kepek[kiJon]);
            kattintott.Tag = $"{sor}_{oszlop}_{kiJon}";
            kiJon += 1;
            if (kiJon == jatekosSzam + 1) {
                kiJon = 1;
            }
            

            ellenoriz(sor, oszlop);
        }

        private void ellenoriz(int sor, int oszlop)
        {
            
        }
    }
}
