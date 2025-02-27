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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Delivery.Drivers
{
    public partial class ChangeDataDriver : Form
    {
        private Models.Driver _loginDriver;
        public ChangeDataDriver(Models.Driver loginDriverId)
        {
            InitializeComponent();
            _loginDriver = loginDriverId;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка на существование пользователя
            if (_loginDriver != null)
            {
                try
                {
                    using (var _context = new ApplicationContext())
                    {
                        // Загружаем данные пользователя с его ID
                        _loginDriver = _context.Drivers
                            .Include(d => d.Auth) // Убедитесь, что поле Auth правильно загружается
                            .FirstOrDefault(d => d.Id == _loginDriver.Id);

                        if (_loginDriver != null && textBox2.Text==_loginDriver.Auth.Password)
                        {
                            // Обновляем данные из текстовых полей
                            _loginDriver.Auth.Login = textBox1.Text;  // Обновляем логин
                            _loginDriver.Auth.Password = textBox3.Text;  // Обновляем пароль
                            // Сохраняем изменения в базе данных
                            _context.SaveChanges();

                            // Информируем пользователя об успешном сохранении
                            MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Пользователь не загружен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ChangeDataDriver_Load(object sender, EventArgs e)
        {
        }

        private void GetLogin()
        {
            using (var _context = new ApplicationContext())
            {
                try
                {
                    // Получаем ID текущего пользователя. Если у вас уже есть ID, замените userId на нужное значение.
                    int userId = _loginDriver.Id;

                    // Загружаем пользователя вместе с его Auth данными
                    _loginDriver = _context.Drivers
                        .Include(d => d.Auth) // Замените Auth на правильное навигационное свойство, если оно называется иначе
                        .FirstOrDefault(d => d.Id == userId);

                    if (_loginDriver != null)
                    {
                        // Вывод данных в TextBox
                        textBox1.Text = _loginDriver.Auth.Login; // Имя пользователя
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
