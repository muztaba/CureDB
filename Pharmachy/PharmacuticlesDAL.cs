using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Pharma.Utility;

namespace Pharmachy
{
    class PharmacuticlesDAL
    {

        public void SavePharmacuticles(PharmacuticlesInfo obj)
        {
            string Qry = "INSERT INTO [CureDB].[dbo].[Pharmacuticles]([PharmaID],[PharmaName],[Address],[CategoryLevel])VALUES('" + obj.pharmaId + "','" + obj.pharmaName + "','" + obj.address + "','" + obj.catagories + "') ";
            DbUtility.ExecuteQuery(Qry);
        }

        public void UpdatePharmacuticles(PharmacuticlesInfo obj)
        {
            string Qry = "update Pharmacuticles set PharmaName='" + obj.pharmaName + "',[Address]='" + obj.address + "',CatagoryLeve='" + obj.catagories + "' where PharmaID='" + obj.pharmaId + "'";


            DbUtility.ExecuteQuery(Qry);
        }

        public void DeletePharmacuticles(PharmacuticlesInfo obj)
        {
            string Qry = "DELETE FROM Pharmacuticles WHERE PharmaID='" + obj.pharmaId + "'";


            DbUtility.ExecuteQuery(Qry);
        }

        public DataTable LoadPharmacuticlesTable()
        {
            const String query = "SELECT * FROM Pharmacuticles";
            
            return DbUtility.GetDataTable(query);
        }

        public String GetPharmaName(String PharmaID)
        {
            object obj = DbUtility.GetColValue("Pharmacuticles", "PharmaName", "PharmaID", PharmaID);

            if (obj != "" || obj != null)
            {
                return (String) obj;
            }
            return String.Empty;
        }
        
    }
}
