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
    /// Interaction logic for TeacherLoggedIn.xaml
    /// </summary>
    public partial class TeacherLoggedIn : Window
    {
        public TeacherLoggedIn()
        {
            InitializeComponent();
        }

        private void BtnAddCourse(object sender, RoutedEventArgs e)
        {
            Model db = new Model();

            Courses courseObject =
                new Courses()
                {
                    CourseName = CourseName.Text,
                    Description = DescriptionName.Text
                };
            if (CourseName.Text.Length < 5)
            {
                MessageBox.Show("Min course length is 5 characters");
                return;
            }
            try
            {
                db.courses.Add (courseObject);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void BtnAddStudentToCourse(object sender, RoutedEventArgs e)
        {
            using (Model context = new Model())
            {
                var user =
                    context
                        .students
                        .FirstOrDefault(u => u.Username == StudentName.Text);
                var course =
                    context
                        .courses
                        .FirstOrDefault(u => u.CourseName == whatCourse.Text);
                if (user != null && course != null)
                {
                    Participants participantsObject =
                        new Participants()
                        {
                            CourseId = course.CoursesId,
                            UserId = user.StudentId
                        };
                    try
                    {
                        context.participants.Add(participantsObject);
                        context.SaveChanges();
                        MessageBox.Show("Students added to course");
                    }
                    catch
                    {
                        MessageBox.Show("Something went wrong");
                    }

                }
            }
        }
    }
}
