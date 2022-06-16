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

namespace project
{
    /// <summary>
    /// Interaction logic for UserLoggedIn.xaml
    /// </summary>
    public partial class UserLoggedIn : Window
    {
        public UserLoggedIn(Student user)
        {
            InitializeComponent();

            Model db = new Model();
            var query =
                from part in db.participants
                join cur in db.courses on part.CourseId equals cur.CoursesId
                where part.UserId == user.StudentId
                select new { part.CourseId, cur.CourseName, cur.Description };

            fromQuery.ItemsSource = query.ToList();
        }
    }
}
