using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class UserModel
    {
        public void AddUser(Users user)
        {
            //实例化数据库上下文类
            SuperMarketEntities db = new SuperMarketEntities();
            //增加用户信息
            db.Users.Add(user);
            //保存修改
            db.SaveChanges();
        }
    }
}