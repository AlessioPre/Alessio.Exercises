using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exersises10
{
    internal class CommercialBank : CentralBank
    {
        public CommercialBank(string intermediaryName, string ceoName, string ceoSurname) : base(intermediaryName, ceoName, ceoSurname)
        {
        }


        public override void NotifyCentralBankCEOChanged(object sender, ChangeCEOEventArgs e)
        {
            base.NotifyCentralBankCEOChanged(sender, e);
        }
    }
}
