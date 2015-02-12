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
        private string _createtime;

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


        #endregion Model


    }
}
