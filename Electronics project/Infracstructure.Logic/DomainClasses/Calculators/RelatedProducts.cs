using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.InterfaceServicesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.DomainClasses.Calculators
{
    public static class RelatedProducts
    {
        public static List<Electronic> Calc(Electronic product, List<Electronic> pastOrders, List<Electronic> allProducts)
        {
            List<Electronic> relatedHolds = allProducts;
            List<Electronic> relatedProducts = new List<Electronic>();

            foreach (Electronic electronic in pastOrders)
            {
                foreach (Electronic elec in relatedHolds)
                {
                    if (electronic.SerialNumber == elec.SerialNumber)
                    {
                        relatedHolds.Remove(elec);
                        break;
                    }
                }
            }

            foreach (Electronic elec in allProducts)
            {
                if (product.GetType() == elec.GetType() && pastOrders.Count == 0)
                {
                    relatedProducts.Add(elec);
                }
            }

            if (relatedProducts.Count == 0)
            {
                relatedProducts = allProducts;
            }

            List<Electronic> Relateds = Randomized(relatedProducts);

            return Relateds;
        }

        private static List<Electronic> Randomized(List<Electronic> Relateds)
        {
            if (Relateds.Count <= 4)
            {
                return Relateds;
            }

            List<Electronic> Randomized = new List<Electronic>();
            HashSet<Electronic> selectedSet = new HashSet<Electronic>();

            while (Randomized.Count < 4)
            {
                int index = _Random.Next(Relateds.Count);
                Electronic elec = Relateds[index];

                if (selectedSet.Add(elec))
                {
                    Randomized.Add(elec);
                }
            }

            if (Randomized.Count >= 4)
            {
                return Randomized.GetRange(0, 4);
            }

            return Randomized;
        }
        private static Random _Random = new Random();

        private static Electronic GetRandomizedElectronic(int n, List<Electronic> randomized, List<Electronic> Relateds)
        {
            int k = _Random.Next(n);
            Electronic elec = Relateds[k];
            if (!randomized.Contains(elec))
            {
                return elec;
            }
            else
            {
                return GetRandomizedElectronic(n, randomized, Relateds);
            }
        }
    }
}
