
namespace Delivery
{
    partial class CheckFlyght
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckFlyght));
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(839, 221);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(0, 227);
            button1.Name = "button1";
            button1.Size = new Size(125, 23);
            button1.TabIndex = 1;
            button1.Text = "Добавить заказ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(189, 227);
            button2.Name = "button2";
            button2.Size = new Size(145, 23);
            button2.TabIndex = 2;
            button2.Text = "Изменить заказ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(415, 227);
            button3.Name = "button3";
            button3.Size = new Size(117, 23);
            button3.TabIndex = 3;
            button3.Text = "Удалить заказ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(604, 227);
            button4.Name = "button4";
            button4.Size = new Size(221, 23);
            button4.TabIndex = 4;
            button4.Text = "Выдать свободному водителю";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 329);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(837, 25);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(43, 22);
            toolStripButton1.Text = "Назад";
            toolStripButton1.Click += toolStripButton1_Click_1;
            // 
            // CheckFlyght
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 354);
            Controls.Add(toolStrip1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "CheckFlyght";
            Text = "Просмотр Заказов";
            Load += CheckFlyght_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
    }
}