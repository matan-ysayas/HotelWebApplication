using HotelWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApplication.Controllers.api
{
    public class OrdersController : ApiController
    {
        static string connectionString = "Data Source=.;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        HotelDBDataContext HotelDB=new HotelDBDataContext(connectionString);
        // GET: api/Orders
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(HotelDB.Orders.ToList());

            }catch(SqlException ex)
            {
                return BadRequest( ex.Message );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Orders/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(HotelDB.Orders.First((item)=>item.Id == id));

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Orders
        public IHttpActionResult Post([FromBody]Order value)
        {
            try
            {
                HotelDB.Orders.InsertOnSubmit(value);
                HotelDB.SubmitChanges();
                return Ok("item was add");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Orders/5
        public IHttpActionResult Put(int id, [FromBody]Order value)
        {
            try
            {
               Order order=HotelDB.Orders.First((item)=>item.Id == id);
                order.CustomerId = value.CustomerId;
                order.NumofEmployee = value.NumofEmployee;
                order.OrderDate = value.OrderDate;
                order.MoneyPaid=value.MoneyPaid;
                order.TotalPrice=value.TotalPrice;
                HotelDB.SubmitChanges();
                return Ok("item was update");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Orders/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                HotelDB.Orders.DeleteOnSubmit(HotelDB.Orders.First((item)=>item.Id==id));

                HotelDB.SubmitChanges();
                return Ok("Item deleted");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
