using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmachy
{
    class PharmacuticlesInfoBLL
    {
        private PharmacuticlesDAL dalObj;
        public void SavePharmacuticles(PharmacuticlesInfo obj)
        {
            dalObj = new PharmacuticlesDAL();
            dalObj.SavePharmacuticles(obj);
        }

        public void UpdatePharmacuticles(PharmacuticlesInfo obj)
        {
            dalObj = new PharmacuticlesDAL();
            dalObj.UpdatePharmacuticles(obj);
        }

        public void DeletePharmacuticles(PharmacuticlesInfo obj)
        {
            dalObj = new PharmacuticlesDAL();
            dalObj.DeletePharmacuticles(obj);
        }
    }
}
