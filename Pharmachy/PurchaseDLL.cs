using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharma.Utility;

namespace Pharmachy
{
    class PurchaseDLL
    {
        public bool Save(PurchaseInfo obj)
        {
            string Qry = "INSERT INTO [CureDB].[dbo].[PurchaseInfo]([PurchaseID],[PurchaseDate],[SupplierID],[PurchaseQty],[PurchaseValue],[UpdatedComputer])VALUES('" + obj.PurchaseId + "','" + obj.PurchaseDate + "','" + obj.SupplierId + "'," + obj.Quantity + "," + obj.Price + ",'" + obj.UpdateComputer + "') ";
            DbUtility.ExecuteQuery(Qry);
            return true;
        }

        public bool Update(PurchaseInfo obj)
        {
            String Qry = "update PurchaseInfo set SupplierID= '" + obj.SupplierId + "', PurchaseQty= " + obj.Quantity + ", PurchaseValue= " + obj.Price + ", [UpdatedDate]='" + obj.UpdateDate + "', UpdatedComputer= '" + obj.UpdateComputer + "' where PurchaseID= '" + obj.PurchaseId + "'";
            DbUtility.ExecuteQuery(Qry);
            return true;
        }

        public bool Delete(PurchaseInfo obj)
        {
            String Qry = "DELETE FROM PurchaseInfo WHERE PurchaseID='" + obj.PurchaseId + "'";
            DbUtility.ExecuteQuery(Qry);
            return true;
        }
    }
}

