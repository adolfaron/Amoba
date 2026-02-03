namespace Amoba
{
    public partial class Form1 : Form
    {
        int meret = 30;
        int jatekosSzam = 2;
        List<string> jatekosNevek = new List<string> { "Üres", "Kör", "X", "Háromszög" };
        List<string> kepekUt = new List<string> { "img/ures.png", "img/kor.png", "img/x.png", "img/haromszog.png" };
        List<Color> szinek = new List<Color> { Color.White, Color.Blue, Color.Yellow, Color.YellowGreen };
        List<Image> kepek = new List<Image>();
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            kepek.Clear();
            for (int i = 0; i < kepekUt.Count; i++)
            {
                Image kep = Image.FromFile(kepekUt[i]);
                kep = kepSzinez(kep, szinek[i]);
                kepek.Add(kep);
            }
            

            jatekter1 ujjatek = new jatekter1(meret, jatekosSzam, jatekosNevek, kepek);
            ujjatek.ShowDialog(); try
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
            ColorDialog szinValaszto = new ColorDialog();
            if (szinValaszto.ShowDialog() == DialogResult.OK)
            {
                Color valasztottSzin = szinValaszto.Color;
                // Ezt elmentheted a játékos színlistájába
            }
        }
    }
}
