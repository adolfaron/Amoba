
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
            kiir.Location = new Point(783, 12);
            kiir.Name = "kiir";
            kiir.Size = new Size(468, 448);
            kiir.TabIndex = 0;
            kiir.Text = "";
            kiir.Visible = false;
            // 
            // jatekter1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1263, 1050);
            Controls.Add(kiir);
            Margin = new Padding(4, 5, 4, 5);
            Name = "jatekter1";
            Text = "jatekter1";
            Load += jatekter1_Load;
            this.Resize += new System.EventHandler(this.meretez);
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