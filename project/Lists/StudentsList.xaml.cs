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
using System.Windows.Shapes;

namespace project.Lists
{
    public partial class StudentsList : Window
    {
        public StudentsList()
        {
            InitializeComponent();
            Model db = new Model();
            var query =
                from stu in db.students
                select new { stu.StudentId, stu.Username};
            lista2.ItemsSource = query.ToList();
        }
    }
}
