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
                { Username = dbName.Text, Password = dbPassword.Password };
            if(dbName.Text.Length<5 || dbName.Text.Length>10)
            {
                MessageBox.Show("Min username length is 5 characters and max is 10 characters");
                return;
            }
            if (dbPassword.Password.Length < 5 || dbPassword.Password.Length > 10)
            {
                MessageBox.Show("Min password length is 5 characters and max is 10 password");
                return;
            }
            try
            {
                db.students.Add (studentObject);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Username");
            }
        }


        private void btnLoginAsStudent(object sender, RoutedEventArgs e)
        {
            UserLoggedIn userLoggedIn = new UserLoggedIn();
            using (Model context = new Model())
            {
                var user = context.students.FirstOrDefault(u => u.Username == loginName.Text);
                if (user != null)
                {
                    if (user.Password == loginPassword.Password)
                    {
                        userLoggedIn.Show();
                        this.Close();
                    }
                }
            }


        }

        private void btnLoginAsTeacher(object sender, RoutedEventArgs e)
        {
            TeacherLoggedIn  teacherLoggedIn = new TeacherLoggedIn();
            using (Model context = new Model())
            {
                var user = context.teachers.FirstOrDefault(u => u.Username == TeacherName.Text);
                if (user != null)
                {
                    if (user.Password == TeacherPassword.Password)
                    {
                        teacherLoggedIn.Show();
                        this.Close();

                    }
                }
            }

        }

    }
}
