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
    /// <summary>
    /// Interaction logic for ParticipantsList.xaml
    /// </summary>
    public partial class ParticipantsList : Window
    {
        public ParticipantsList()
        {
            InitializeComponent();
            Model db = new Model();
            var query =
                from part in db.participants
                join cur in db.courses on part.CourseId equals cur.CoursesId
                join stu in db.students on part.UserId equals stu.StudentId
                select new { cur.CourseName, stu.Name, stu.Surname };

            fromQuery.ItemsSource = query.ToList();
        }
    }
}
