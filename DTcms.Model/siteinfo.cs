using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
   public partial  class siteinfo
    {
        #region Model
        private int _id;
        private string _stationId;
        private string _stationName;
        private String _stationType;
        private DateTime _createTime = DateTime.Now;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string stationId
        {
            get { return _stationId; }
            set { _stationId = value; }
        }

        public string stationName
       {
           get {return _stationName;}
           set {_stationName=value;}
       }

        public string stationType
        {
            get { return _stationType; }
            set { _stationType = value; }
        }

        public DateTime createTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        #endregion Model


    }
}
