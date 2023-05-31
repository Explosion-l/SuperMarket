using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{

    public class GoodsModel
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Goods> GetGoods(string keyword)
        {
            //实例化数据库上下文类
            SuperMarketEntities db = new SuperMarketEntities();
            //获取数据库中数据
            var data = db.Goods.ToList();
            //搜索的关键字是否为空
            if (!string.IsNullOrEmpty(keyword))
            {
                //获取到的数据库信息中是否含有关键字
                data = data.Where(p => p.GoodsName.Contains(keyword)).ToList();
            }
            return data;
        }
        /// <summary>
        /// 删除物品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelGoods(int id)
        {
            //实例化数据库上下文类
            SuperMarketEntities db = new SuperMarketEntities();
            //根据id获得该条信息
            var data = db.Goods.Where(p => p.ID == id).FirstOrDefault();
            if (data != null)
            {
                //删除信息
                db.Goods.Remove(data);
                //保存操作
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Goods GetSinalGoods(int id)
        {
            //实例化数据库上下文类
            SuperMarketEntities db = new SuperMarketEntities();
            //根据id获得单条物品信息
            var data = db.Goods.Where(p => p.ID == id).FirstOrDefault();
            return data;
        }
        /// <summary>
        /// 修改单条信息
        /// </summary>
        /// <param name="good"></param>
        public void UpdateSingelGoods(Goods good)
        {
            //实例化数据库上下文类
            SuperMarketEntities db = new SuperMarketEntities();
            //根据id获得单条物品信息
            var data = db.Goods.Where(p => p.ID == good.ID).FirstOrDefault();
            //对拿出来的信息重新赋值
            data.GoodsName = good.GoodsName;
            data.Price = good.Price;
            data.Count = good.Count;
            //保存修改
            db.SaveChanges();
        }
        /// <summary>
        /// 增加单条信息
        /// </summary>
        /// <param name="good"></param>
        public void AddGoods(Goods good)
        {
            //实例化数据库上下文类
            SuperMarketEntities db = new SuperMarketEntities();
            //增加数据
            db.Goods.Add(good);
            //保存修改
            db.SaveChanges();
        }
    }
}