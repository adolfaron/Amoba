using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amoba
{

    public partial class jatekter1 : Form
    {
        //int meret = 30;
        int meret;
        int jatekosSzam = 2;
        List<string> jatekosNevek = new List<string> { "Üres", "Kör", "X" };
        int kijon;
        //int kijon = 5;

        int cellameret;
        int elhagyas = 12;
        int koz = 3;

        int maxLerakott = 3;

        int kor = 0;

        PictureBox[,] cellak;
        Label kovJatekosMutat;
        ListBox jatekosok;

        PictureBox kovJatekosMutatKep;
        //List<string> kepekUt = new List<string> { "img/ures.png", "img/kor.png", "img/x.png", "img/haromszog.png" };
        List<string> ellenorizve = new List<string>();
        List<string> ellenorizveSzin = new List<string>();
        List<Color> szinek = new List<Color>();
        string kattintottKord = "-1_-1";
        int kiKov = 0;
        List<Image> kepek = new List<Image>();
        List<int> pontszamok = new List<int>();


        int[] iranyDb = new int[] { 1, 1, 1, 1, 0, 0, 0, 0 };//függőleges, jobb föl átló, vízszintes, jobb le átló
        //föl, Jobb föl, jobb, jobb le, le, bal le,                     bal, bal föl
        int[] iranyDbSzin = new int[] { 1, 1, 1, 1 };

        List<int> jatekosTart = new List<int>();     

        string[] iranyOK = new string[] { "-1_0", "-1_1", "0_1", "1_1", "1_0" , "1_-1" , "0_-1" , "-1_-1" };
        public jatekter1(int ujMeret, List<string> ujNevek, List<Image> ujkepek, List<Color> ujSzinek, int ujKijon, int lerakotmax)
        {
            //indításra
            {
                kepek.Clear();
                kepek = ujkepek;
                InitializeComponent();
                meret = ujMeret;
                jatekosSzam = ujNevek.Count - 1;
                jatekosNevek = ujNevek;
                szinek = ujSzinek;
                maxLerakott = lerakotmax;
                //MessageBox.Show(maxLerakott + "Maxlerakott");
                kijon = ujKijon;
                cellak = new PictureBox[meret, meret];
                this.BackColor = Color.White;
                Text = "Amőba";
                cellameret = (int)(this.ClientSize.Width * (2.0 / 3.0) / meret);

                pontszamok = Enumerable
                    .Repeat(0, jatekosNevek.Count)
                    .ToList();

                for (int i = 0; i < jatekosSzam; i++) { 
                    jatekosTart.Add(0);
                }
                for (int sor = 0; sor < meret; sor++)
                {
                    for (int oszlop = 0; oszlop < meret; oszlop++)
                    {
                        cellak[sor, oszlop] = new PictureBox();
                        PictureBox cella = cellak[sor, oszlop];
                        cella.Size = new Size(cellameret, cellameret);
                        cella.BackColor = Color.LightGray;
                        //asd
                        cella.Location = new Point(oszlop * (cella.Size.Width + koz) + elhagyas, sor * (cella.Size.Height + koz) + elhagyas);
                        this.Controls.Add(cella);
                        cella.Click += new(cekkaKatt);
                        cella.SizeMode = PictureBoxSizeMode.StretchImage;
                        cella.Tag = $"{sor}_{oszlop}_0_0_0000";
                    }
                }
                kovJatekosMutat = new Label()
                {
                    Text = "Következő játékos:",
                    Size = new Size(300, 30),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                kovJatekosMutatKep = new PictureBox()
                {
                    Image = kepek[1],
                    Size = new Size(50, 50),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                jatekosok = new ListBox()
                {
                    Size = new Size(180, 200),
                    SelectionMode = SelectionMode.One,
                    BorderStyle = BorderStyle.None,
                    BackColor = this.BackColor,
                    ForeColor = Color.Black,
                    Enabled = false,

                };
                jatekosok.ItemHeight = 40; // vagy a kívánt pixel
                jatekosok.Height = jatekosSzam * jatekosok.ItemHeight + 2; // 2 pixel keretnek
                jatekosok.SelectionMode = SelectionMode.One;
                jatekosok.DrawMode = DrawMode.OwnerDrawFixed;

                jatekosok.DrawItem += (s, e) =>
                {
                    if (e.Index < 0) return;

                    bool kijelolt = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

                    Color hatter = kijelolt ? Color.DarkGray : jatekosok.BackColor;
                    Color szoveg = kijelolt ? Color.White : jatekosok.ForeColor;

                    using (SolidBrush bg = new SolidBrush(hatter)) //háttér kitöltése, using: automatikusan eldobja a bg objektumot a blokk végén, így nem kell manuálisan meghívni a Dispose() metódust
                        e.Graphics.FillRectangle(bg, e.Bounds);

                    string szovegTartalom = jatekosok.Items[e.Index].ToString();

                    using (SolidBrush fg = new SolidBrush(szoveg)) //formázás
                        e.Graphics.DrawString(
                            szovegTartalom,
                            e.Font,
                            fg,
                            e.Bounds.Left + 6,
                            e.Bounds.Top + 10
                        );
                };
                jatekosokKiir();

                this.Controls.Add(jatekosok);
                this.Controls.Add(kovJatekosMutatKep);
                this.Controls.Add(kovJatekosMutat);
                elhelyezesSzamol();
                kiKov = 1;
                //kovJatekosMutat.Text = "Következő játékos:\n" + jatekosNevek[kiKov];
                kovJatekosMutatKep.Image = kepek[kiKov];
                jatekosok.SelectedIndex = kiKov - 1;

            }
        }
        private void jatekosokKiir()
        {
            int kival = jatekosok.SelectedIndex;
            jatekosok.Items.Clear();
            for (int i = 1; i <= jatekosSzam; i++)
            {
                jatekosok.Items.Add(jatekosNevek[i] + ": " + pontszamok[i]);
            }
            jatekosok.SelectedIndex = kival;
        }

        private void elhelyezesSzamol()
        {
            if (kovJatekosMutat == null ||
                kovJatekosMutatKep == null ||
                jatekosok == null ||
                cellak == null)
                return;
            cellameret = (int)(this.ClientSize.Width * (2.0 / 3.0) / meret);
            int cellakSzelesseg = 2 * elhagyas + (cellameret + koz) * meret;
            int maradek = this.ClientSize.Width - cellakSzelesseg;
            int width = this.ClientSize.Width;
            //this.Height = cellakSzelesseg+elhagyas*2;
            //this.ClientSize = new Size(this.Width, this.Height);
            this.ClientSize = new Size(
                this.ClientSize.Width,
                cellakSzelesseg + elhagyas * 2
            );

            if (kovJatekosMutat.Width > maradek)
            {
                kovJatekosMutat.Width = maradek-2*elhagyas;
            }
            if (kovJatekosMutatKep.Width > maradek) 
            {
                kovJatekosMutatKep.Width = maradek - 2 * elhagyas;
            }
            if (jatekosok.Width > maradek)
            {
                jatekosok.Width = maradek - 2 * elhagyas;
            }
            kovJatekosMutat.Location =
                new Point(
                    (width - cellakSzelesseg) / 2 + cellakSzelesseg - kovJatekosMutat.Width / 2,
                    elhagyas
                );

            kovJatekosMutatKep.Location =
                new Point(
                    (width - cellakSzelesseg) / 2 + cellakSzelesseg - kovJatekosMutatKep.Width / 2,
                    elhagyas * 3 + kovJatekosMutat.Height + jatekosok.Height
                );

            jatekosok.Location =
                new Point(
                    (width - cellakSzelesseg) / 2 + cellakSzelesseg - jatekosok.Width / 2,
                    elhagyas * 2 + kovJatekosMutat.Height
                );

            for (int sor = 0; sor < meret; sor++)
            {
                for (int oszlop = 0; oszlop < meret; oszlop++)
                {
                    PictureBox cella = cellak[sor, oszlop];
                    cella.Size = new Size(cellameret, cellameret);
                    cella.Location = new Point(
                        oszlop * (cellameret + koz) + elhagyas,
                        sor * (cellameret + koz) + elhagyas
                    );
                }
            }
        }
        //itt tartunk

        private void cekkaKatt(object sender, EventArgs e)
        {
            PictureBox kattintott = sender as PictureBox;


            string[] tag = kattintott.Tag.ToString().Split('_');
            //tag[4] = "1";
            //kattintott.Tag = string.Join("_", tag);

            int sor = Convert.ToInt32(tag[0]);
            int oszlop = Convert.ToInt32(tag[1]);
            int ertek = Convert.ToInt32(tag[2]);
            if (ertek != 0)
                return;
            kattintott.Image = kepek[kiKov];
            ertek = kiKov;
            tag[2] = kiKov.ToString();
            tag[3] = kor.ToString();
            //kattintott.Tag = $"{sor}_{oszlop}_{ertek}_{kor}_0";
            kattintott.Tag = string.Join("_", tag);
            kattintottKord = $"{sor}_{oszlop}";
            jatekosTart[kiKov-1] += 1;

            for (int dbsor = 0; dbsor < meret; dbsor++)
            {
                for (int dboszlop = 0; dboszlop < meret; dboszlop++)
                {
                    int ujakt = Convert.ToInt32(cellak[dbsor, dboszlop].Tag.ToString().Split('_')[3]);
                    int ujertek = Convert.ToInt32(cellak[dbsor, dboszlop].Tag.ToString().Split('_')[2]);

                    if (ujakt < jatekosTart[kiKov - 1] - maxLerakott && ujertek == ertek)
                    {
                        cellak[dbsor, dboszlop].BackColor = Color.LightGray;
                        cellak[dbsor, dboszlop].Image = kepek[0];

                        cellak[dbsor, dboszlop].Tag = $"{dbsor}_{dboszlop}_0_0_0000";
                    }
                }
            }

            kiKov += 1;
            if (kiKov == jatekosSzam + 1)
            {
                kiKov = 1;
                kor++;               
            }
            //kovJatekosMutat.Text = "Következő játékos:\n" + jatekosNevek[kiKov];
            jatekosok.SelectedIndex = kiKov-1;
            kovJatekosMutatKep.Image = kepek[kiKov];

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
            teleEll();
        }

        private void teleEll()
        {
            for (int sor = 0; sor < meret; sor++)
            {
                for (int oszlop = 0; oszlop < meret; oszlop++)
                {
                    if (Convert.ToInt32(cellak[sor, oszlop].Tag.ToString().Split('_')[2]) == 0)
                        return;
                }
            };
            int max = pontszamok[0];
            foreach (int pont in pontszamok)
            {
                if (pont > max)
                { 
                    max = pont;
                }
            }
            
            if (max != 0)
            {
                string dontetlen = "";
                int dontetlenDb = 0;
                List<string> nevek = jatekosNevek;
                foreach (int pont in pontszamok)
                {
                    if (pont == max)
                    {
                        dontetlen += (dontetlen == ""?"":", ")+nevek[pontszamok.IndexOf(max)];
                        nevek.RemoveAt(pontszamok.IndexOf(max));
                        dontetlenDb++;
                    }
                }
                    MessageBox.Show("Nincs több lépés! " + dontetlen+(dontetlenDb == 1 ? " nyert!" :  " döntetlen!"));
            }
            else
                MessageBox.Show("Nincs több lépés! Nincs nyertes!");
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
                        int kijott = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[4]);
                        if (ellErtek == ertek && kijott == 0)
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
                    if (iranyDb[ind] + iranyDb[ind + 4] >= kijon)
                    {
                        //MessageBox.Show("Nyert a " + (ertek == 1 ? "kör" : ertek == 2 ? "X":"hiba") + " játékos!");
                        ellenorizveSzin.Clear();
                        //iranyDbSzin = new int[] { 1, 1, 1, 1, 0, 0, 0, 0 };
                        int szinSor = Convert.ToInt32(kattintottKord.Split('_')[0]);
                        int szinOszl = Convert.ToInt32(kattintottKord.Split('_')[1]);
                        cellaszinez(szinSor, szinOszl, ertek, iranyOK[ind]);
                        //MessageBox.Show("Nyert a " + ertek + " játékos!");
                        iranyDb[ind] = 0;
                        iranyDb[ind + 4] = 0;
                    }
                }
                
                if (!(s >= 0 && s < meret && o >= 0 && o < meret)) return;
                string kijott = cellak[s, o].Tag.ToString().Split('_')[4];
                int ellErtek = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]);
                //függőleges, jobb föl átló, vízszintes, jobb le átló

                int kijottNez = -1;
                if ((ellS == -1 && ellO == -1)|| (ellS == 1 && ellO == 1)) {
                    kijottNez = 3;
                }
                else if ((ellS == -1 && ellO == 0) || (ellS == 1 && ellO == 0))
                {
                    kijottNez = 0;
                }
                else if ((ellS == -1 && ellO == 1) || (ellS == 1 && ellO == -1))
                {
                    kijottNez = 1;
                }
                else if ((ellS == 0 && ellO == -1) || (ellS == 0 && ellO == 1))
                {
                    kijottNez = 2;
                }

                if (ellErtek == ertek && kijott[kijottNez] == '0')
                {
                    if (!ellenorizve.Contains(s + "_" + o))
                    {

                        //cellak[s, o].BackColor = Color.Red;
                        //cellak[sor, oszlop].BackColor = Color.Blue;
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

        private void cellaszinez(int sor, int oszlop, int ertek, string irany)
        {
            if (ellenorizveSzin.Contains(sor + "_" + oszlop))
            {
                return;
            }
            pontszamok[ertek] +=1;
            jatekosokKiir();
            ellenorizveSzin.Add((sor + "_" + oszlop));
            int ellS = Convert.ToInt32(irany.Split('_')[0]);
            int ellO = Convert.ToInt32(irany.Split('_')[1]);

            int s = sor;
            int o = oszlop;

            int ujertek;

            int tagS = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[0]);
            int tagO = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[1]);
            //cellak[sor, oszlop].BackColor = Color.Red;
            if (s >= 0 && s < meret && o >= 0 && o < meret)
            {
                ujertek = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]);
                
                while (ujertek == ertek)
                {
                    if (!(s >= 0 && s < meret && o >= 0 && o < meret)) break;
                    cellak[s, o].BackColor = vilagosit(szinek[ertek]);

                    string[] tag = cellak[s, o].Tag.ToString().Split('_');
                    int kijottNez = -1;
                    if ((ellS == -1 && ellO == -1) || (ellS == 1 && ellO == 1))
                    {
                        kijottNez = 3;
                    }
                    else if ((ellS == -1 && ellO == 0) || (ellS == 1 && ellO == 0))
                    {
                        kijottNez = 0;
                    }
                    else if ((ellS == -1 && ellO == 1) || (ellS == 1 && ellO == -1))
                    {
                        kijottNez = 1;
                    }
                    else if ((ellS == 0 && ellO == -1) || (ellS == 0 && ellO == 1))
                    {
                        kijottNez = 2;
                    }
                    string kijott = tag[4];
                    if (kijott[kijottNez] == '1') break;
                    kijott =kijott.Remove(kijottNez, 1).Insert(kijottNez, "1");
                    tag[4] = kijott;
                    cellak[s, o].Tag = string.Join("_", tag);

                    //cellak[s, o].Tag = $"{tagS}_{tagO}_0";
                    s = s + ellS;
                    o = o + ellO;
                    if (!(s >= 0 && s < meret && o >= 0 && o < meret)) break;
                    ujertek = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]);
                    /*
                    cellaszinez(s, o, ertek, irany);
                    irany = ((-ellS).ToString() + "_" + (-ellO).ToString());
                    cellaszinez(s, o, ertek, irany);*/
                    //Thread.Sleep(1000);

                }
            }
            s = sor;
            o = oszlop;
            irany = ((-ellS).ToString() + "_" + (-ellO).ToString());
            ellS = Convert.ToInt32(irany.Split('_')[0]);
            ellO = Convert.ToInt32(irany.Split('_')[1]);
            ujertek = ertek;
            bool elso = true;
            while (ujertek == ertek)
            {
                if (!(s >= 0 && s < meret && o >= 0 && o < meret)) break;
                if (Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]) == ertek)
                {
                    cellak[s, o].BackColor = vilagosit(szinek[ertek]);
                    //cellak[s, o].Tag = $"{tagS}_{tagO}_0";
                    string[] tag = cellak[s, o].Tag.ToString().Split('_');
                    int kijottNez = -1;
                    if ((ellS == -1 && ellO == -1) || (ellS == 1 && ellO == 1))
                    {
                        kijottNez = 3;
                    }
                    else if ((ellS == -1 && ellO == 0) || (ellS == 1 && ellO == 0))
                    {
                        kijottNez = 0;
                    }
                    else if ((ellS == -1 && ellO == 1) || (ellS == 1 && ellO == -1))
                    {
                        kijottNez = 1;
                    }
                    else if ((ellS == 0 && ellO == -1) || (ellS == 0 && ellO == 1))
                    {
                        kijottNez = 2;
                    }
                    string kijott = tag[4];
                    if (kijott[kijottNez] == '1' && !elso) break;
                    elso = false;
                    kijott = kijott.Remove(kijottNez, 1).Insert(kijottNez, "1");
                    tag[4] = kijott;
                    cellak[s, o].Tag = string.Join("_", tag);
                }

                s = s + ellS;
                o = o + ellO;
                if (!(s >= 0 && s < meret && o >= 0 && o < meret)) break;
                ujertek = Convert.ToInt32(cellak[s, o].Tag.ToString().Split('_')[2]);
                /*
                cellaszinez(s, o, ertek, irany);
                irany = ((-ellS).ToString() + "_" + (-ellO).ToString());
                cellaszinez(s, o, ertek, irany);*/

            }
        }

        private Color vilagosit(Color color)
        {
            int r = color.R/2;
            int g = color.G/2;
            int b = color.B/2;
            return Color.FromArgb(r, g, b);
        }

        //binárissá:
        //Convert.ToString(be, 2)
        //decimálissá:
        //Convert.ToInt32(be, 2);
    }
}
