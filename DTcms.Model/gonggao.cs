using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public partial class gonggao
    {
        public gonggao()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _content;
        private string _name;
        private DateTime _date = DateTime.Now;
        private int _status;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime date
        {
            get { return _date; }
            set { _date = value; }

        }

        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion Model
    }
}
