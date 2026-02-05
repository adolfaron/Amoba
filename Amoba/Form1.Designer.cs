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
            start = new Button();
            ujJatekosBTN = new Button();
            jatekosokLB = new Label();
            SuspendLayout();
            // 
            // start
            // 
            start.Location = new Point(313, 151);
            start.Name = "start";
            start.Size = new Size(96, 44);
            start.TabIndex = 0;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // ujJatekosBTN
            // 
            ujJatekosBTN.Location = new Point(324, 201);
            ujJatekosBTN.Name = "ujJatekosBTN";
            ujJatekosBTN.Size = new Size(75, 23);
            ujJatekosBTN.TabIndex = 1;
            ujJatekosBTN.Text = "Új játékos";
            ujJatekosBTN.UseVisualStyleBackColor = true;
            ujJatekosBTN.Click += ujJatekos_Click;
            // 
            // jatekosokLB
            // 
            jatekosokLB.Location = new Point(313, 250);
            jatekosokLB.Margin = new Padding(2, 0, 2, 0);
            jatekosokLB.Name = "jatekosokLB";
            jatekosokLB.Size = new Size(105, 15);
            jatekosokLB.TabIndex = 3;
            jatekosokLB.Text = "Játékosok:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(jatekosokLB);
            Controls.Add(ujJatekosBTN);
            Controls.Add(start);
            Name = "Form1";
            Text = "Amőba";
            ResumeLayout(false);
        }

        #endregion

        private Button start;
        private Button ujJatekosBTN;
        private Label jatekosokLB;
    }
}
