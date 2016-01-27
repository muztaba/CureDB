using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharma.Utility;
namespace Pharmachy
{
   public class MedicineDAL
    {
       public void SaveMedicine(MedicineInfo obj)
       {
           string Qry = "INSERT INTO [CureDB].[dbo].[MedicineInfo]([MedicineID],[MedicineName],[Contains],[DosageId],[Manufacturer],[Price])VALUES('"+obj.MedicineID+"','"+obj.MedicineBrandName+"','"+obj.Contains+"','"+obj.Dosage+"','"+obj.Manufacturar+"',"+obj.Price+") ";
           DbUtility.ExecuteQuery(Qry);
       }

       public void UpdateMedicine(MedicineInfo obj)
       {
           string Qry = "update MedicineInfo set MedicineName='" + obj.MedicineBrandName + "',[Contains]='" + obj.Contains + "',DosageId='" + obj.Dosage + "',Manufacturer='" + obj.Manufacturar + "',Price='" + obj.Price + "' where MedicineID='" + obj.MedicineID + "'";

           
           DbUtility.ExecuteQuery(Qry);
       }

       public void DeleteMedicine(MedicineInfo obj)
       {
           string Qry = "DELETE FROM MedicineInfo WHERE MedicineID='" + obj.MedicineID + "'";


           DbUtility.ExecuteQuery(Qry);
       }



    }
}
