using AutoMapper;
using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services
{
    public class HospitalsService : IHospitalsService
    {
        private readonly AppDbContext context;

        public HospitalsService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Hospital>> GetAll()
        {
            return await context.Hospitals.Include(k => k.Kind).ToListAsync();
        }
        public async Task<Hospital> GetById(int id)
        {
            return await context.Hospitals.Include(k => k.Kind).SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Hospital> Add(Hospital hospital)
        {
            await context.AddAsync(hospital);
            context.SaveChangesAsync();
            return hospital;
        }
        public Hospital Update(Hospital hospital)
        {
            context.Update(hospital);
            context.SaveChanges();
            return hospital;
        }
        public Hospital Delete(Hospital hospital)
        {
            context.Remove(hospital);
            context.SaveChanges();
            return hospital;
        }
        public double DegreesToRadians(float deg)
        {
            return deg * Math.PI / 180;
        }
        public async Task<IEnumerable<Hospital>> GetDistance(string myLocation)
        {
            var hospitals = await context.Hospitals.Include(x => x.Kind).ToListAsync();

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

            return hospitals.OrderBy(x => x.Distance);
        }

        //public double DistanceBetween(string MyLocation)
        //{
        //    var hospital = new Hospital();

        //    var lang = float.Parse( hospital.Location.Split(',')[0]);
        //    var lat = float.Parse( hospital.Location.Split(',')[1]);

        //    var MyLang = float.Parse(MyLocation.Split(',')[0]);
        //    var MyLat = float.Parse(MyLocation.Split(',')[1]);


        //    var earthRadius = 6371;
        //    var dLong = DegreesToRadians(MyLang - lang);
        //    var dLat = DegreesToRadians(MyLat - lat);

        //    var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(DegreesToRadians(MyLat)) * Math.Cos(DegreesToRadians(lat)) * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);

        //    var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        //    var distance = earthRadius * c;

        //    return distance;
        //}
    }
}
