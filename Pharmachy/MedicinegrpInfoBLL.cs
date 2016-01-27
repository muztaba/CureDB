using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmachy
{
    class MedicinegrpInfoBLL
    {
        private MedicinegrpInfoDAL dalObj;

        public void SaveMedicinegrp(MedicinegrpInfo obj)
        {
            dalObj = new MedicinegrpInfoDAL();
            dalObj.SaveMedicinegrp(obj);
        }

        public void UpdateMedicinegrp(MedicinegrpInfo obj)
        {
            dalObj = new MedicinegrpInfoDAL();
            dalObj.UpdateMedicinegrp(obj);
        }

        public void DeleteMedicinegrp(MedicinegrpInfo obj)
        {
            dalObj = new MedicinegrpInfoDAL();
            dalObj.DeleteMedicinegrp(obj);
        }
    }
}
