using Delivery.Driver;
using Delivery.Models;
using Delivery.Operators;
using Delivery.Primitives;
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

namespace Delivery.Drivers
{
    public partial class CurrentFlight : Form
    {
        private static Models.Driver _Driver;
        private StatusOfDelievery _StatusOfDelievery;
        private Generate generate = new Generate();
        public CurrentFlight(Models.Driver driver)
        {
            InitializeComponent();
            _Driver = driver;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            DriverForm driverForm = new DriverForm(_Driver);
            driverForm.Show();
        }

        private void CurrentFlight_Load(object sender, EventArgs e)
        {
            GetFlyight();
            var Status = Enum.GetValues(typeof(StatusOfDelievery));
            comboBox1.DataSource = Status;
        }

        private void GetFlyight()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Получение данных о водителе с текущим рейсом
                var driver = db.Drivers
                    .Include(d => d.CurrentFlight) // Подгружаем текущий рейс
                    .ThenInclude(f => f.Cargo) // Подгружаем груз рейса
                    .FirstOrDefault(d => d.Id == _Driver.Id);

                if (driver == null)
                {
                    MessageBox.Show("Водитель не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Очистка DataGridView
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                // Добавление колонок
                dataGridView1.Columns.Add("Name", "Имя рейса");
                dataGridView1.Columns.Add("StartingPoint", "Точка отправки");
                dataGridView1.Columns.Add("EndPoint", "Точка доставки");
                dataGridView1.Columns.Add("Status", "Статус");
                dataGridView1.Columns.Add("DispatchDate", "Дата отправки");
                dataGridView1.Columns.Add("ArrivalDate", "Дата доставки");
                dataGridView1.Columns.Add("CargosType", "Тип груза");
                dataGridView1.Columns.Add("CargosWeight", "Вес груза");

                // Отображение текущего рейса
                if (driver.CurrentFlight != null)
                {
                    var flight = driver.CurrentFlight;
                    var cargo = flight.Cargo; // Груз рейса

                    dataGridView1.Rows.Add(
                        flight.Name ?? "Не указано", // Имя рейса
                        flight.StartingPoint ?? "Не указано", // Точка отправки
                        flight.EndPoint ?? "Не указано", // Точка доставки
                        flight.Status.ToString() ?? "Неизвестно", // Статус рейса
                        flight.DispatchDate.ToString("dd.MM.yyyy") ?? "Не указано", // Дата отправки
                        flight.ArrivalDate.ToString("dd.MM.yyyy") ?? "Не указано", // Дата доставки
                        cargo?.type.ToString() ?? "Не указано", // Тип груза
                        cargo?.Weight.ToString() ?? "0" // Вес груза
                    );
                }
                else
                {
                    MessageBox.Show("Текущий рейс не найден для данного водителя.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                using (ApplicationContext _context = new ApplicationContext())
                {
                    try
                    {
                        // Получаем выбранную строку в DataGridView
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        // Извлекаем данные рейса из строки
                        string name = selectedRow.Cells["Name"].Value.ToString();
                        string startPoint = selectedRow.Cells["StartingPoint"].Value.ToString();
                        string endPoint = selectedRow.Cells["EndPoint"].Value.ToString();

                        // Находим рейс в базе данных
                        var flight = _context.Flights.Include(x=>x.Cargo).FirstOrDefault(s =>
                            s.Name == name &&
                            s.StartingPoint == startPoint &&
                            s.EndPoint == endPoint);

                        if (flight != null)
                        {
                            // Устанавливаем новый статус рейса
                            var selectedStatus = (StatusOfDelievery)comboBox1.SelectedItem;
                            flight.Status = selectedStatus;

                            // Сохраняем изменения в базе данных
                            _context.SaveChanges();

                            // Обновляем статус в DataGridView
                            selectedRow.Cells["Status"].Value = selectedStatus.ToString();
                            HistoryOfFlight history = new HistoryOfFlight()
                            {
                                DriverId = _Driver.Id,
                                FlightName = flight.Name,
                                ArrivalDate = flight.ArrivalDate,
                                DispatchDate = flight.DispatchDate,
                                StartingPoint = flight.StartingPoint,
                                EndPoint = flight.EndPoint,
                                Status = flight.Status,
                                type = flight.Cargo.type,
                                Weight = flight.Cargo.Weight
                            };
                            _context.Add(history);
                            _context.SaveChanges();
                            MessageBox.Show("Статус успешно изменён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Рейс не найден в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку с рейсом для изменения статуса.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                using (ApplicationContext _context = new ApplicationContext())
                {
                    try
                    {
                        var driver = _context.Drivers.Include(d => d.CurrentFlight)
                                                     .FirstOrDefault(d => d.Id == _Driver.Id);

                        if (driver == null)
                        {
                            MessageBox.Show("Водитель не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string name = selectedRow.Cells["Name"].Value.ToString();
                        string startpoint = selectedRow.Cells["StartingPoint"].Value.ToString();
                        string endpoint = selectedRow.Cells["EndPoint"].Value.ToString();

                        var fly = _context.Flights.FirstOrDefault(f =>
                            f.Name == name &&
                            f.StartingPoint == startpoint &&
                            f.EndPoint == endpoint);

                        if (fly == null)
                        {
                            MessageBox.Show("Рейс не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        CancelForm cancelCodeForm = new CancelForm();
                        if (cancelCodeForm.ShowDialog() != DialogResult.OK)
                        {
                            MessageBox.Show("Действие отменено пользователем.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string cancelCode = cancelCodeForm.CancelCode;

                        if (string.IsNullOrEmpty(cancelCode))
                        {
                            MessageBox.Show("Код отмены не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (cancelCode != driver.CancelPassword)
                        {
                            MessageBox.Show("Неверный код отмены! Код можно узнать у оператора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Отмена рейса
                        fly.Status = Primitives.StatusOfDelievery.Waiting; // Установить статус "Ожидание" или другой
                        driver.FlightId = 0; // Или driver.FlightId = null;
                        driver.CurrentFlight = null;
                        fly.DriverId = null;
                        driver.FlightId = 0;
                        _Driver = driver;

                        // Генерация нового кода отмены
                        driver.CancelPassword = generate.GeneratePassport();

                        // Пометка объектов как измененные
                        _context.Entry(driver).State = EntityState.Modified;
                        _context.Entry(fly).State = EntityState.Modified;
                        _context.SaveChanges();

                        MessageBox.Show("Рейс успешно отменён! Новый код отмены установлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновление DataGridView
                        GetFlyight();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку с рейсом для отмены.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    }
