namespace Amoba
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jatekter1 ujjatek=new jatekter1();
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
