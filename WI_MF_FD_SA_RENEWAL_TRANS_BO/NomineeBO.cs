using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_RENEWAL_TRANS_BO
{
    public class NomineeBO
    {
        public string name { get; set; }
        public string relation { get; set; }
        public string guardianname { get; set; }
        public string dob { get; set; }

        public string nomseq { get; set; }

         public string guardianadd1 { get; set; }
        public string guardiancity { get; set; }
        public string guardianpin { get; set; }
        public string guardiancountry { get; set; }
        public string guardianstate { get; set; }
        public string guardiandistrict { get; set; }
               
    }
}
