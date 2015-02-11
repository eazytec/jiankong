using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public partial class discharge_companies
    {
        public discharge_companies()
        {}
        #region Model
        private int _id;
        private string _name;
        private string _address;
        private string _contact_person;
        private string _telephone;
        private int _sewage_id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string contact_person
        {
            get { return _contact_person; }
            set { _contact_person = value; }
        }

        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public int sewage_id
        {
            get { return _sewage_id; }
            set { _sewage_id = value; }
        }
        #endregion Model
    }
}
