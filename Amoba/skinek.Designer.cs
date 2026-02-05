namespace Amoba
{
    partial class skinek
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
            label1 = new Label();
            jatekosNeve = new TextBox();
            label2 = new Label();
            szimbolum = new ComboBox();
            szinValasztas = new Button();
            ok = new Button();
            jatekosSzimb = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)jatekosSzimb).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 35);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Játékos neve: ";
            // 
            // jatekosNeve
            // 
            jatekosNeve.Location = new Point(108, 35);
            jatekosNeve.Name = "jatekosNeve";
            jatekosNeve.Size = new Size(156, 23);
            jatekosNeve.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 77);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 2;
            label2.Text = "Szimbólum:";
            // 
            // szimbolum
            // 
            szimbolum.DrawMode = DrawMode.OwnerDrawFixed;
            szimbolum.DropDownStyle = ComboBoxStyle.DropDownList;
            szimbolum.FormattingEnabled = true;
            szimbolum.ItemHeight = 44;
            szimbolum.Location = new Point(108, 77);
            szimbolum.Name = "szimbolum";
            szimbolum.Size = new Size(64, 50);
            szimbolum.TabIndex = 3;
            szimbolum.SelectedIndexChanged += szimbolum_SelectedIndexChanged;
            // 
            // szinValasztas
            // 
            szinValasztas.Location = new Point(178, 77);
            szinValasztas.Name = "szinValasztas";
            szinValasztas.Size = new Size(86, 50);
            szinValasztas.TabIndex = 5;
            szinValasztas.Text = "Szín kiválasztása";
            szinValasztas.UseVisualStyleBackColor = true;
            szinValasztas.Click += szinValasztas_Click;
            // 
            // ok
            // 
            ok.Location = new Point(190, 158);
            ok.Name = "ok";
            ok.Size = new Size(38, 29);
            ok.TabIndex = 6;
            ok.Text = "OK";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click;
            // 
            // jatekosSzimb
            // 
            jatekosSzimb.Location = new Point(108, 137);
            jatekosSzimb.Name = "jatekosSzimb";
            jatekosSzimb.Size = new Size(64, 64);
            jatekosSzimb.SizeMode = PictureBoxSizeMode.StretchImage;
            jatekosSzimb.TabIndex = 7;
            jatekosSzimb.TabStop = false;
            // 
            // skinek
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(276, 208);
            Controls.Add(jatekosSzimb);
            Controls.Add(ok);
            Controls.Add(szinValasztas);
            Controls.Add(szimbolum);
            Controls.Add(label2);
            Controls.Add(jatekosNeve);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "skinek";
            Text = "skinek";
            ((System.ComponentModel.ISupportInitialize)jatekosSzimb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox jatekosNeve;
        private Label label2;
        private ComboBox szimbolum;
        private Button szinValasztas;
        private Button ok;
        private PictureBox jatekosSzimb;
    }
}