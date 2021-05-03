using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    interface IABMLogic<T, in ID>
    {
        List<T> GetAll();
        T GetOne(ID anObject);
        void Add(T newObject);
        void Delete(ID property);
        void Update(T updateObject);
    }
}
