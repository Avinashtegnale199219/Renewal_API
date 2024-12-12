using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_RENEWAL_TRANS_BO
{
    public class FD_Save_Renewal_BO
    {


        public FD_Renewal_Config_BO investmentdtls { get; set; }

        public HolderVerificationBO holderverification { get; set; }

        public FD_Renewal_Additional_BO additionaldtls { get; set; }


        //public FD_Bank_Details_BO bankdetails { get; set; }

        //public NomineeBO nominee { get; set; }

       

    }
}
