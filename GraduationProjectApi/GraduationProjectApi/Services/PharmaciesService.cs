﻿using AutoMapper;
using GraduationProjectApi.Data;
using GraduationProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectApi.Services
{
    public class PharmaciesService : IPharmaciesService
    {
        private readonly AppDbContext context;

        public PharmaciesService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Pharmacy>> GetAll()
        {
            return await context.Pharmacies.ToListAsync();
        }
        public async Task<Pharmacy> GetById(int id)
        {
            return await context.Pharmacies.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Pharmacy> Add(Pharmacy pharmacy)
        {
            await context.AddAsync(pharmacy);
            context.SaveChangesAsync();
            return pharmacy;
        }
        public Pharmacy Update(Pharmacy pharmacy)
        {
            context.Update(pharmacy);
            context.SaveChanges();
            return pharmacy;
        }
        public Pharmacy Delete(Pharmacy pharmacy)
        {
            context.Remove(pharmacy);
            context.SaveChanges();
            return pharmacy;
        }
        public double DegreesToRadians(float deg)
        {
            return deg * Math.PI / 180;
        }
        public async Task<IEnumerable<Pharmacy>> GetDistance(string myLocation)
        {
            var Pharmacies = await context.Pharmacies.ToListAsync();

            foreach (var item in Pharmacies)
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

            return Pharmacies.OrderBy(x => x.Distance);
        }
    }
}
