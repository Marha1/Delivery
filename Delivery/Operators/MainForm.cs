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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            СheckDrivers сheckDrivers = new СheckDrivers();
            сheckDrivers.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            CheckFlyght checkFlyght = new CheckFlyght();
            checkFlyght.Show();
        }
    }
}
