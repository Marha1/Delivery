using Delivery.Driver;
using Microsoft.EntityFrameworkCore;

namespace Delivery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext _context = new ApplicationContext())
                {
                    // Получаем объект авторизации
                    var login = _context.Auths
                        .Include(x => x.Operator)  // Включаем оператора
                        .Include(x => x.Driver)    // Включаем водителя
                        .FirstOrDefault(x => x.Login == textBox1.Text && x.Password == textBox2.Text);

                    if (login != null)
                    {
                        MessageBox.Show($"Авторизован как: {login.Role}");

                        // Скрываем текущую форму
                        this.Hide();

                        // В зависимости от роли показываем соответствующую форму
                        if (login.Role == Primitives.Role.Admin)
                        {
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                        }
                        else if (login.Role == Primitives.Role.User)
                        {
                            // Если роль водителя, показываем форму водителя
                            DriverForm driverForm = new DriverForm(login.Driver);
                            driverForm.Show();
                        }
                    }
                    else
                    {
                        // Если логин или пароль неверные
                        textBox1.ForeColor = Color.Red;
                        textBox2.ForeColor = Color.Red;
                        MessageBox.Show("Неверный логин или пароль");
                        textBox1.ForeColor = Color.Black;
                        textBox2.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибок
                Console.WriteLine(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
