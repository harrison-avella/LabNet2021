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
            /// Encuentra la PRIMER ocurrencia que coincida con la expresión entre paréntesis, si no 
            /// se encuentra valor arroja una excepción.
            //var regionAEliminar = context.Region.First(r => r.RegionID == id);

            /// Encuentra la PRIMER ocurrencia que coincida con la expresión entre paréntesis, si no 
            /// se encuentra valor devuelve un valor default (correspondiente al tipo de dato solicitado)
            //regionAEliminar = context.Region.FirstOrDefault(r => r.RegionID == id);

            /// Encuentra la UNICA ocurrencia que coincida con la expresión entre paréntesis, si no 
            /// se encuentra valor arroja una excepción. Si se encuentra más de un valor arroja una excepción.
            //regionAEliminar = context.Region.Single(r => r.RegionID == id);

            /// Encuentra la UNICA ocurrencia que coincida con la expresión entre paréntesis, si no 
            /// se encuentra valor devuelve un valor default (correspondiente al tipo de dato solicitado). Si se encuentra más de un valor arroja una excepción.
            //regionAEliminar = context.Region.SingleOrDefault(r => r.RegionID == id);

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

        public Region GetOne(int anObject)
        {
            throw new NotImplementedException();
        }

        public int idMax()
        {
            return context.Region.Select(r => r.RegionID).Max();
        }
    }
}
