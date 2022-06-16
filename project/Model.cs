using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace project
{
    public class Model : DbContext
    {
        public DbSet<Student> students { get; set; }

        public DbSet<Teacher> teachers { get; set; }

        public DbSet<Courses> courses { get; set; }

        public DbSet<Participants> participants { get; set; }

        public string DbPath { get; }

        public Model()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "project.db");
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder options
        ) => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participants>().HasKey(k => new { k.CourseId, k.UserId });

            modelBuilder.Entity<Student>().HasIndex(u => u.Username).IsUnique();

            modelBuilder.Entity<Teacher>().HasIndex(u => u.Username).IsUnique();
        }
    }
}

public class Teacher
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public int TeacherId { get; set; }
}

public class Student
{
    public int StudentId { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}

public class Courses
{
    public int CoursesId { get; set; }

    [Required]
    public string CourseName { get; set; }

    public int TeacherId { get; set; }

    public string Description { get; set; }
}

public class Participants
{
    public int CourseId { get; set; }

    public int UserId { get; set; }
}
