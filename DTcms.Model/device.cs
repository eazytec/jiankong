using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public partial class device 
    {
        public device()
        { }
        #region Model
        private int _id;
        private string _device_id;
        private string _device_name;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string device_id
        {
            get { return _device_id; }
            set { _device_id = value; }
        }

        public string device_name
        {
            get { return _device_name; }
            set { _device_name = value; }
        }
        #endregion Model
    }
}
