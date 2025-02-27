using Delivery.Configuration;
using Delivery.Models;
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

namespace Delivery.Operators
{
    public partial class IssueFly : Form
    {
        private int _choose;
        public IssueFly(int choose)
        {
            InitializeComponent();
            _choose = choose;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            CheckFlyght checkFlyght = new CheckFlyght();
            checkFlyght.Show();
        }

        private void IssueFly_Load(object sender, EventArgs e)
        {
            LoadFreeDriver();
        }

        private void LoadFreeDriver()
        {

            button1.Visible = true;
            using (ApplicationContext db = new ApplicationContext())
            {
                // Получение списка водителей, у которых нет связанного рейса
                var freeDrivers = db.Drivers
                    .Where(driver => !db.Flights.Any(flight => flight.DriverId == driver.Id))
                    .OrderBy(d => d.Id)
                    .ToList();

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
                foreach (var driver in freeDrivers)
                {
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext _context = new ApplicationContext())
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите водителя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Получаем выбранную строку
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Извлекаем данные из строки
                string DriverName = selectedRow.Cells["Name"].Value.ToString();
                string DriverSurname = selectedRow.Cells["Surname"].Value.ToString();
                string DriverLic = selectedRow.Cells["LicenseNumber"].Value.ToString();

                // Ищем выбранного водителя в базе данных
                var driver = _context.Drivers.FirstOrDefault(s =>
                    s.Name == DriverName &&
                    s.Surname == DriverSurname &&
                    s.LicenseNumber == DriverLic);

                if (driver == null)
                {
                    MessageBox.Show("Выбранный водитель не найден в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ищем рейс по переданному _choose (Id рейса)
                var flight = _context.Flights.Include(x=>x.Cargo).FirstOrDefault(f => f.Id == _choose);

                if (flight == null)
                {
                    MessageBox.Show("Рейс не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                HistoryOfFlight history = new HistoryOfFlight()
                {
                    DriverId = driver.Id,
                    Driver = driver,
                    FlightName = flight.Name,
                    ArrivalDate = flight.ArrivalDate,
                    DispatchDate = flight.DispatchDate,
                    StartingPoint = flight.StartingPoint,
                    EndPoint = flight.EndPoint,
                    Status = flight.Status,
                    type = flight.Cargo.type,
                    Weight = flight.Cargo.Weight
                };
                    // Назначаем водителя на рейс
                flight.DriverId = driver.Id;
                _context.HistoryOfFlights.Add(history);
                // Сохраняем изменения
                _context.SaveChanges();

                MessageBox.Show("Водитель успешно назначен на рейс!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFreeDriver();
            }
        }

    }
}
