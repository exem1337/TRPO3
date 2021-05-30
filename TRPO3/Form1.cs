using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TRPO3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Teacher> teachers = new List<Teacher>();
        List<Firm> firms = new List<Firm>();
        List<Course> courses = new List<Course>();
        List<Education> Education = new List<Education>();
        private void updateTeachersDG()
        {
            TeachersDG.Rows.Clear();
            foreach (Course c in courses)
                foreach (Teacher t in c.courseTeachers)
                {
                    TeachersDG.Rows.Add(t.sFIO, t.sEducation, t.sCategory);
                }
        }

        private void updateCourseDG()
        {
            CoursesDG.Rows.Clear();


            foreach (Course c in courses)
            {
                CoursesDG.Rows.Add(c.sCourseName, c.iCourseHours, c.iPrice, c.sCourseStart, c.sCourseEnd, c.Income);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addNewCourse();
            updateCourseDG();
            updateTeachersDG();
            updateCoursePicker();
            updateTeacherCB();
        }

        public void addNewCourse()
        {
            try
            {
                Course newCourse = new Course(courseNameTB.Text, Convert.ToInt32(coursePriceTB.Text), Convert.ToInt32(courseHoursTB.Text), CourseStartTimeDTP.Value.ToString(), CourseEndTimeDTP.Value.ToString(), 0);
                courses.Add(newCourse);

                teacherFIOtb.ForeColor = Color.White;

                courseNameTB.ForeColor = Color.White;
                coursePriceTB.ForeColor = Color.White;
                courseHoursTB.ForeColor = Color.White;
            }
            catch (System.FormatException)
            {
                if (courseNameTB.Text == string.Empty) courseNameTB.ForeColor = Color.IndianRed;
                if (coursePriceTB.Text == "") coursePriceTB.ForeColor = Color.IndianRed;
                if (courseHoursTB.Text == string.Empty) courseHoursTB.ForeColor = Color.IndianRed;
            }

        }

        private void updateCoursePicker()
        {
            studentCoursePicker.Items.Clear();

            foreach (Course c in courses)
            {
                studentCoursePicker.Items.Add(c.sCourseName);
            }
        }

        public void addNewStudent()
        {
            Course cou;
            Students newStudent = new Students(studentFIOtb.Text, studentPhoneTB.Text, dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());


            foreach (Course c in courses)
            {
                if (c.sCourseName == studentCoursePicker.SelectedItem.ToString())
                {
                    cou = c;
                    cou.setThisStudent = newStudent;
                    cou.Income += cou.iPrice;
                }
            }

        }

        private void updateStudentsDG()
        {
            studentsDG.Rows.Clear();

            foreach (Course c in courses)
            {
                foreach (Students s in c.studentsList)
                {
                    studentsDG.Rows.Add(s.sFIO, s.sphoneNumber, c.sCourseName, comboBox1.SelectedItem.ToString(), s.BeginDate, s.EndDate);
                }
            }
        }

        private void addnewStudentBTN_Click(object sender, EventArgs e)
        {
            addNewStudent();
            updateStudentsDG();
            updateCourseDG();
            updateStats();
        }

        void updateStats()
        {
            chart1.Series.Clear(); int i = 0;
            foreach (Course c in courses) 
            {
                chart1.Series.Add(c.sCourseName);
                chart1.Series[i].Points.Add(c.Income); i++; 
            }
            i = 0;
            treeView1.Nodes.Clear();
            foreach (Course c in courses) 
            {
                treeView1.Nodes.Add(c.sCourseName);
                foreach(Students s in c.studentsList)
                {
                    treeView1.Nodes[i].Nodes.Add(s.sFIO);
                }
                i++;
            }
        }

        string tempFIO; Teacher tempTCHR;

        private void TeachersDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TeachersDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tempFIO = TeachersDG.Rows[e.RowIndex].Cells[0].Value.ToString();
            teacherFIOtb.Text = TeachersDG.Rows[e.RowIndex].Cells[0].Value.ToString();

            foreach (Course c in courses)
            {
                foreach (Teacher t in c.courseTeachers)
                {
                    if (t.sFIO == tempFIO)
                    {
                        tempTCHR = t; break;
                    }
                }
            }
        }

        void updateTeacherCB()
        {
            addCourseTeacherCB.Items.Clear();
            foreach (Course c in courses)
            {
                addCourseTeacherCB.Items.Add(c.sCourseName);
            }
        }

        private void addTeacherBTN_Click(object sender, EventArgs e)
        {
            try
            {
                crs.setThisTeacher = new Teacher(teacherFIOtb.Text, comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString());

                teacherFIOtb.Text = String.Empty;

                updateTeacherCB(); updateTeachersDG();

            }
            catch (Exception)
            {

            }
        }

        private void EditTeacherBTN_Click(object sender, EventArgs e)
        {
            tempTCHR.sFIO = teacherFIOtb.Text;

            updateTeacherCB(); updateTeachersDG();
            teacherFIOtb.Text = String.Empty;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            courses.Remove(tempCourse);
            updateCourseDG();
            updateCoursePicker();
        }
        Course tempCourse;
        private void CoursesDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CoursesDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            courseNameTB.Text = CoursesDG.Rows[e.RowIndex].Cells[0].Value.ToString();
            courseHoursTB.Text = CoursesDG.Rows[e.RowIndex].Cells[1].Value.ToString();
            coursePriceTB.Text = CoursesDG.Rows[e.RowIndex].Cells[2].Value.ToString();
            CourseStartTimeDTP.Value = Convert.ToDateTime(CoursesDG.Rows[e.RowIndex].Cells[3].Value);
            CourseEndTimeDTP.Value = Convert.ToDateTime(CoursesDG.Rows[e.RowIndex].Cells[4].Value);
            foreach (Course c in courses)
            {
                if (c.sCourseName == courseNameTB.Text) { tempCourse = c; break; }
            }
        }

        private void studentCoursePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (Course c in courses)
            {
                if (c.sCourseName == studentCoursePicker.SelectedItem.ToString())
                {
                    foreach (Teacher t in c.courseTeachers)
                    {
                        comboBox1.Items.Add(t.sFIO);
                    }
                }
            }
        }

        private void studentCoursePicker_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (Course c in courses)
            {
                if (c.sCourseName == studentCoursePicker.SelectedItem.ToString())
                {
                    foreach (Teacher t in c.courseTeachers)
                    {
                        comboBox1.Items.Add(t.sFIO);
                    }
                }
            }
        }
        Course crs;
        private void addCourseTeacherCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Course c in courses)
                {
                    if (c.sCourseName == addCourseTeacherCB.SelectedItem.ToString()) { crs = c; break; }
                }
            }
            catch { }
        }

        private void deleteTeacher_Click(object sender, EventArgs e)
        {
            foreach (Course c in courses)
            {
                if (c.courseTeachers.Contains(tempTCHR)) { c.courseTeachers.Remove(tempTCHR); break; }
            }
            updateTeacherCB(); updateTeachersDG();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Education.Add(new Education(textBox1.Text));
                updateEducationDG();
                textBox1.Text = String.Empty;
            }
            catch { }
        }

        void updateEducationDG()
        {
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            EducationDG.Rows.Clear();
            foreach (Education edu in Education)
            {
                comboBox2.Items.Add(edu.Name);
                EducationDG.Rows.Add(edu.Name);
                comboBox4.Items.Add(edu.Name);
            }
        }
        Education ed;
        private void EducationDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EducationDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            textBox1.Text = EducationDG.Rows[e.RowIndex].Cells[0].Value.ToString();
            foreach (Education edu in Education)
            {
                if (edu.Name == textBox1.Text) { ed = edu; break; }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ed.Name = textBox1.Text;
            updateEducationDG();
            textBox1.Text = String.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Education.Remove(ed);
            updateEducationDG();
            textBox1.Text = String.Empty;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Education edu in Education)
                {
                    if (edu.Name == comboBox4.SelectedItem.ToString())
                    {
                        edu.setNewCategory = textBox2.Text;
                        textBox2.Text = String.Empty;
                        updateCategoryDG();
                    }
                }
            }
            catch { }
        }

        void updateCategoryDG()
        {
            KategoryDG.Rows.Clear();
            foreach (Education edu in Education)
            {
                foreach (string cat in edu.categories)
                {
                    KategoryDG.Rows.Add(edu.Name, cat);
                }
            }
        }
        string tempCat;
        private void KategoryDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tempCat = textBox2.Text;
            KategoryDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            textBox2.Text = KategoryDG.Rows[e.RowIndex].Cells[1].Value.ToString();
            foreach (Education edu in Education)
            {
                if (edu.Name == textBox1.Text) { ed = edu; break; }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //foreach(Education edu in Education)
            //{
            //    foreach(string cat in edu.categories)
            //   {
            //       if (cat == tempCat) cat = textBox2.Text;
            //   }
            // }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (Education edu in Education)
            {
                foreach (string cat in edu.categories)
                {
                    if (cat == tempCat) edu.categories.Remove(cat);
                }
            }
            textBox2.Text = String.Empty;
            updateCategoryDG();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            foreach(Education edu in Education)
            {
                if(edu.Name == comboBox2.SelectedItem.ToString())
                {
                    foreach(string cat in edu.categories)
                    {
                        comboBox3.Items.Add(cat);
                    }
                }
            }


        }
    }
}

