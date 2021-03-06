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
                join tea in db.teachers on cur.TeacherId equals tea.TeacherId
                where part.UserId == user.StudentId
                select new { cur.CourseName, cur.Description, Teacher_Name = tea.Name, Teacher_Surname = tea.Surname };

            fromQuery.ItemsSource = query.ToList();
        }
    }
}
