using Delivery.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Delivery.Operators
{
    public partial class ChangeFlight : Form
    {
        private int _choose;
        private TypeOfCargo _typeOfCargo;

        public ChangeFlight(int choose)
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

        private void ChangeFlight_Load(object sender, EventArgs e)
        {
            LoadFlyght();
            var cargoTypes = Enum.GetValues(typeof(TypeOfCargo));
            comboBox1.DataSource = cargoTypes;
        }

        private void LoadFlyght()
        {
            using (ApplicationContext _context = new ApplicationContext())
            {
                var flyight = _context.Flights.Include(x => x.Cargo).FirstOrDefault(x => x.Id == _choose);
                if (flyight != null)
                {
                    textBox1.Text = flyight.Name;
                    textBox2.Text = flyight.StartingPoint;
                    textBox3.Text = flyight.EndPoint;

                    // Проверяем DispatchDate
                    dateTimePicker1.Value = flyight.DispatchDate != DateTime.MinValue
                        ? flyight.DispatchDate
                        : DateTime.Now; // Установить текущую дату, если дата неизвестна

                    // Проверяем ArrivalDate
                    dateTimePicker2.Value = flyight.ArrivalDate != DateTime.MinValue
                        ? flyight.ArrivalDate
                        : DateTime.Now; // Аналогично, устанавливаем текущую дату
                    if (flyight.Cargo != null)
                    {
                        numericUpDown1.Value = (decimal)flyight.Cargo.Weight;
                    }
                    else
                    {
                        numericUpDown1.Value = 0; // Если груза нет, устанавливаем 0
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext _context = new ApplicationContext())
            {
                // Получаем объект Flight из базы данных по ID (_choose)
                var flight = _context.Flights.Include(f => f.Cargo).FirstOrDefault(f => f.Id == _choose);

                if (flight != null)
                {
                    // Обновляем поля объекта из элементов управления
                    flight.Name = textBox1.Text;
                    flight.StartingPoint = textBox2.Text;
                    flight.EndPoint = textBox3.Text;
                    flight.DispatchDate = dateTimePicker1.Value;
                    flight.ArrivalDate = dateTimePicker2.Value;

                    // Обновляем статус из ComboBox
                    if (comboBox1.SelectedItem != null)
                    {
                        flight.Cargo.type = (TypeOfCargo)comboBox1.SelectedItem;
                    }

                    // Обновляем данные о грузе (если связанный объект Cargo существует)
                    if (flight.Cargo != null)
                    {
                        flight.Cargo.Weight = (double)numericUpDown1.Value;
                    }

                    // Сохраняем изменения в базе данных
                    _context.SaveChanges();

                    MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Рейс не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _typeOfCargo = (TypeOfCargo)comboBox1.SelectedItem;

        }
    }
}
