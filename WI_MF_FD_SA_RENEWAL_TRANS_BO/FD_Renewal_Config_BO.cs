using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_RENEWAL_TRANS_BO
{
    public class FD_Renewal_Config_BO
    {
        public string fdrno { get; set; }
        public string foliono { get; set; }

        public string transrefno { get; set; }
        public string categorycode { get; set; }

        public string categorydesc { get; set; }

        public string schemecode { get; set; }

        public string schemedesc { get; set; }

        public string intfreq { get; set; }

        //public string intfrqdec { get; set; }
        public string tenure { get; set; }
        public string intrate { get; set; }

        public string fdramt { get; set; }

        public string renewalfordec { get; set; }
     
        public string micrcode { get; set; }

        public string neftcode { get; set; }
        public string bankname { get; set; }
        public string branchname { get; set; }
        public string bankaccountno { get; set; }

          public string nomineename { get; set; }
        public string nomineerelation { get; set; }

        public string nomineedob { get; set; }
        public string guardianname { get; set; }
      
        public string nomineeseq { get; set; }

         public string guardianadd1 { get; set; }

         public string? guardianadd2 { get; set; }
         public string? guardianadd3 { get; set; }
        public string guardiancity { get; set; }
        public string guardianpin { get; set; }
        public string guardiancountry { get; set; }
        public string guardianstate { get; set; }
        public string guardiandistrict { get; set; }

      public string istncaccepted { get; set; }
        //private string _Fdr_No;
        //private string _Folio_No;
        //private string _Mynewno;
        //private string _Old_Mynewno;
        //private string _CategoryCode;
        //private string _CategoryDec;
        //private string _EmployeeCode;
        //private string _SchemeCode;
        //private string _SchemeDec;
        //private string _IntFrqCode;
        //private string _intFrqDec;
        //private string _TenureCode;
        //private string _TenureDec;
        //private string _Tenure;
        //private string _IntRate;
        //private string _FdrAmt;
        //private string _RenewalForCode;
        //private string _RenewalForDec;
        //private string _ExistingFDRNo;
        //private string _FirstHolderDtlId;
        //private string _BankDtlId;
        //private string _SecoundHolderDtlId;
        //private string _ThirdHolderDtlId;
        //private string _SecoundHolderDtltbl;
        //private string _ThirdHolderDtltbl;

        //private string _NomineeDtlId;
        //private bool _PaperlessDisclamer;
        //private bool _IsFreshRenewal;
        //private string _NewBrokerCode;
        //private string _NewBrokerName;
        //private string _OldBrokerCode;
        //private string _OldBrokerName;
        //private bool _IsBrokerremove;


        //private string _RelationshipManager_Code;
        //private string _RelationshipManager_Dec;

        //public string FH_hold_seq { get; set; }
        //public string SH_hold_seq { get; set; }
        //public string TH_hold_seq { get; set; }
        //public string OTP { get; set; }
        //public string Holding_sequnce { get; set; }
        //public string Verification_Type { get; set; }

        //public string Verification_By { get; set; }
        //public string nomineename { get; set; }

        //public string nomineerelation { get; set; }
        //public string SH_HolderName { get; set; }

        //public string TH_HolderName { get; set; }

        //public string SH_hold_type { get; set; }
        //public string TH_hold_type { get; set; }

        //public string Nom_Guardian { get; set; }

        //public string Nom_DOB { get; set; }

        //public string Scheme_Code { get; set; }

        //private string _ApplicationNo;

        //public string Fdr_No
        //{
        //    get
        //    {
        //        return _Fdr_No;
        //    }

        //    set
        //    {
        //        _Fdr_No = value;
        //    }
        //}

        //public string Folio_No
        //{
        //    get
        //    {
        //        return _Folio_No;
        //    }

        //    set
        //    {
        //        _Folio_No = value;
        //    }
        //}

        //public string Mynewno
        //{
        //    get
        //    {
        //        return _Mynewno;
        //    }

        //    set
        //    {
        //        _Mynewno = value;
        //    }
        //}

        //public string categorycode
        //{
        //    get
        //    {
        //        return categorycode;
        //    }

        //    set
        //    {
        //        categorycode = value;
        //    }
        //}

        //public string categorydec
        //{
        //    get
        //    {
        //        return categorydec;
        //    }

        //    set
        //    {
        //        categorydec = value;
        //    }
        //}

        //public string EmployeeCode
        //{
        //    get
        //    {
        //        return _EmployeeCode;
        //    }

        //    set
        //    {
        //        _EmployeeCode = value;
        //    }
        //}

        //public string schemecode
        //{
        //    get
        //    {
        //        return schemecode;
        //    }

        //    set
        //    {
        //        schemecode = value;
        //    }
        //}

        //public string schemedec
        //{
        //    get
        //    {
        //        return schemedec;
        //    }

        //    set
        //    {
        //        schemedec = value;
        //    }
        //}

        //public string intfrqcode
        //{
        //    get
        //    {
        //        return intfrqcode;
        //    }

        //    set
        //    {
        //        intfrqcode = value;
        //    }
        //}

        //public string intfrqdec
        //{
        //    get
        //    {
        //        return intfrqdec;
        //    }

        //    set
        //    {
        //        intfrqdec = value;
        //    }
        //}

        //public string tenurecode
        //{
        //    get
        //    {
        //        return tenurecode;
        //    }

        //    set
        //    {
        //        _TenureCode = value;
        //    }
        //}

        //public string TenureDec
        //{
        //    get
        //    {
        //        return _TenureDec;
        //    }

        //    set
        //    {
        //        _TenureDec = value;
        //    }
        //}

        //public string Tenure
        //{
        //    get
        //    {
        //        return _Tenure;
        //    }

        //    set
        //    {
        //        _Tenure = value;
        //    }
        //}

        //public string IntRate
        //{
        //    get
        //    {
        //        return _IntRate;
        //    }

        //    set
        //    {
        //        _IntRate = value;
        //    }
        //}

        //public string FdrAmt
        //{
        //    get
        //    {
        //        return _FdrAmt;
        //    }

        //    set
        //    {
        //        _FdrAmt = value;
        //    }
        //}

        //public string RenewalForCode
        //{
        //    get
        //    {
        //        return _RenewalForCode;
        //    }

        //    set
        //    {
        //        _RenewalForCode = value;
        //    }
        //}

        //public string RenewalForDec
        //{
        //    get
        //    {
        //        return _RenewalForDec;
        //    }

        //    set
        //    {
        //        _RenewalForDec = value;
        //    }
        //}

        //public string ExistingFDRNo
        //{
        //    get
        //    {
        //        return _ExistingFDRNo;
        //    }

        //    set
        //    {
        //        _ExistingFDRNo = value;
        //    }
        //}

        //public string BankDtlId
        //{
        //    get
        //    {
        //        return _BankDtlId;
        //    }

        //    set
        //    {
        //        _BankDtlId = value;
        //    }
        //}

        //public string SecoundHolderDtlId
        //{
        //    get
        //    {
        //        return _SecoundHolderDtlId;
        //    }

        //    set
        //    {
        //        _SecoundHolderDtlId = value;
        //    }
        //}

        //public string ThirdHolderDtlId
        //{
        //    get
        //    {
        //        return _ThirdHolderDtlId;
        //    }

        //    set
        //    {
        //        _ThirdHolderDtlId = value;
        //    }
        //}

        //public string NomineeDtlId
        //{
        //    get
        //    {
        //        return _NomineeDtlId;
        //    }

        //    set
        //    {
        //        _NomineeDtlId = value;
        //    }
        //}


        //public bool PaperlessDisclamer
        //{
        //    get
        //    {
        //        return _PaperlessDisclamer;
        //    }

        //    set
        //    {
        //        _PaperlessDisclamer = value;
        //    }
        //}

        //public bool IsFreshRenewal
        //{
        //    get
        //    {
        //        return _IsFreshRenewal;
        //    }

        //    set
        //    {
        //        _IsFreshRenewal = value;
        //    }
        //}

        //public string FirstHolderDtlId
        //{
        //    get
        //    {
        //        return _FirstHolderDtlId;
        //    }

        //    set
        //    {
        //        _FirstHolderDtlId = value;
        //    }
        //}

        //public string Old_Mynewno
        //{
        //    get
        //    {
        //        return _Old_Mynewno;
        //    }

        //    set
        //    {
        //        _Old_Mynewno = value;
        //    }
        //}

        //public string SecoundHolderDtltbl
        //{
        //    get
        //    {
        //        return _SecoundHolderDtltbl;
        //    }

        //    set
        //    {
        //        _SecoundHolderDtltbl = value;
        //    }
        //}

        //public string ThirdHolderDtltbl
        //{
        //    get
        //    {
        //        return _ThirdHolderDtltbl;
        //    }

        //    set
        //    {
        //        _ThirdHolderDtltbl = value;
        //    }
        //}

        //public string NewBrokerCode
        //{
        //    get
        //    {
        //        return _NewBrokerCode;
        //    }

        //    set
        //    {
        //        _NewBrokerCode = value;
        //    }
        //}

        //public string OldBrokerCode
        //{
        //    get
        //    {
        //        return _OldBrokerCode;
        //    }

        //    set
        //    {
        //        _OldBrokerCode = value;
        //    }
        //}

        //public bool IsBrokerremove
        //{
        //    get
        //    {
        //        return _IsBrokerremove;
        //    }

        //    set
        //    {
        //        _IsBrokerremove = value;
        //    }
        //}

        //public string NewBrokerName
        //{
        //    get
        //    {
        //        return _NewBrokerName;
        //    }

        //    set
        //    {
        //        _NewBrokerName = value;
        //    }
        //}

        //public string OldBrokerName
        //{
        //    get
        //    {
        //        return _OldBrokerName;
        //    }

        //    set
        //    {
        //        _OldBrokerName = value;
        //    }
        //}

        //public string RelationshipManager_Code
        //{
        //    get
        //    {
        //        return _RelationshipManager_Code;
        //    }

        //    set
        //    {
        //        _RelationshipManager_Code = value;
        //    }
        //}

        //public string RelationshipManager_Dec
        //{
        //    get
        //    {
        //        return _RelationshipManager_Dec;
        //    }

        //    set
        //    {
        //        _RelationshipManager_Dec = value;
        //    }
        //}


        //public string ApplicationNo
        //{
        //    get
        //    {
        //        return _ApplicationNo;

        //    }
        //    set
        //    {
        //        _ApplicationNo = value;
        //    }
        //}
    }
}
