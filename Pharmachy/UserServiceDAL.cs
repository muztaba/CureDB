using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharma.Utility;

namespace Pharmachy
{
    class UserServiceDAL : IUserServiceDAL
    {
        public User GetUserInfo(User user)
        {
            String userName = user.UserName;
            User retriveUser = new User();
           
            object obj = DbUtility.GetColValue("userinfo", "user_password", "user_name", userName);

            String query = "select * from userinfo where user_name = '"+ userName +"' ";

            DataTable table = DbUtility.GetDataTable(query);
            


            /*if (obj == "" || obj == null)
            {
                return null;
            }*/
            
            /*retriveUser.UserName = user.UserName;
            retriveUser.UserPassword = (string)obj;*/

            foreach (DataRow row in table.Rows)
            {
                retriveUser.UserId = (int) row["user_id"];
                retriveUser.UserName = row["user_name"].ToString();
                retriveUser.UserPassword = row["user_password"].ToString();
            }
            return retriveUser;
        }
    }
}
