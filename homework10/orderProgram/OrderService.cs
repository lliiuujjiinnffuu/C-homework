using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    public class OrderService
    {

        public void Add(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Add(order);
                db.SaveChanges();
            }
        }

        public void DeleteOrder(String orderId)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("orderDetails").SingleOrDefault(o => o.orderNumber == orderId);
                db.OrderDetail.RemoveRange(order.orderDetails);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }
        public void DeleteDetail(String Id)
        {
            using (var db = new OrderDB())
            {
                var orderdetail = db.OrderDetail.SingleOrDefault(o => o.ID == Id);
                db.OrderDetail.Remove(orderdetail);
                db.SaveChanges();
            }
        }
        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                List<OrderDetails> odl = GetAllOrderDetails();
                foreach (OrderDetails details in order.orderDetails)
                {
                    bool exist = false;
                    foreach (OrderDetails detailed in odl)
                    {
                        if (detailed.ID == details.ID)
                        {
                            exist = true;
                            break;
                        }
                    }
                    db.Entry(details).State = EntityState.Modified;
                    if (!exist)
                    {
                       
                        db.OrderDetail.Add(details);
                    }
                }
                //order.orderDetails.ForEach(
                //    item => db.Entry(item).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public Order GetOrder(String Id)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("orderDetails").
                  SingleOrDefault(o => o.orderNumber == Id);
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("orderDetails").ToList<Order>();
            }
        }
        public List<OrderDetails> GetAllOrderDetails()
        {
            using (var db = new OrderDB())
            {
                return db.OrderDetail.ToList<OrderDetails>();
            }
        }

        public List<Order> QueryByCustormer(String custormer)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("orderDetails")
                  .Where(o => o.customerName.Equals(custormer)).ToList<Order>();
            }
        }

        public List<Order> QueryByGoods(String product)
        {
            using (var db = new OrderDB())
            {
                var query = db.Order.Include("orderDetails")
                  .Where(o => o.orderDetails.Where(
                    item => item.kindOfGoods.Equals(product)).Count() > 0);
                return query.ToList<Order>();
            }
        }




    }
}
