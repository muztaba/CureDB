using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharma.Utility;

namespace Pharmachy
{
    class DosageDAL
    {
        public void SaveDosage(DosageInfo obj)
        {
            string Qry = "INSERT INTO [CureDB].[dbo].[DosageForm]([DosageID],[DosageName])VALUES('" + obj.DosageId + "','" + obj.DosageName + "') ";
            DbUtility.ExecuteQuery(Qry);
        }

        public void UpdateDosage(DosageInfo obj)
        {
            string Qry = "update DosageForm set DosageName='" + obj.DosageName + "',DosageId='" + obj.DosageId + "'where DosageID='" + obj.DosageId + "'";


            DbUtility.ExecuteQuery(Qry);
        }

        public void DeleteDosage(DosageInfo obj)
        {
            string Qry = "DELETE FROM DosageForm WHERE DosageID='" + obj.DosageId + "'";


            DbUtility.ExecuteQuery(Qry);
        }

    }
}
