using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharma.Utility;

namespace Pharmachy
{
    class MedicinegrpInfoDAL
    {
        public void SaveMedicinegrp(MedicinegrpInfo obj)
        {
            string Qry = "INSERT INTO [CureDB].[dbo].[MedicineGroup]([GroupID],[GroupName])VALUES('" + obj.GroupID + "','" + obj.GroupName + "') ";
            DbUtility.ExecuteQuery(Qry);
        }

        public void UpdateMedicinegrp(MedicinegrpInfo obj)
        {
            string Qry = "update MedicineGroup set GroupName='" + obj.GroupName + "'where GroupID='" + obj.GroupID + "'";


            DbUtility.ExecuteQuery(Qry);
        }

        public void DeleteMedicinegrp(MedicinegrpInfo obj)
        {
            string Qry = "DELETE FROM MedicineGroup WHERE GroupID='" + obj.GroupID + "'";


            DbUtility.ExecuteQuery(Qry);
        }
    }
}
