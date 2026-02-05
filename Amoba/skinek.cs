using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Amoba
{
    public partial class skinek : Form
    {
        string JatekosNev;
        Color ValasztottSzin;
        Form1 foAblak;
        List<string> kepekUt = new List<string>();
        List<Image> kepek = new List<Image>();
        bool valasztottSzint = false;

        public skinek(Form1 form1)
        {
            InitializeComponent();
            foAblak = form1;

            string futtatasiMappa = AppDomain.CurrentDomain.BaseDirectory;

            // A "kepek" mappa elérési útja
            string kepekMappa = Path.Combine(futtatasiMappa, "img/szimbolumok");

            // Ellenőrizzük, hogy létezik-e a mappa
            if (!Directory.Exists(kepekMappa))
            {
                MessageBox.Show("A 'kepek' mappa nem található itt: " + kepekMappa);
                return;
            }

            string[] kiterjesztesek = { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };

            // Az összes képfájl lekérése
            kepekUt = Directory
                .GetFiles(kepekMappa, "*.*", SearchOption.TopDirectoryOnly)
                .Where(f => kiterjesztesek.Contains(Path.GetExtension(f).ToLower()))
                .OrderBy(f => Path.GetFileName(f))
                .ToList();


            if (kepekUt.Count == 0)
            {
                MessageBox.Show("Nem találhatók képek!");
                return;
            }



            // Képek és szöveg tárolása
            /* List<Tuple<string, Image>> elemek = new List<Tuple<string, Image>>()
             {
                 Tuple.Create("X", Image.FromFile("img/x.png")),
                 Tuple.Create("Kör", Image.FromFile("img/kor.png")),
                 Tuple.Create("Háromszög", Image.FromFile("img/haromszog.png"))
             };*/

            // Feltöltés a ComboBox-ba
            kepek.Clear();
            foreach (string ut in kepekUt)
            {
                kepek.Add(Image.FromFile(ut));
                szimbolum.Items.Add(InvertImage(Image.FromFile(ut)));
            }
            // Rajzolás esemény
            szimbolum.DrawItem += (s, e) =>
            {
                if (e.Index < 0) return;

                Image img = (Image)szimbolum.Items[e.Index];

                e.DrawBackground();
                e.Graphics.DrawImage(img, e.Bounds.Left, e.Bounds.Top, 20, 20);
                e.DrawFocusRectangle();
            };

        }

        private void szinValasztas_Click(object sender, EventArgs e)
        {
            ColorDialog szinValaszto = new ColorDialog();
            if (szinValaszto.ShowDialog() == DialogResult.OK)
            {
                ValasztottSzin = szinValaszto.Color;
                szinKi.BackColor = ValasztottSzin;
                valasztottSzint = true;

            }
            
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(jatekosNeve.Text))
            {
                MessageBox.Show("Add meg a játékos nevét!");
                return;
            }
            if (szimbolum.SelectedIndex == -1)
            {
                MessageBox.Show("Válassz egy szimbólumot!");
                return;
            }
            if (!valasztottSzint)
            {
                MessageBox.Show("Válassz egy színt!");
                return;
            }
            Image kivantKep = kepek[szimbolum.SelectedIndex];

            JatekosNev = jatekosNeve.Text;
            foAblak.ujJatekos(JatekosNev, ValasztottSzin, kivantKep, szimbolum.SelectedIndex);
            this.Close();
        }
        public static Image InvertImage(Image inputImage)
        {
            Bitmap bmp = new Bitmap(inputImage);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    Color inverted = Color.FromArgb(c.A, 255 - c.R, 255 - c.G, 255 - c.B);
                    bmp.SetPixel(x, y, inverted);
                }
            }

            return bmp;
        }

    }
}
