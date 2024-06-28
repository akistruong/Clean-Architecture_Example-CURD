using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MySQL.DataSeed
{
    public  class Iventories
    {
        public static List<Iventory> IventoriesInit()
        {
            var Iventories = new List<Iventory>()
                    {
                        new Iventory()
                        {
                            ProductID="c09628ea-441e-4486-a019-e4005e1b1644",
                            ID= Guid.NewGuid().ToString(),
                            Qty=100,
                        },
                         new Iventory()
                        {
                             ProductID="511e3a9e-1cbd-4355-92f4-ff25d838979b",
                            ID= Guid.NewGuid().ToString(),
                            Qty=50,
                        },
                         new Iventory()
                        {
                             ProductID="151987ae-da8c-43a3-9923-faccf5b32b95",
                            ID= Guid.NewGuid().ToString(),
                            Qty=50,
                        }
                    };
            return Iventories;
        }
    }
}
