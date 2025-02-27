namespace Delivery.Operators
{
    partial class ChangeFlight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeFlight));
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label7 = new Label();
            dateTimePicker2 = new DateTimePicker();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 370);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(529, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(55, 24);
            toolStripButton1.Text = "Назад";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(159, 303);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 46;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 3;
            numericUpDown1.Location = new Point(186, 233);
            numericUpDown1.Margin = new Padding(3, 4, 3, 4);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(137, 27);
            numericUpDown1.TabIndex = 45;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(186, 169);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 44;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(185, 204);
            label5.Name = "label5";
            label5.Size = new Size(47, 22);
            label5.TabIndex = 43;
            label5.Text = "Вес:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(187, 140);
            label6.Name = "label6";
            label6.Size = new Size(99, 22);
            label6.TabIndex = 42;
            label6.Text = "Тип груза:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(186, 12);
            label4.Name = "label4";
            label4.Size = new Size(129, 22);
            label4.TabIndex = 41;
            label4.Text = "Дата отравки:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(186, 41);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(228, 27);
            dateTimePicker1.TabIndex = 40;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(0, 151);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(135, 20);
            textBox3.TabIndex = 39;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(0, 121);
            label3.Name = "label3";
            label3.Size = new Size(149, 22);
            label3.TabIndex = 38;
            label3.Text = "Конечная точка:";
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(0, 96);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(135, 20);
            textBox2.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(0, 67);
            label2.Name = "label2";
            label2.Size = new Size(159, 22);
            label2.TabIndex = 36;
            label2.Text = "Отправная точка:";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(0, 41);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(135, 20);
            textBox1.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(0, 12);
            label1.Name = "label1";
            label1.Size = new Size(96, 22);
            label1.TabIndex = 34;
            label1.Text = "Название:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(185, 76);
            label7.Name = "label7";
            label7.Size = new Size(129, 22);
            label7.TabIndex = 48;
            label7.Text = "Дата отравки:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(187, 105);
            dateTimePicker2.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(228, 27);
            dateTimePicker2.TabIndex = 47;
            // 
            // ChangeFlight
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 397);
            Controls.Add(label7);
            Controls.Add(dateTimePicker2);
            Controls.Add(button1);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(toolStrip1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChangeFlight";
            Text = "ChangeFlight";
            Load += ChangeFlight_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private Button button1;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox1;
        private Label label5;
        private Label label6;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Label label7;
        private DateTimePicker dateTimePicker2;
    }
}