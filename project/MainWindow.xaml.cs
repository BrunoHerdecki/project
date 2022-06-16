using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRegister(object sender, RoutedEventArgs e)
        {
            Model db = new Model();

            Student studentObject =
                new Student()
                {
                    Username = dbName.Text,
                    Password = dbPassword.Password,
                    Name = dbNamee.Text,
                    Surname = dbSurname.Text,
                    Adress = dbAdress.Text
                };
            if (dbName.Text.Length < 5 || dbName.Text.Length > 10)
            {
                MessageBox
                    .Show("Min username length is 5 characters and max is 10 characters");
                return;
            }
            if (
                dbPassword.Password.Length < 5 ||
                dbPassword.Password.Length > 10
            )
            {
                MessageBox
                    .Show("Min password length is 5 characters and max is 10 password");
                return;
            }
            try
            {
                db.students.Add(studentObject);
                db.SaveChanges();
                var user =
                    db.students.FirstOrDefault(u => u.Username == dbName.Text);
                UserLoggedIn userLoggedIn = new UserLoggedIn(user);
                userLoggedIn.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Username");
            }
        }

        private void btnLoginAsStudent(object sender, RoutedEventArgs e)
        {
            using (Model context = new Model())
            {
                var user =
                    context
                        .students
                        .FirstOrDefault(u => u.Username == loginName.Text);
                if (user != null)
                {
                    if (user.Password == loginPassword.Password)
                    {
                        UserLoggedIn userLoggedIn = new UserLoggedIn(user);
                        userLoggedIn.Show();
                        this.Close();
                    }
                }
            }
        }

        private void btnLoginAsTeacher(object sender, RoutedEventArgs e)
        {
            using (Model context = new Model())
            {
                var teacher =
                    context
                        .teachers
                        .FirstOrDefault(u => u.Username == TeacherName.Text);
                if (teacher != null)
                {
                    if (teacher.Password == TeacherPassword.Password)
                    {
                        TeacherLoggedIn teacherLoggedIn =
                            new TeacherLoggedIn(teacher);
                        teacherLoggedIn.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}
