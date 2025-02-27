using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery
{
    public partial class CancelForm : Form
    {
        private TextBox txtCancelCode;
        private Button btnOk;
        private Button btnCancel;
        public string CancelCode { get; private set; }
        public CancelForm()
        {
            InitializeComponent();
            this.Text = "Введите код отмены";
            this.Size = new System.Drawing.Size(300, 150);
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblPrompt = new Label
            {
                Text = "Введите код отмены:",
                AutoSize = true,
                Location = new System.Drawing.Point(10, 10)
            };
            this.Controls.Add(lblPrompt);

            txtCancelCode = new TextBox
            {
                Location = new System.Drawing.Point(10, 30),
                Width = 260,
                PasswordChar = '*'
            };
            this.Controls.Add(txtCancelCode);

            btnOk = new Button
            {
                Text = "OK",
                Location = new System.Drawing.Point(120, 70),
                DialogResult = DialogResult.OK
            };
            btnOk.Click += (s, e) => { this.CancelCode = txtCancelCode.Text; };
            this.Controls.Add(btnOk);

            btnCancel = new Button
            {
                Text = "Отмена",
                Location = new System.Drawing.Point(200, 70),
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        private void CancelForm_Load(object sender, EventArgs e)
        {

        }
    }
}
