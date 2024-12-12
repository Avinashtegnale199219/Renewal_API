using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_RENEWAL_TRANS_BO
{
    public class FD_Renewal_Additional_BO
    {
      

        public string clientipaddress { get; set; }

        public string serveripaddress { get; set; }

        public string browsertype { get; set; }

        public string browserversion { get; set; }

        public string browsermajorversion { get; set; }

        public string browserminorversion { get; set; }

        public string ismobiledevice { get; set; }
        public string? useragent { get; set; }
        public string? sessionid { get; set; }

        public string? sysrefno { get; set; }

    }
}
