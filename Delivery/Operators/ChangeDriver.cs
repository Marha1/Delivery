using Microsoft.EntityFrameworkCore;
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
    public partial class ChangeDriver : Form
    {
        private int _choose;
        public ChangeDriver(int choose)
        {
            InitializeComponent();
            _choose = choose;
        }

        private void ChangeDriver_Load(object sender, EventArgs e)
        {
            LoadDriver();

        }

        private void LoadDriver()
        {
            using (ApplicationContext _context = new ApplicationContext())
            {
                var driver = _context.Drivers.Include(x=>x.Auth).FirstOrDefault(x => x.Id == _choose);
                if (driver != null)
                {
                    textBox1.Text = driver.Name;
                    textBox2.Text = driver.Surname;
                    textBox3.Text = driver.LastName;
                    numericUpDown1.Value = driver.Age;
                    numericUpDown2.Value = driver.Experience;
                    textBox4.Text = driver.PassNumber;
                    textBox5.Text = driver.LicenseNumber;
                    textBox6.Text = driver.Auth.Login;
                    textBox7.Text = driver.Auth.Password;
                    textBox8.Text = driver.CancelPassword;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext _context = new ApplicationContext())
            {
                var driver = _context.Drivers.FirstOrDefault(x => x.Id == _choose);
                if (driver != null)
                {
                    // Обновление данных из текстовых полей и числовых полей в объект driver
                    driver.Name = textBox1.Text;
                    driver.Surname = textBox2.Text;
                    driver.LastName = textBox3.Text;
                    driver.Age = (int)numericUpDown1.Value;  // Убедитесь, что значение соответствует типу
                    driver.Experience = (int)numericUpDown2.Value;
                    driver.PassNumber = textBox4.Text;
                    driver.LicenseNumber = textBox5.Text;

                    // Обновление данных для объекта Auth (если нужно)
                    if (driver.Auth != null)
                    {
                        driver.Auth.Login = textBox6.Text;
                        driver.Auth.Password = textBox7.Text;
                    }

                    // Если нужно обновить CancelPassword
                    driver.CancelPassword = textBox8.Text;

                    // Сохранение изменений в базе данных
                    _context.SaveChanges();
                    MessageBox.Show("Изменено!");
                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            СheckDrivers сheckDrivers = new СheckDrivers();
            сheckDrivers.Show();
        }
    }
}
