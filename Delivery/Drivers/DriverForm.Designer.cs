namespace Delivery.Driver
{
    partial class DriverForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverForm));
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(140, 216);
            button3.Name = "button3";
            button3.Size = new Size(260, 29);
            button3.TabIndex = 2;
            button3.Text = "Редактировать профиль";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(173, 103);
            button1.Name = "button1";
            button1.Size = new Size(201, 29);
            button1.TabIndex = 3;
            button1.Text = "Текущий Заказ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(173, 159);
            button2.Name = "button2";
            button2.Size = new Size(201, 29);
            button2.TabIndex = 4;
            button2.Text = "Свободные Заказы";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // DriverForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(605, 521);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button3);
            Name = "DriverForm";
            Text = "DriverForm";
            Load += DriverForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button3;
        private Button button1;
        private Button button2;
    }
}