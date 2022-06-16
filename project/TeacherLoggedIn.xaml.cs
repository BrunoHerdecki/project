using project.Lists;
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
        public Teacher teacher1 { get; set; }
        public TeacherLoggedIn(Teacher teacher)
        {
            InitializeComponent();
            teacher1 = teacher;
        }

        private void ShowCurses(object sender, RoutedEventArgs e)
        {
            CourseList curses = new CourseList();
            curses.Show();
        }
        private void ShowStudents(object sender, RoutedEventArgs e)
        {
            StudentsList students = new StudentsList();
            students.Show();
        }
        private void ShowParticipants(object sender, RoutedEventArgs e)
        {
            ParticipantsList participants = new ParticipantsList();
            participants.Show();
        }

        private void BtnAddCourse(object sender, RoutedEventArgs e)
        {
            Model db = new Model();
            Courses courseObject =
                new Courses()
                {
                    CourseName = CourseName.Text,
                    TeacherId = teacher1.TeacherId,
                    Description = DescriptionName.Text

                };
            if (CourseName.Text.Length < 5)
            {
                MessageBox.Show("Min course length is 5 characters");
                return;
            }
            try
            {
                db.courses.Add(courseObject);
                db.SaveChanges();
                MessageBox.Show($"You added course {CourseName.Text}");
            }
            catch (Exception)
            {
                MessageBox.Show("That course name already exhists");
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
                        MessageBox.Show($"Student:{StudentName.Text}  added to course: {whatCourse.Text}");
                    }
                    catch
                    {
                        MessageBox.Show("Something went wrong");
                    }

                }
                else
                    MessageBox.Show("Something went wrong");
            }
        }
    }
}
