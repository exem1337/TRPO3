using System;
using System.Collections.Generic;

namespace TRPO3
{
    public class Firm
    {
        private string _FirmName, _FirmAdress, _FirmPhone, _FirmEmail;
        private int _income;

        public Firm(string FirmName, string FirmAdress, string FirmPhone, string FirmEmail, int income)
        {
            this._FirmName = FirmName;
            this._FirmAdress = FirmAdress;
            this._FirmPhone = FirmPhone;
            this._FirmEmail = FirmEmail;
            this._income = income;
        }

        public int iIncome
        {
            get { return this._income; }
            set
            {
                this._income += value;
            }
        }

        public string sFirmName
        {
            get { return this._FirmName; }
            set { this._FirmName = value is string ? value : null; }
        }

        public string sFirmAdress
        {
            get { return this._FirmAdress; }
            set { this._FirmAdress = value is string ? value : null; }
        }

        public string sFirmPhone
        {
            get { return this._FirmPhone; }
            set { this._FirmPhone = value is string ? value : null; }
        }

        public string sFirmEmail
        {
            get { return this._FirmEmail; }
            set { this._FirmEmail = value is string ? value : null; }
        }

        public List<Course> courseList = new List<Course>();

        public List<Course> thisCourse
        {
            get { return courseList; }
        }

        public Course setThisCourse
        {
            set{ courseList.Add(value); }    
        }
    }
}
