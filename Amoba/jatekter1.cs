using System;
using System.Collections;
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
        List<string> kepek = new List<string> { "img/ures.png", "img/kor.png", "img/x.png", "img/haromszog.png" };
        List<string> ellenorizve = new List<string>();
        List<string> ellenorizveSzin = new List<string>();
        string kattintottKord = "-1_-1";
        int kiJon = 0;
        //1 kor
        //2 x
        int jatekosSzam = 1;
        int[] iranyDb = new int[] { 1, 1, 1, 1 };//függőleges, jobb föl átló, vízszintes, jobb le átló
        //föl, Jobb föl, jobb, jobb le, le, bal le,                     bal, bal föl
        int[] iranyDbSzin = new int[] { 1, 1, 1, 1 };

        string[] iranyOK = new string[] { "-1_0", "-1_1", "0_1", "1_1", "1_0" , "1_-1" , "0_-1" , "-1_-1" };
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
                    PictureBox cella = cellak[sor, oszlop];
                    cella.Size = new Size(25, 25);
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
            ertek = kiJon;
            kattintott.Tag = $"{sor}_{oszlop}_{ertek}";
            kattintottKord = $"{sor}_{oszlop}";
            kiJon += 1;
            if (kiJon == jatekosSzam + 1)
            {
                kiJon = 1;
            }
            //MessageBox.Show("irányok: " + string.Join(", ", iranyDb)+"\n");
            kiir.Clear();

            ellenorizve.Clear();
            iranyDb = new int[] { 1, 1, 1, 1, 0, 0, 0, 0 };
            /*for (int so = 0; so < meret; so++)
            {
                for (int osz = 0; osz < meret; osz++)
                {
                    cellak[so, osz].BackColor = Color.LightGray;
                }
            }*/
            
            ellenoriz(sor, oszlop, ertek, "");
            kiir.AppendText("irányok: " + string.Join(", ", iranyDb) + "\n");
        }

        private void ellenoriz(int sor, int oszlop, int ertek, string irany)
        {
            ellenorizve.Add((sor + "_" + oszlop));
            if (irany == "")
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0) continue; // ne a saját cellát nézzük
                        int s = sor + i;
                        int o = oszlop + j;
                        if (!(s >= 0 && s < meret && o >= 0 && o < meret)) continue;
                        // if (!(s < 0 || s >= meret ||     o < 0 && o >= meret)) continue;
                        //if (s >= 0 && s < meret && o >= 0 && o < meret) continue;
                        //cellak[s, o].BackColor = Color.Orange;
                        int ellErtek = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]);
                        if (ellErtek == ertek)
                        {
                            int iranyindex = koordinataSzamSzamol(i, j);
                            /*int db = iranyDb[iranyindex];
                            db++;*/
                            //iranyDb[iranyindex] = 1;
                            /*foreach (int elem in iranyDb)
                            {
                                if (elem >= 5)
                                {
                                    //MessageBox.Show("Nyert a " + (ertek == 1 ? "kör" : ertek == 2 ? "X":"hiba") + " játékos!");
                                    MessageBox.Show("Nyert a " + ertek + " játékos!");
                                    return;
                                }
                            }*/
                            /*for (int ind = 0; ind < 4; ind++)
                            {
                                if (iranyDb[ind] + iranyDb[ind + 4] >= 5)
                                {
                                    //MessageBox.Show("Nyert a " + (ertek == 1 ? "kör" : ertek == 2 ? "X":"hiba") + " játékos!");
                                    MessageBox.Show("Nyert a " + ertek + " játékos!");
                                    return;
                                }
                            }*/
                            if (!ellenorizve.Contains(s + "_" + o))
                            {
                                //cellak[s, o].BackColor = Color.Blue;

                                ellenoriz(s, o, ertek, (i.ToString() + "_" + j.ToString()));
                            }
                        }
                    }
                }
            }
            else
            {
                int ellS = Convert.ToInt32(irany.Split('_')[0]);
                int ellO = Convert.ToInt32(irany.Split('_')[1]);

                int s = sor + ellS;
                int o = oszlop + ellO;

                //kiir.AppendText("\nkülön: "+ellS+"_"+ ellO);
                kiir.AppendText("\n"+ koordinataSzamSzamol(ellS, ellO));

                int iranyindex = koordinataSzamSzamol(ellS, ellO);
                iranyDb[iranyindex]++;

                for (int ind = 0; ind < 4; ind++)
                {
                    if (iranyDb[ind] + iranyDb[ind + 4] >= 5)
                    {
                        //MessageBox.Show("Nyert a " + (ertek == 1 ? "kör" : ertek == 2 ? "X":"hiba") + " játékos!");
                        ellenorizveSzin.Clear();
                        //iranyDbSzin = new int[] { 1, 1, 1, 1, 0, 0, 0, 0 };
                        int szinSor = Convert.ToInt32(kattintottKord.Split('_')[0]);
                        int szinOszl = Convert.ToInt32(kattintottKord.Split('_')[1]);
                        cellaszinez(szinSor, szinOszl, ertek, iranyOK[ind]);
                        //MessageBox.Show("Nyert a " + ertek + " játékos!");
                        
                    }
                }

                if (!(s >= 0 && s < meret && o >= 0 && o < meret)) return;

                int ellErtek = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]);
                if (ellErtek == ertek)
                {
                    if (!ellenorizve.Contains(s + "_" + o))
                    {
                        //cellak[s, o].BackColor = Color.Red;
                        cellak[sor, oszlop].BackColor = Color.Blue;
                        ellenoriz(s, o, ertek, (ellS.ToString() + "_" + ellO.ToString()));

                    }


                }

            }
        }

        private int koordinataSzamSzamol(int s, int o)
        {
            if (s == 0 && o == 0)
                throw new ArgumentException("0_0 nem megengedett");

            string koord  = $"{s}_{o}";

            /*switch (koord)
            {
                case "-1_0":
                    return 0; //föl

                case "-1_1":
                    return 1; //jobb föl

                case "0_1":
                    return 2; //jobb

                case "1_1":
                    return 3; //jobb le

                case "1_0":
                    return 4; //le

                case "1_-1":
                    return 5; //bal le

                case "0_-1":
                    return 6; //bal

                case "-1_-1":
                    return 7; //bal föl

                default:
                    throw new ArgumentException("Érvénytelen koordináta: " + koord);
            }*/
            return iranyOK.ToList().IndexOf(koord);
        }

        private void jatekter1_Load(object sender, EventArgs e)
        {

        }

        private void cellaszinez(int sor, int oszlop, int ertek, string irany)
        {
            if (ellenorizveSzin.Contains(sor + "_" + oszlop))
            {
                return;
            }
            ellenorizveSzin.Add((sor + "_" + oszlop));
            int ellS = Convert.ToInt32(irany.Split('_')[0]);
            int ellO = Convert.ToInt32(irany.Split('_')[1]);

            int s = sor + ellS;
            int o = oszlop + ellO;
            //cellak[sor, oszlop].BackColor = Color.Red;
            int ujertek = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]);

            while (ujertek == ertek)
            {
                if (!(s >= 0 && s < meret && o >= 0 && o < meret)) return;
                cellak[s, o].BackColor = Color.Red;
                s = s + ellS;
                o = o + ellO;
                if (!(s >= 0 && s < meret && o >= 0 && o < meret)) return;
                ujertek = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]);
                /*
                cellaszinez(s, o, ertek, irany);
                irany = ((-ellS).ToString() + "_" + (-ellO).ToString());
                cellaszinez(s, o, ertek, irany);*/
                //Thread.Sleep(1000);

            }
            irany = ((-ellS).ToString() + "_" + (-ellO).ToString());
            ellS = Convert.ToInt32(irany.Split('_')[0]);
            ellO = Convert.ToInt32(irany.Split('_')[1]);
            ujertek = ertek;
            while (ujertek == ertek)
            {
                if (!(s >= 0 && s < meret && o >= 0 && o < meret)) return;
                if (Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]) == ertek)
                cellak[s, o].BackColor = Color.Red;
                s = s + ellS;
                o = o + ellO;
                ujertek = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]);
                /*
                cellaszinez(s, o, ertek, irany);
                irany = ((-ellS).ToString() + "_" + (-ellO).ToString());
                cellaszinez(s, o, ertek, irany);*/

            }
        }
    }
}
