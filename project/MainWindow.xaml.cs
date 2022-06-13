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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Model db = new Model();

            Student studentObject = new Student()
            {
                Username = dbName.Text,
                Password = dbPassword.Text
            };
            try
            {
                db.students.Add(studentObject);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("ciota");
            }

        }
    }
}
