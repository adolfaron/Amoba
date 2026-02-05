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
            label3 = new Label();
            szinValasztas = new Button();
            ok = new Button();
            szinKi = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 58);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(121, 25);
            label1.TabIndex = 0;
            label1.Text = "Játékos neve: ";
            // 
            // jatekosNeve
            // 
            jatekosNeve.Location = new Point(154, 58);
            jatekosNeve.Margin = new Padding(4, 5, 4, 5);
            jatekosNeve.Name = "jatekosNeve";
            jatekosNeve.Size = new Size(171, 31);
            jatekosNeve.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 128);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(105, 25);
            label2.TabIndex = 2;
            label2.Text = "Szimbólum:";
            // 
            // szimbolum
            // 
            szimbolum.DrawMode = DrawMode.OwnerDrawFixed;
            szimbolum.DropDownStyle = ComboBoxStyle.DropDownList;
            szimbolum.FormattingEnabled = true;
            szimbolum.Location = new Point(154, 128);
            szimbolum.Margin = new Padding(4, 5, 4, 5);
            szimbolum.Name = "szimbolum";
            szimbolum.Size = new Size(171, 32);
            szimbolum.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 202);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(47, 25);
            label3.TabIndex = 4;
            label3.Text = "Szín:";
            // 
            // szinValasztas
            // 
            szinValasztas.Location = new Point(154, 195);
            szinValasztas.Margin = new Padding(4, 5, 4, 5);
            szinValasztas.Name = "szinValasztas";
            szinValasztas.Size = new Size(173, 38);
            szinValasztas.TabIndex = 5;
            szinValasztas.Text = "Szín kiválasztása";
            szinValasztas.UseVisualStyleBackColor = true;
            szinValasztas.Click += szinValasztas_Click;
            // 
            // ok
            // 
            ok.Location = new Point(271, 264);
            ok.Margin = new Padding(4, 5, 4, 5);
            ok.Name = "ok";
            ok.Size = new Size(54, 48);
            ok.TabIndex = 6;
            ok.Text = "OK";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click;
            // 
            // szinKi
            // 
            szinKi.Location = new Point(151, 266);
            szinKi.Name = "szinKi";
            szinKi.Size = new Size(53, 46);
            szinKi.TabIndex = 7;
            // 
            // skinek
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 347);
            Controls.Add(szinKi);
            Controls.Add(ok);
            Controls.Add(szinValasztas);
            Controls.Add(label3);
            Controls.Add(szimbolum);
            Controls.Add(label2);
            Controls.Add(jatekosNeve);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "skinek";
            Text = "skinek";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox jatekosNeve;
        private Label label2;
        private ComboBox szimbolum;
        private Label label3;
        private Button szinValasztas;
        private Button ok;
        private Panel szinKi;
    }
}