using HotelWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HotelWebApplication.Controllers.api
{
    public class GuestController : ApiController
    {
        HotelContext HotelDB = new HotelContext();
        // GET: api/Guest
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(HotelDB.Guest.ToList());
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

        // GET: api/Guest/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                return Ok(await HotelDB.Guest.FindAsync(id));
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

        // POST: api/Guest
        public async Task<IHttpActionResult> Post([FromBody]Guest value)
        {

            try
            {
                HotelDB.Guest.Add(value);
                await HotelDB.SaveChangesAsync();
                return Ok("item was ADD");
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

        // PUT: api/Guest/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Guest value)
        {
            try
            {
                Guest guest = await HotelDB.Guest.FindAsync(id);
               guest.Id = value.Id;
                guest.FirstName = value.FirstName;
                guest.LastName = value.LastName;
                guest.Gender = value.Gender;
                guest.CheckInDate = value.CheckInDate;
                guest.yaerOfBirth= value.yaerOfBirth;
             
                await HotelDB.SaveChangesAsync();
                return Ok("itam was update");

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

        // DELETE: api/Guest/5
        public async Task<IHttpActionResult>Delete(int id)
        {
            try
            {
               HotelDB.Guest.Remove(await HotelDB.Guest.FindAsync(id));

                return Ok("item was deleted");

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
