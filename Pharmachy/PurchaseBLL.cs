using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmachy
{
    class PurchaseBLL
    {
        public void Save(PurchaseInfo obj)
        {
            PurchaseDLL objDll = new PurchaseDLL();
            objDll.Save(obj);
        }

        public void Update(PurchaseInfo obj)
        {
            PurchaseDLL objDll = new PurchaseDLL();
            objDll.Update(obj);
        }

        public void Delete(PurchaseInfo obj)
        {
            PurchaseDLL objDll = new PurchaseDLL();
            objDll.Delete(obj);
        }
    }
}
