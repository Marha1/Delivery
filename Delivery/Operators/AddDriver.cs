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
    public partial class AddDriver : Form
    {
        private Generate gener = new Generate();
        public AddDriver()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext _context = new ApplicationContext())
                {
                    string login = textBox1.Text + textBox2.Text;
                    string loginInLatin = gener.TransliterateToLatin(login);
                    Auth auth = new Auth()
                    {
                        Login = loginInLatin,
                        Password =gener.GeneratePassport(),
                        Role = Primitives.Role.User
                    };
                    _context.Auths.Add(auth);
                    _context.SaveChanges(); // Сохраняем изменения, чтобы получить Id для Auth

                    Models.Driver driver = new Models.Driver()
                    {
                        Name = textBox1.Text,
                        Surname = textBox2.Text,
                        LastName = textBox3.Text,
                        Age = (int)numericUpDown1.Value,
                        Experience = (int)numericUpDown2.Value,
                        AuthId = auth.Id,
                        PassNumber = textBox4.Text,
                        LicenseNumber = textBox5.Text,
                        CancelPassword = gener.GeneratePassport(),
                    };

                    _context.Drivers.Add(driver);
                    _context.SaveChanges();
                    MessageBox.Show("Успешно Добавлен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте правильность введенных данных!");
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            СheckDrivers сheckDrivers = new СheckDrivers();
            сheckDrivers.Show();
        }

        private void AddDriver_Load(object sender, EventArgs e)
        {

        }
    }
}
