using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMarket.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (SuperMarketEntities db = new SuperMarketEntities())
            {
                List<Goods> goods = db.Goods.ToList(); 
                ViewBag.list = goods;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            GoodsModel good = new GoodsModel();
            good.DelGoods(id);
            return View();
        }
    }
}