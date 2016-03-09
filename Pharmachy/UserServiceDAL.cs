using System;
using System.Collections.Generic;
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

            if (obj == "" || obj == null)
            {
                return null;
            }
            
            retriveUser.UserName = user.UserName;
            retriveUser.UserPassword = (string)obj;

            return retriveUser;
        }
    }
}
