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
                }
            }
        }
    }
}
