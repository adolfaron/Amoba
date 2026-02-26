
using System.Windows.Forms;

namespace Amoba
{
    partial class jatekter1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            kiir = new RichTextBox();
            SuspendLayout();
            // 
            // kiir
            // 
            kiir.Location = new Point(548, 7);
            kiir.Margin = new Padding(2);
            kiir.Name = "kiir";
            kiir.Size = new Size(329, 270);
            kiir.TabIndex = 0;
            kiir.Text = "";
            kiir.Visible = false;
            // 
            // jatekter1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 529);
            Controls.Add(kiir);
            Name = "jatekter1";
            Text = "jatekter1";
            Resize += meretez;
            ResumeLayout(false);



        }

        private void meretez(object sender, EventArgs e)
        {
            this.elhelyezesSzamol();
        }

        #endregion

        private RichTextBox kiir;
    }
}