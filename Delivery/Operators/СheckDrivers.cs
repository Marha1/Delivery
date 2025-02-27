using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery
{
    public partial class СheckDrivers : Form
    {
        public СheckDrivers()
        {
            InitializeComponent();
        }

        private void СheckDrivers_Load(object sender, EventArgs e)
        {

            GetDrivers();
        }

        private void GetDrivers()
        {
            button1.Visible = true;
            using (ApplicationContext db = new ApplicationContext())
            {
                // Получение списка водителей из базы данных, отсортированных по ID
                var drivers = db.Drivers.OrderBy(d => d.Id).ToList();

                // Очищаем DataGridView
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                // Добавление колонок в DataGridView
                dataGridView1.Columns.Add("Name", "Имя");
                dataGridView1.Columns.Add("Surname", "Фамилия");
                dataGridView1.Columns.Add("LastName", "Отчество");
                dataGridView1.Columns.Add("CancelPassword", "Код-Отмены");
                dataGridView1.Columns.Add("Experience", "Cтаж");
                dataGridView1.Columns.Add("LicenseNumber", "Номер Вод.Уд");

                // Заполнение DataGridView данными из базы
                foreach (var driver in drivers)
                {
                    // Если у водителя есть текущий рейс, выводим его название, иначе оставляем пусто

                    dataGridView1.Rows.Add(
                        driver.Name,
                        driver.Surname,
                        driver.LastName,
                        driver.CancelPassword,
                        driver.Experience,
                        driver.LicenseNumber
                    );
                }
            }
            if (dataGridView1.Rows.Count == 0)
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AddDriver driver = new AddDriver();
            driver.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Проверяем, есть ли выделенная строка
            {
                using (ApplicationContext _context = new ApplicationContext())
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];


                    // Получаем данные из выбранной строки
                    string Drivername = selectedRow.Cells["Name"].Value.ToString();
                    string DriverSurname = selectedRow.Cells["Surname"].Value.ToString();
                    string DriverLic = selectedRow.Cells["LicenseNumber"].Value.ToString();
                    var driver = _context.Drivers.FirstOrDefault(s =>
            s.Name == Drivername &&
            s.Surname == DriverSurname &&
            s.LicenseNumber == DriverLic);


                    this.Close();
                    ChangeDriver changeBook = new ChangeDriver(driver.Id);
                    changeBook.Show();
                }
            }
            
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку.");
            }

            }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Проверяем, есть ли выделенная строка
            {

                using (ApplicationContext _context = new ApplicationContext())
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];


                    // Получаем данные из выбранной строки
                    string Drivername = selectedRow.Cells["Name"].Value.ToString();
                    string DriverSurname = selectedRow.Cells["Surname"].Value.ToString();
                    string DriverLic = selectedRow.Cells["LicenseNumber"].Value.ToString();
                    var driver = _context.Drivers.FirstOrDefault(s =>
            s.Name == Drivername &&
            s.Surname == DriverSurname &&
            s.LicenseNumber == DriverLic);


                    _context.Remove(driver);
                    _context.SaveChanges();
                    GetDrivers();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Проверяем, есть ли выделенная строка
            {
                using (ApplicationContext _context = new ApplicationContext())
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];


                    // Получаем данные из выбранной строки
                    string Drivername = selectedRow.Cells["Name"].Value.ToString();
                    string DriverSurname = selectedRow.Cells["Surname"].Value.ToString();
                    string DriverLic = selectedRow.Cells["LicenseNumber"].Value.ToString();
                    var driver = _context.Drivers.FirstOrDefault(s =>
            s.Name == Drivername &&
            s.Surname == DriverSurname &&
            s.LicenseNumber == DriverLic);
                    if (driver != null)
                    {
                        CheckHistory checkHistory = new CheckHistory(driver.Id);
                        checkHistory.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку.");
            }

        }
    }
}

