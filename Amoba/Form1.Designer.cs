namespace Amoba
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            ujJatekosBTN = new Button();
            jatekosokLB = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(380, 273);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(107, 38);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ujJatekosBTN
            // 
            ujJatekosBTN.Location = new Point(576, 273);
            ujJatekosBTN.Margin = new Padding(4, 5, 4, 5);
            ujJatekosBTN.Name = "ujJatekosBTN";
            ujJatekosBTN.Size = new Size(107, 38);
            ujJatekosBTN.TabIndex = 1;
            ujJatekosBTN.Text = "Új játékos";
            ujJatekosBTN.UseVisualStyleBackColor = true;
            ujJatekosBTN.Click += ujJatekos_Click;
            // 
            // jatekosokLB
            // 
            jatekosokLB.Location = new Point(473, 341);
            jatekosokLB.Name = "jatekosokLB";
            jatekosokLB.Size = new Size(150, 25);
            jatekosokLB.TabIndex = 3;
            jatekosokLB.Text = "Játékosok:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(jatekosokLB);
            Controls.Add(ujJatekosBTN);
            Controls.Add(button1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Amőba";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button ujJatekosBTN;
        private Label jatekosokLB;
    }
}
