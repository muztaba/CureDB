using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmachy
{
    class DosageBLL
    {
        private DosageDAL dalObj;
        public void SaveDosage(DosageInfo obj)
        {
            dalObj = new DosageDAL();
            dalObj.SaveDosage(obj);
        }

        public void UpdateDosage(DosageInfo obj)
        {
            dalObj = new DosageDAL();
            dalObj.UpdateDosage(obj);
        }

        public void DeleteDosage(DosageInfo obj)
        {
            dalObj = new DosageDAL();
            dalObj.DeleteDosage(obj);
        }
    }
}
