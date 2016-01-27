using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharma.Utility;

namespace Pharmachy
{
    class UnitInfoDAL
    {
        public void SaveUnit(UnitInfo obj)
        {
            string Qry = "INSERT INTO [CureDB].[dbo].[Unit]([UnitID],[UnitName])VALUES('" + obj.UnitID + "','" + obj.UnitName + "') ";
            DbUtility.ExecuteQuery(Qry);
        }

        public void UpdateUnit(UnitInfo obj)
        {
            string Qry = "update Unit set UnitName='" + obj.UnitName + "'where UnitID='" + obj.UnitID + "'";


            DbUtility.ExecuteQuery(Qry);
        }

        public void DeleteUnit(UnitInfo obj)
        {
            string Qry = "DELETE FROM Unit WHERE UnitID='" + obj.UnitID + "'";


            DbUtility.ExecuteQuery(Qry);
        }
    }
}
