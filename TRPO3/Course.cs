using System;
using System.Collections.Generic;

namespace TRPO3
{
    public class Course
    {
        private string _CourseName, _CourseStart, _CourseEnd;
        private int _Price, _CourseHours, income;
        private Teacher _thisTeacher;
        public List<Teacher> courseTeachers = new List<Teacher>();
        public Course(string CourseName, int Price, int CourseHours, string courseStart, string courseEnd, int income)
        {
            this._CourseName = CourseName;
            this._Price = Price;
            this._CourseHours = CourseHours;
            this._CourseEnd = courseEnd;
            this._CourseStart = courseStart;
            this.income = income;
        }

        public string sCourseStart
        {
            get { return this._CourseStart; }
            set { this._CourseStart = value is string ? value : null; }
        }

        public string sCourseEnd
        {
            get { return this._CourseEnd; }
            set { this._CourseEnd = value is string ? value : null; }
        }

        public string sCourseName
        {
            get { return this._CourseName; }
            set { this._CourseName = value is string ? value : null; }
        }

        public int iPrice
        {
            get { return this._Price; }
            set { this._Price = value; }
        }

        public int Income
        {
            get { return this.income; }
            set { this.income = value; }
        }

        public int iCourseHours
        {
            get { return this._CourseHours; }
            set { this._CourseHours = value; }
        }

        public Teacher tthisTeacher
        {
            get { return this._thisTeacher; }
            set { this._thisTeacher = value; }
        }

        public List<Students> studentsList = new List<Students>();

        public List<Students> thisStudent
        {
            get { return studentsList; }
        }

        public Students setThisStudent
        {
            set { studentsList.Add(value); }
        }

        public List<Teacher> thisCourseTeachers
        {
            get { return courseTeachers; }
        }

        public Teacher setThisTeacher 
        {
            set { courseTeachers.Add(value); }
        }
        

    }
}

