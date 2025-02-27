using Delivery.Driver;
using Delivery.Models;
using Delivery.Operators;
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
    public partial class FreeFlyght : Form
    {
        private Models.Driver _logindriver;
        public FreeFlyght(Models.Driver loginDriverId)
        {
            InitializeComponent();
            _logindriver = loginDriverId;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            DriverForm driverform = new DriverForm(_logindriver);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Проверяем, есть ли выделенная строка
            {

                using (ApplicationContext _context = new ApplicationContext())
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];


                    // Получаем данные из выбранной строки
                    string Name = selectedRow.Cells["Name"].Value.ToString();
                    string startpoint = selectedRow.Cells["StartingPoint"].Value.ToString();
                    string endpoint = selectedRow.Cells["EndPoint"].Value.ToString();
                    var flight = _context.Flights.Include(X=>X.Cargo).First(s =>
            s.Name == Name &&
            s.StartingPoint == startpoint &&
            s.EndPoint == endpoint);

                    if (flight != null)
                    {
                        var driver = _context.Drivers.FirstOrDefault(d => d.Id == _logindriver.Id);
                        if (driver != null)
                        {
                            driver.FlightId = flight.Id;
                            driver.CurrentFlight = flight;
                        }
                        _context.SaveChanges();
                        HistoryOfFlight history = new HistoryOfFlight()
                            {
                                DriverId = _logindriver.Id,
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
                        MessageBox.Show("Заказ Успешно взят");
                        // Сохраняем изменения
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Произошла Ошибка!");
                    }

                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку.");
            }
        }

        private void FreeFlyght_Load(object sender, EventArgs e)
        {
            GetFreeFlyght();
        }

        
            private void GetFreeFlyght()
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                // Получение списка водителей из базы данных, отсортированных по ID
                var flights = db.Flights
     .Include(f => f.Cargo)
     .Include(x => x.Driver) // Загружаем связанный Driver для каждого Flight
     .OrderBy(f => f.Id).Where(x=>x.DriverId == null);

                    // Очищаем DataGridView
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();

                    // Добавление колонок в DataGridView
                    dataGridView1.Columns.Add("Name", "Имя");
                    dataGridView1.Columns.Add("StartingPoint", "Точка отправки");
                    dataGridView1.Columns.Add("EndPoint", "Точка Доставки");
                    dataGridView1.Columns.Add("Status", "Статус");
                    dataGridView1.Columns.Add("DispatchDate", "Дата Отправки");
                    dataGridView1.Columns.Add("ArrivalDate", "Дата Доставки");
                    dataGridView1.Columns.Add("CargosType", "Тип Груза");
                    dataGridView1.Columns.Add("CargosWeight", "Вес Груза");
                    // Заполнение DataGridView данными из базы
                    foreach (var flight in flights)
                    {
                        var cargoType = flight.Cargo != null ? flight.Cargo.type.ToString() : "Нет груза";
                        var cargoWeight = flight.Cargo != null ? flight.Cargo.Weight.ToString() : "0";
                        var arrivalDate = flight.ArrivalDate == DateTime.MinValue ? "Неизвестно" : flight.ArrivalDate.ToString("yyyy-MM-dd");

                        // Проверка на наличие водителя
                        var driverName = flight.Driver != null ? flight.Driver.Name : "Неназначен";

                        dataGridView1.Rows.Add(
                            flight.Name,
                            flight.StartingPoint,
                            flight.EndPoint,
                            flight.Status,
                            flight.DispatchDate.ToString("yyyy-MM-dd"),
                            arrivalDate,
                            cargoType,
                            cargoWeight
                        );
                    }

                }
            }
        
    }
}
