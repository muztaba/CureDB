using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharma.Utility;

namespace Pharmachy
{
    class PharmacuticlesDAL
    {

        public void SavePharmacuticles(PharmacuticlesInfo obj)
        {
            string Qry = "INSERT INTO [CureDB].[dbo].[Pharmacuticles]([PharmaID],[PharmaName],[Address],[CategoryLevel],)VALUES('" + obj.pharmaId + "','" + obj.pharmaName + "','" + obj.address + "','" + obj.catagories + "') ";
            DbUtility.ExecuteQuery(Qry);
        }

        public void UpdatePharmacuticles(PharmacuticlesInfo obj)
        {
            string Qry = "update PharmacuticlesInfo set PharmaName='" + obj.pharmaName + "',[Address]='" + obj.address + "',CatagoryLeve='" + obj.catagories + "' where PharmaID='" + obj.pharmaId + "'";


            DbUtility.ExecuteQuery(Qry);
        }

        public void DeletePharmacuticles(PharmacuticlesInfo obj)
        {
            string Qry = "DELETE FROM PharmacuticlesInfo WHERE PharmaID='" + obj.pharmaId + "'";


            DbUtility.ExecuteQuery(Qry);
        }
    }
}
