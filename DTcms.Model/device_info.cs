using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public partial class device_info
    {
        public device_info()
        { }
        #region Model
        private int _id;
        private string _install_address;
        private string _telephone;
        private string _install_date;
        private string _install_person;
        private string _ph;
        private string _yangqi;
        private int _device_ids;
        private int _shenhe;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string install_address
        {
            get { return _install_address; }
            set { _install_address = value; }
        }

        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public string install_date
        {
            get { return _install_date; }
            set { _install_date = value; }
        }

        public string install_person
        {
            get { return _install_person; }
            set { _install_person = value; }
        }

        public string ph
        {
            get { return _ph; }
            set { _ph = value; }
        }

        public string yangqi
        {
            get { return _yangqi; }
            set { _yangqi = value; }
        }

        public int device_ids
        {
            get { return _device_ids; }
            set { _device_ids = value; }
        }

        public int shenhe
        {
            get { return _shenhe;}
            set { _shenhe = value;}
        }
        #endregion Model
    }
}
