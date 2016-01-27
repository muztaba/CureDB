using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmachy
{
    internal class UnitInfoBLL
    {
        private UnitInfoDAL dalObj;

        public void SaveUnit(UnitInfo obj)
        {
            dalObj = new UnitInfoDAL();
            dalObj.SaveUnit(obj);
        }

        public void UpdateUnit(UnitInfo obj)
        {
            dalObj = new UnitInfoDAL();
            dalObj.UpdateUnit(obj);
        }

        public void Delete(UnitInfo obj)
        {
            dalObj = new UnitInfoDAL();
            dalObj.DeleteUnit(obj);
        }
    }
}