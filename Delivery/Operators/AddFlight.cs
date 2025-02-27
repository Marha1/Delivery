using Delivery.Models;
using Delivery.Primitives;
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
    public partial class AddFlight : Form
    {
        private TypeOfCargo _typeOfCargo;
        public AddFlight()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            CheckFlyght checkFlyght = new CheckFlyght();
            checkFlyght.Show();
        }

        private void AddFlight_Load(object sender, EventArgs e)
        {
            var cargoTypes = Enum.GetValues(typeof(TypeOfCargo));
            comboBox1.DataSource = cargoTypes;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             _typeOfCargo = (TypeOfCargo)comboBox1.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            
            using (ApplicationContext _context = new ApplicationContext())
            {

                    Flight flight = new Flight()
                    {
                        Name = textBox1.Text,
                        StartingPoint = textBox2.Text,
                        EndPoint = textBox3.Text,
                        DispatchDate = dateTimePicker1.Value.ToUniversalTime(),
                    };
                    _context.Flights.Add(flight);
                    _context.SaveChanges();
                    Cargo cargo = new Cargo()
                {
                    type = _typeOfCargo,
                    Weight = (double)numericUpDown1.Value,
                    FlightId=flight.Id
                   
                };
                _context.Cargos.Add(cargo);
                _context.SaveChanges();
                    MessageBox.Show("Добавлено!");
            }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
