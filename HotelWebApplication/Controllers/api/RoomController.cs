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
    public class RoomController : ApiController
    {
        string connectionString = "Data Source=.;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";

        // GET: api/Room
        public IHttpActionResult Get()
        {
            try
            {
                List<Room> rooms = new List<Room>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT* FROM Room";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            rooms.Add(new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetBoolean(3), reader.GetInt32(4)));
                        }
                        return Ok(new { rooms });
                    }
                    connection.Close();
                    return Ok(new { rooms });
                }
            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }
        }

        // GET: api/Room/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT * FROM Room WHERE Id={id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Room room = new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetBoolean(3), reader.GetInt32(4));
                            return Ok(new { room });
                        }

                    }
                    connection.Close();
                    return Ok(new { Message = "not found" });
                }

            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }
        }
        // POST: api/Room
        public IHttpActionResult Post([FromBody] Room value)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"INSERT INTO Room (RoomNum,TypeOfRoom,IsAvailable,Price) VALUES({value.RoomNum},'{value.TypeOfRoom}','{value.IsAvailable}',{value.Price} )";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return Ok(new { message = "item was update" });

                }

            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });

            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }
        }



        // PUT: api/Room/5
        public IHttpActionResult Put(int id, [FromBody] Room value)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"UPDATE Room SET  RoomNum={value.RoomNum},TypeOfRoom='{value.TypeOfRoom}',IsAvailable='{value.IsAvailable}',Price={value.Price} WHERE Id={id} ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return Ok(new { message = "the Professor was update" });

                }

            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }

        }




        // DELETE: api/Room/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"DELETE  FROM Room WHERE Id={id} ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return Ok(new { message = "item was Deleted" });

                }

            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }
        }
    }
}
