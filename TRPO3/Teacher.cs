using System;

namespace TRPO3
{
    public class Teacher
    {
        private string _FIO, _Education, _Category;
        
        public Teacher(string FIO, string Education, string Category)
        {
            this._FIO = FIO;
            this._Education = Education;
            this._Category = Category;
        }

        public string sFIO
        {
            get { return this._FIO; }
            set { this._FIO = value is string ? value : null; }
        }

        public string sEducation
        {
            get { return this._Education; }
            set { this._Education = value is string ? value : null; }
        }

        public string sCategory
        {
            get { return this._Category; }
            set { this._Category = value is string ? value : null; }
        }
    }
}
