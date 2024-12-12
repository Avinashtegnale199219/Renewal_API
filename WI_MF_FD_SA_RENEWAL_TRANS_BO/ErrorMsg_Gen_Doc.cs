using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI_MF_FD_SA_RENEWAL_TRANS_BO
{
    public class ErrorMsg_Renewal_Trans
    {
        public static readonly ReadOnlyDictionary<string, KeyValuePair<string, string>> ErrorMsgs = new ReadOnlyDictionary<string, KeyValuePair<string, string>>(
     new Dictionary<string, KeyValuePair<string, string>>(){

             //Generate Doc validation
              {"foliono",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0001","Folio no can't be blank.")},
              {"fdrno",new KeyValuePair<string, string>("MFFDSUP-API-RW-VAL-0002","Fdr no can't be blank.")},
    });
    }
}
