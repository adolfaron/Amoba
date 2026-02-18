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
            label2 = new Label();
            kijonBe = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)merete).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lerakotmax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kijonBe).BeginInit();
            SuspendLayout();
            // 
            // start
            // 
            start.Location = new Point(506, 248);
            start.Margin = new Padding(4, 5, 4, 5);
            start.Name = "start";
            start.Size = new Size(137, 73);
            start.TabIndex = 0;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // ujJatekosBTN
            // 
            ujJatekosBTN.Location = new Point(521, 332);
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
            jatekosokLB.Location = new Point(506, 413);
            jatekosokLB.Name = "jatekosokLB";
            jatekosokLB.Size = new Size(150, 25);
            jatekosokLB.TabIndex = 3;
            jatekosokLB.Text = "Játékosok:";
            // 
            // merete
            // 
            merete.Location = new Point(780, 311);
            merete.Margin = new Padding(4, 5, 4, 5);
            merete.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            merete.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            merete.Name = "merete";
            merete.Size = new Size(134, 31);
            merete.TabIndex = 4;
            merete.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(780, 272);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(134, 25);
            label1.TabIndex = 5;
            label1.Text = "játéktér mérete:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(70, 248);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(213, 128);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Legyen max vagy nem?";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(32, 83);
            radioButton2.Margin = new Padding(4, 5, 4, 5);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(72, 29);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "nem";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(33, 44);
            radioButton1.Margin = new Padding(4, 5, 4, 5);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(71, 29);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "igen";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // lerakotmax
            // 
            lerakotmax.Location = new Point(93, 386);
            lerakotmax.Margin = new Padding(4, 5, 4, 5);
            lerakotmax.Maximum = new decimal(new int[] { 900, 0, 0, 0 });
            lerakotmax.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            lerakotmax.Name = "lerakotmax";
            lerakotmax.Size = new Size(171, 31);
            lerakotmax.TabIndex = 7;
            lerakotmax.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(291, 272);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(154, 25);
            label2.TabIndex = 9;
            label2.Text = "sor mérete (kijön):";
            // 
            // kijonBe
            // 
            kijonBe.Location = new Point(291, 311);
            kijonBe.Margin = new Padding(4, 5, 4, 5);
            kijonBe.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            kijonBe.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            kijonBe.Name = "kijonBe";
            kijonBe.Size = new Size(154, 31);
            kijonBe.TabIndex = 8;
            kijonBe.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(label2);
            Controls.Add(kijonBe);
            Controls.Add(lerakotmax);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(merete);
            Controls.Add(jatekosokLB);
            Controls.Add(ujJatekosBTN);
            Controls.Add(start);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Amőba";
            ((System.ComponentModel.ISupportInitialize)merete).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lerakotmax).EndInit();
            ((System.ComponentModel.ISupportInitialize)kijonBe).EndInit();
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
        private Label label2;
        private NumericUpDown kijonBe;
    }
}
