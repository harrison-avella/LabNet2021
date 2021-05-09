using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class RegionLogic : BaseLogic, IABMLogic<Region, int>
    {
        public List<Region> GetAll()
        {
            return context.Region.ToList();
        }

        public void Add(Region newRegion)
        {
            context.Region.Add(newRegion);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var regionAEliminar = context.Region.Find(id);

            context.Region.Remove(regionAEliminar);

            context.SaveChanges();
        }

        public void Update(Region region)
        {
            var regionUpdate = context.Region.Find(region.RegionID);

            regionUpdate.RegionDescription = region.RegionDescription;

            context.SaveChanges();
        }

        public Region GetOne(int id)
        {
            return context.Region.First(p => p.RegionID.Equals(id));
        }

        public int IdMax()
        {
            return context.Region.Select(r => r.RegionID).Max();
        }
    }
}
