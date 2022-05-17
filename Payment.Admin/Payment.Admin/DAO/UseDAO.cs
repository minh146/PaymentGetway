using Common;
using Payment.Admin.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Admin.DAO
{
    public class UseDAO
    {
        private PaymentEntities db = null;
        public UseDAO()
        {
            db = new PaymentEntities();
        }
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.users.FirstOrDefault(x => x.user_name == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.pass.Trim() != passWord)
                {
                    return 0;
                }
                var aa = result.pass.Trim();
                //if (isLoginAdmin == true)
                //{
                //    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
                //    {
                //        if (result.Status == false)
                //        {
                //            return -1;
                //        }
                //        else
                //        {
                //            if (result.Password == passWord)
                //                return 1;
                //            else
                //                return -2;
                //        }
                //    }
                //    else
                //    {
                //        return -3;
                //    }
                //}
                //else
                //{
                //    if (result.Status == false)
                //    {
                //        return -1;
                //    }
                //    else
                //    {
                //        if (result.Password == passWord)
                //            return 1;
                //        else
                //            return -2;
                //    }
                //}
                return 1;
            }
        }
    }
}