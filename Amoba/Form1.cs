namespace Amoba
{
    public partial class Form1 : Form
    {
        int meret = 30;
        int jatekosSzam =2;
        List<string> jatekosNevek = new List<string> { "Üres", "Kör", "X" , "Háromszög"};
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jatekter1 ujjatek = new jatekter1(meret, jatekosSzam, jatekosNevek);
            ujjatek.ShowDialog(); try
            {
                this.Show();
            }
            catch (Exception) 
            {
                Application.Exit(); 
            };
        }
    }
}
