namespace Amoba
{
    public partial class Form1 : Form
    {
        int meret = 10;

        int kijon = 3;
        //List<string> jatekosNevek = new List<string> { "Üres", "Kör", "X", "Háromszög" };
        List<List<object>> jatekosok = new List<List<object>>()
        {
            new List<object> { "Üres", Color.White, Image.FromFile("img/ures.png"), -1},
            new List<object> { "Kör", Color.Blue, Image.FromFile("img/szimbolumok/1kor.png"), 0 },
            new List<object> { "X", Color.Red, Image.FromFile("img/szimbolumok/2x.png"), 1 }
        };
        //List<string> kepekUt = new List<string> { "img/ures.png", "img/szimbolumok/kor.png", "img/szimbolumok/x.png", "img/szimbolumok/haromszog.png" };

        List<Label> jatekosLBL = new List<Label>();
        public Form1()
        {
            InitializeComponent();
            jatekosokKiir();
            lerakotmax.Visible= false;
            radioButton2.Checked = true;
        }


        private void start_Click(object sender, EventArgs e)
        {
            if (jatekosok.Count <= 1)
            {
                MessageBox.Show("Kérem adjon hozzá játékosokat!");
                return;
            }
            List<Image> kepek = new List<Image>();

            for (int i = 0; i < jatekosok.Count; i++)
            {
                Image kep = (Image)jatekosok[i][2];
                kep = kepSzinez(kep, (Color)jatekosok[i][1]);
                kepek.Add(kep);
            }

            meret = (int)merete.Value;
            int lerakotmaxx;
            if (radioButton1.Checked)
            {
                lerakotmaxx = (int)lerakotmax.Value;
            }
            else { lerakotmaxx = meret*meret; }

            List<string> jatekosNevek = jatekosok.Select(j => (string)j[0]).ToList();
            List<Color> szinek = jatekosok.Select(j => (Color)j[1]).ToList();

            jatekter1 ujjatek = new jatekter1(meret, jatekosNevek, kepek, szinek, kijon, lerakotmaxx);
            ujjatek.ShowDialog();
            try
            {
                this.Show();
            }
            catch (Exception)
            {
                Application.Exit();
            }
            ;
        }
        public static Image kepSzinez(Image inputImage, Color ujSzin)
        {
            Bitmap input = new Bitmap(inputImage);
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    Color c = input.GetPixel(x, y);

                    // Csak ahol nem átlátszó
                    if (c.A > 0)
                    {
                        float brightness = c.GetBrightness();

                        Color tinted = Color.FromArgb(
                            c.A,
                            (int)(ujSzin.R * brightness),
                            (int)(ujSzin.G * brightness),
                            (int)(ujSzin.B * brightness)
                        );

                        output.SetPixel(x, y, tinted);
                    }
                    else
                    {
                        output.SetPixel(x, y, Color.Transparent);
                    }
                }
            }

            return output;
        }

        private void ujJatekos_Click(object sender, EventArgs e)
        {
            skinek ablak = new skinek(this);
            ablak.ShowDialog();

        }
        public void ujJatekos(string nev, Color szin, Image kep, int index)
        {
            //MessageBox.Show(index.ToString());
            // Ha a lista üres, nincs duplikáció
            if (jatekosok.Count > 0)
            {
                bool marVan = jatekosok.Any(j =>
                    ((string)j[0] == nev) ||
                    ((Color)j[1] == szin) ||
                    ((int)j[3] == index)
                );

                if (marVan)
                {
                    MessageBox.Show("Ez a játékos már létezik!");
                    return;
                }
            }

            // Hozzáadás
            jatekosok.Add(new List<object> { nev, szin, kep, index });

            // Frissítés
            jatekosokKiir();
        }


        private void jatekosokKiir()
        {
            int elhagyas = 3;
            while (jatekosLBL.Count > 0)
            {
                Label lbl = jatekosLBL[0];
                this.Controls.Remove(lbl);
                lbl.Dispose();          // erőforrás felszabadítása
                jatekosLBL.RemoveAt(0);
            }

            for (int i = 1; i < jatekosok.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = (string)jatekosok[i][0];
                lbl.Size = new Size(jatekosokLB.Width, jatekosokLB.Height);
                lbl.Location = new Point(jatekosokLB.Location.X,
                                        jatekosokLB.Location.Y + jatekosokLB.Height + elhagyas + (i - 1) * (lbl.Height + elhagyas));
                lbl.Click += new EventHandler(jatekosTorol);
                Color bg = (Color)jatekosok[i][1];
                lbl.ForeColor = bg;
                int brightness = (int)((bg.R * 0.299) + (bg.G * 0.587) + (bg.B * 0.114));
                lbl.BackColor = (brightness < 128) ? SystemColors.Control : Color.Black;
                jatekosLBL.Add(lbl);
                this.Controls.Add(lbl);
                //jatekosok.Items.Add(jatekosNevek[i]);
            }
        }

        private void jatekosTorol(object sender, EventArgs e)
        {
            if (sender is not Label lbl) return;

            DialogResult result = MessageBox.Show(
                "Biztosan törlöd a játékost?",
                "Törlés",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                // Megkeressük a label indexét a jatekosLBL listában
                int index = jatekosLBL.IndexOf(lbl) + 1;
                if (index >= 0 && index < jatekosok.Count)
                {
                    jatekosok.RemoveAt(index);
                    jatekosokKiir();
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                start_Click(this, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                lerakotmax.Visible = true;
            }
            else
            {
                lerakotmax.Visible = false;
            }
        }
    }
}

