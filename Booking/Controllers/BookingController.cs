using Booking.Models.DbModels;
using Booking.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext db;

        public BookingController(AppDbContext db)
        {
            this.db = db;
            
            var hotels1 = this.db.hotels.ToList();
            if(hotels1.Count != 0) 
                this.db.hotels.RemoveRange(hotels1);
            this.db.SaveChanges();
            
            var rooms1 = this.db.rooms.ToList();
            if(rooms1.Count != 0) 
                this.db.rooms.RemoveRange(rooms1);
            this.db.SaveChanges();
            
            var hotel = new HotelModel
            {
                id = 0,
                name = "Kazan Palace",
                city = "Казань",
                description = "Центр Казани, около Баскет-холла"
            };
            this.db.hotels.Add(hotel);
            this.db.SaveChanges();
            
            var hotel1 = new HotelModel
            {
                id = 0,
                name = "Отель Overtop",
                city = "Москва",
                description = "Хороший отель и цены норм"
            };
            this.db.hotels.Add(hotel1);
            this.db.SaveChanges();

            var hotelAdd = this.db.hotels.FirstOrDefault(x => x.name == "Kazan Palace");
            var room = new RoomModel
            {
                id = 0,
                hotel_id = hotelAdd.id,
                seats = 3,
                price = 2000,
                begin_date = new DateTime(2021, 12, 1),
                end_date = new DateTime(2021, 12, 30)
            };
            this.db.rooms.Add(room);
            this.db.SaveChanges();
            
            var hotel1Add = this.db.hotels.FirstOrDefault(x => x.name == "Отель Overtop");
            var room1 = new RoomModel
            {
                id = 0,
                hotel_id = hotel1Add.id,
                seats = 1,
                price = 2000,
                begin_date = new DateTime(2021, 1, 1),
                end_date = new DateTime(2021, 12, 30)
            };
            this.db.rooms.Add(room1);
            this.db.SaveChanges();
            
            var room2 = new RoomModel
            {
                id = 0,
                hotel_id = hotel1Add.id,
                seats = 2,
                price = 2500,
                begin_date = new DateTime(2021, 1, 1),
                end_date = new DateTime(2021, 12, 30)
            };
            this.db.rooms.Add(room2);
            this.db.SaveChanges();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchModel model)
        {
            //получаем из бд список отелей, находящихся в указанном городе
            List<HotelModel> hotels = await db.hotels
                .Where(h => h.city == model.city).ToListAsync();
            if(hotels.Count == 0)
            {
                //написать - ОТЕЛИ НЕ НАЙДЕНЫ и выйти
               
            }
            //List<RoomModel> rooms = new List<RoomModel>();
            List<EntityModel> entities = new List<EntityModel>();
            //получаем из бд список комнат в отелях, находящихся в указанном
            //городе + проверяем их на вместимость и дату на заселение
            foreach (var h in hotels)
            {
                var tmp = await db.rooms
                    .Where(r => r.hotel_id == h.id && r.seats <= model.seats
                    && model.endDate >= r.begin_date 
                    && model.beginDate <= r.end_date).ToListAsync();
                if (tmp != null)
                {
                    //rooms.AddRange(tmp);
                    foreach(var t in tmp)
                    {
                        entities.Add(new EntityModel
                        {hotel_name = h.name, room_id = t.id, price = t.price, seats = t.seats});
                    }
                }
            }
            if(entities.Count == 0)
            {
                //написать - НОМЕРА НЕ НАЙДЕТ и выйти
                
            }
            return View(entities);
        }

        //отображение результата поиска
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
    }
}
