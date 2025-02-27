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

namespace Delivery
{
    public partial class CheckFlyght : Form
    {
        public CheckFlyght()
        {
            InitializeComponent();
        }

        private void CheckFlyght_Load(object sender, EventArgs e)
        {
            GetFlight();
        }

        private void GetFlight()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Получение списка водителей из базы данных, отсортированных по ID
                var flights = db.Flights
     .Include(f => f.Cargo)
     .Include(x => x.Driver) // Загружаем связанный Driver для каждого Flight
     .OrderBy(f => f.Id)
     .ToList();

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
                dataGridView1.Columns.Add("Driver", "Водитель");

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
                        cargoWeight,
                        driverName
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
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AddFlight addFlight = new AddFlight();
            addFlight.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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
                var fly = _context.Flights.First(s =>
        s.Name == Name &&
        s.StartingPoint == startpoint &&
        s.EndPoint == endpoint);

                if (fly != null)
                {
                    this.Close();
                    ChangeFlight changeFlight = new ChangeFlight(fly.Id);
                    changeFlight.Show();
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

        private void button4_Click(object sender, EventArgs e)
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
                var fly = _context.Flights.First(s =>
        s.Name == Name &&
        s.StartingPoint == startpoint &&
        s.EndPoint == endpoint);

                if (fly != null)
                {
                    this.Close();
                    IssueFly issueFly = new IssueFly(fly.Id);
                    issueFly.Show();
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

        private void button3_Click(object sender, EventArgs e)
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
                    var fly = _context.Flights.First(s =>
            s.Name == Name &&
            s.StartingPoint == startpoint &&
            s.EndPoint == endpoint);

                    if (fly != null)
                    {
                        _context.Flights.Remove(fly);
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
    }
}
