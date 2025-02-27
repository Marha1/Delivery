using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Delivery
{
    public partial class CheckHistory : Form
    {
        private int _choose; // ID выбранного водителя
        public CheckHistory(int choose)
        {
            InitializeComponent();
            _choose = choose; // сохраняем ID водителя
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckHistory_Load(object sender, EventArgs e)
        {
            LoadDriverHistory(); // Загрузка истории рейсов
        }

        private void LoadDriverHistory()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Получение данных о водителе по ID
                var driver = db.Drivers.FirstOrDefault(d => d.Id == _choose);

                if (driver == null)
                {
                    MessageBox.Show("Водитель не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Получение истории рейсов, связанных с этим водителем
                var history = db.HistoryOfFlights
                    .Where(h => h.DriverId == driver.Id)
                    .ToList();

                // Очистка DataGridView
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                // Добавление колонок в DataGridView
                dataGridView1.Columns.Add("Name", "Имя рейса");
                dataGridView1.Columns.Add("StartingPoint", "Точка отправки");
                dataGridView1.Columns.Add("EndPoint", "Точка Доставки");
                dataGridView1.Columns.Add("Status", "Статус");
                dataGridView1.Columns.Add("DispatchDate", "Дата Отправки");
                dataGridView1.Columns.Add("ArrivalDate", "Дата Доставки");
                dataGridView1.Columns.Add("CargosType", "Тип Груза");
                dataGridView1.Columns.Add("CargosWeight", "Вес Груза");
                foreach (var h in history)
                {
                    dataGridView1.Rows.Add(
                        h.FlightName,           // Имя рейса
                        h.StartingPoint,        // Точка отправки
                        h.EndPoint,             // Точка доставки
                        h.Status.ToString(),    // Статус
                        h.DispatchDate.ToString("dd.MM.yyyy"), // Дата отправки
                        h.ArrivalDate.ToString("dd.MM.yyyy"),  // Дата доставки
                        h.type.ToString(),      // Тип груза
                        h.Weight.ToString()     // Вес
                    );
                }
            }
        }

    }
}
