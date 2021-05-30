using System;

namespace TRPO3
{
    public class Students
    {
        private string _FIO, _phoneNumber, beginDate, endDate;

        public Students(string FIO, string phoneNumber, string beginDate, string endDate)
        {
            this._FIO = FIO;
            this._phoneNumber = phoneNumber;
            this.beginDate = beginDate;
            this.endDate = endDate;
        }

        public string sFIO
        {
            get { return this._FIO; }
            set { this._FIO = value is string ? value : null; }
        }

        public string sphoneNumber
        {
            get { return this._phoneNumber; }
            set { this._phoneNumber = value is string ? value : null; }
        }

        public string BeginDate
        {
            get { return this.beginDate; }
            set { this.beginDate = value is string ? value : null; }
        }

        public string EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value is string ? value : null; }
        }
    }
}
