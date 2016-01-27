using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmachy
{
   public class MedicineInfoBLL
   {
       private MedicineDAL dalObj;
       public void SaveMedicine(MedicineInfo obj)
       {
           dalObj=new MedicineDAL();
           dalObj.SaveMedicine(obj);
       }

       public void UpdateMedicine(MedicineInfo obj)
       {
           dalObj=new MedicineDAL();
           dalObj.UpdateMedicine(obj);
       }

       public void DeleteMedicine(MedicineInfo obj)
       {
           dalObj=new MedicineDAL();
           dalObj.DeleteMedicine(obj);
       }


    }
}
