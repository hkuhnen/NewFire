using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Mar31Fire
{

        public class eMail
        {
            public string emailAddress { get; set; }
        }

    public class eMailStatus
    {
        public string statusCode { get; set; }
    }
    public class Building
        {
            public string buildingPrimaryName { get; set; }

            public string buildingStatus { get; set; }

        }
        public class valCode
        {
            public string valId { get; set; }
        }

    public class valInfo
    {
        public string valString { get; set; }
    }

    public class userValidation
    {
        [DataMember]
        public string Token { get; set; }
        public string cookieInfo { get; set; }
    }

    public class confirmStatus
    {
        [DataMember]
        public bool statusCode { get; set; }
    }
}
