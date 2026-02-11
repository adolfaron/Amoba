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
            merete = new NumericUpDown();
            label1 = new Label();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            lerakotmax = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)merete).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lerakotmax).BeginInit();
            SuspendLayout();
            // 
            // start
            // 
            start.Location = new Point(354, 149);
            start.Name = "start";
            start.Size = new Size(96, 44);
            start.TabIndex = 0;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // ujJatekosBTN
            // 
            ujJatekosBTN.Location = new Point(365, 199);
            ujJatekosBTN.Name = "ujJatekosBTN";
            ujJatekosBTN.Size = new Size(75, 23);
            ujJatekosBTN.TabIndex = 1;
            ujJatekosBTN.Text = "Új játékos";
            ujJatekosBTN.UseVisualStyleBackColor = true;
            ujJatekosBTN.Click += ujJatekos_Click;
            // 
            // jatekosokLB
            // 
            jatekosokLB.Location = new Point(354, 248);
            jatekosokLB.Margin = new Padding(2, 0, 2, 0);
            jatekosokLB.Name = "jatekosokLB";
            jatekosokLB.Size = new Size(105, 15);
            jatekosokLB.TabIndex = 3;
            jatekosokLB.Text = "Játékosok:";
            // 
            // merete
            // 
            merete.Location = new Point(546, 199);
            merete.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            merete.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            merete.Name = "merete";
            merete.Size = new Size(120, 23);
            merete.TabIndex = 4;
            merete.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(546, 164);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 5;
            label1.Text = "játéktér mérete:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(49, 149);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 100);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Legyen max vagy nem?";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(31, 75);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(49, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "nem";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(31, 38);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(48, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "igen";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // lerakotmax
            // 
            lerakotmax.Location = new Point(60, 264);
            lerakotmax.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            lerakotmax.Name = "lerakotmax";
            lerakotmax.Size = new Size(120, 23);
            lerakotmax.TabIndex = 7;
            lerakotmax.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lerakotmax);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(merete);
            Controls.Add(jatekosokLB);
            Controls.Add(ujJatekosBTN);
            Controls.Add(start);
            Name = "Form1";
            Text = "Amőba";
            ((System.ComponentModel.ISupportInitialize)merete).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lerakotmax).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button start;
        private Button ujJatekosBTN;
        private Label jatekosokLB;
        private NumericUpDown merete;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private NumericUpDown lerakotmax;
    }
}
