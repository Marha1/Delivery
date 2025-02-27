using Delivery.Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery.Driver
{
    public partial class DriverForm : Form
    {
        private static Models.Driver _loginDriverId;
        public DriverForm(Models.Driver id)
        {
            InitializeComponent();
            _loginDriverId = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_loginDriverId.FlightId == null || _loginDriverId.FlightId == 0)
            {
                FreeFlyght free = new FreeFlyght(_loginDriverId);
                free.Show();
            }
            else
            {
                MessageBox.Show("Вы не можете взять новый заказ, пока не закончили старый", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            CurrentFlight currentFlight = new CurrentFlight(_loginDriverId);
            currentFlight.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeDataDriver changeDataDriver = new ChangeDataDriver(_loginDriverId);
            changeDataDriver.Show();
        }
    }
}
