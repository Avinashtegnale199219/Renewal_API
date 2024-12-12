using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_RENEWAL_TRANS_BO
{
    public class FD_RenewalBO
    {
        public FDR_DetailsBO investmentdtls { get; set;}
        public HoldersBO jointholdersdtls { get; set; }
        //public NomineeBO fdrnominee { get; set; }

        //public Bank_DetailsBO bankdetails { get; set; }
        //public List<HoldersBO> jointholdersdtls { get; set; }

        public List<ProvisionalNomineeBO> folionominee { get; set; }
    }
    public class FDR_DetailsBO
    {
        public string fdrno { get; set; }
        public string fdrdate { get; set; }
        public string matudate { get; set; }
        public string fdramt { get; set; }
        public string matuamt { get; set; }
        public string categorycode { get; set; }
        public string categorydesc { get; set; }
        public string schemecode { get; set; }
        public string schemedesc { get; set; }
        public string intfreq { get; set; }
        public string tenure { get; set; }
         public string intrate { get; set; }
        public string renewaltype { get; set; }
        public string autorenewal { get; set; }
        public string nomineename { get; set; }
        public string nomineedob { get; set; }
        public string nomineerelation { get; set; }
        public string guardianname { get; set; }
        public string guardianadd1 { get; set; }
        public string guardianadd2 { get; set; }
        public string guardianadd3 { get; set; }

        public string guardiancity { get; set; }
        public string guardianpincode { get; set; }

        public string guardiancountry { get; set; }
        public string guardianstate { get; set; }

        public string guardiandistrict { get; set; }
        public string nomineeseq { get; set; }

         public string micrcode { get; set; }
        public string neftcode { get; set; }
        public string bankname { get; set; }
        public string branchname { get; set; }
        public string bankaccountno { get; set; }

      
    }
    // public class NomineeBO
    // {
    //     public string nomineename { get; set; }
    //     public string nomineedob { get; set; }
    //     public string nomineerelation { get; set; }
    //     public string guardianname { get; set; }
    //     public string nomineedtlid { get; set; }
    // }
    public class HoldersBO
    {
        public string fhisckyccompliant { get; set; }
        public string fhisamlcompliant { get; set; }
        public string shname { get; set; }
        public string shmob { get; set; }
        public string shseq { get; set; }
        public string shpan { get; set; }
        public string shdob { get; set; }

        public string shisckyccompliant { get; set; }
        public string shisamlcompliant { get; set; }

        public string thname { get; set; }
        public string thmob { get; set; }
        public string thseq { get; set; }
        public string thpan { get; set; }
        public string thdob { get; set; }
        public string thisckyccompliant { get; set; }
        public string thisamlcompliant { get; set; }
    }

    // public class Bank_DetailsBO
    // {
    //     public string micrcd { get; set; }
    //     public string neftcd { get; set; }
    //     public string bankname { get; set; }
    //     public string branchname { get; set; }
    //     public string bankaccno { get; set; }
    // }

    public class ProvisionalNomineeBO
    {
        public string nomineeseq { get; set; }
        public string nomineename { get; set; }
        public string nomineerelation { get; set; }
        public string nomineedob { get; set; }
        public string? guardianname { get; set; }
        public string? guardianadd1 { get; set; }
        public string? guardianadd2 { get; set; }
        public string? guardianadd3 { get; set; }

        public string? guardiancity { get; set; }
        public string? guardianpincode { get; set; }

        public string? guardiancountry { get; set; }
        public string? guardianstate { get; set; }

        public string? guardiandistrict { get; set; }
    }
}
