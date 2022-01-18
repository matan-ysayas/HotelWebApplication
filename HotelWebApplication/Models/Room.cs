using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebApplication.Models
{
    public class Room
    {
        public int ID;
        public int RoomNum;
        public string TypeOfRoom;
        public bool IsAvailable;
        public int Price;

        public Room(int iD, int roomNum, string typeOfRoom, bool isAvailable, int price)
        {
            ID = iD;
            RoomNum = roomNum;
            TypeOfRoom = typeOfRoom;
            IsAvailable = isAvailable;
            Price = price;
        }
    }
}