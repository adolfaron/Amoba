using System;
using System.Drawing;
using System.Windows.Forms;

namespace Amoba
{
    public partial class skinek : Form
    {
        public string JatekosNev { get; private set; }
        public Color ValasztottSzin { get; private set; }

        public skinek()
        {
            InitializeComponent();
        }

        private void szinValasztas_Click(object sender, EventArgs e)
        {
            ColorDialog szinValaszto = new ColorDialog();
            if (szinValaszto.ShowDialog() == DialogResult.OK)
            {
                ValasztottSzin = szinValaszto.Color;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(jatekosNeve.Text))
            {
                MessageBox.Show("Add meg a játékos nevét!");
                return;
            }

            JatekosNev = jatekosNeve.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
