using AutoMapper;
using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services
{
    public class Nearby : INearby
    {
        private readonly AppDbContext context;

        public Nearby(AppDbContext context)
        {
            this.context = context;
        }
        public double DegreesToRadians(float deg)
        {
            return deg * Math.PI / 180;
        }
        public async Task<IEnumerable<Hospital>> GetDistance(string myLocation)
        {
            var hospitals = await context.Hospitals.Include(x => x.Kind).OrderBy(x => x.Distance).ToListAsync();

            foreach (var item in hospitals)
            {
                item.MyLocation = myLocation;

                var lang = float.Parse(item.Location.Split(',')[0]);
                var lat = float.Parse(item.Location.Split(',')[1]);

                var MyLang = float.Parse(myLocation.Split(',')[0]);
                var MyLat = float.Parse(myLocation.Split(',')[1]);

                var earthRadius = 6371;
                var dLong = DegreesToRadians(MyLang - lang);
                var dLat = DegreesToRadians(MyLat - lat);

                var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(DegreesToRadians(MyLat)) * Math.Cos(DegreesToRadians(lat)) * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);

                var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                var distance = earthRadius * c;

                item.Distance = (float)distance;
            }

            context.SaveChanges();

            return hospitals;
        }
    }
}
