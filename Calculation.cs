using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalHunt
{
    class Calculation
    {
        public List<int> GenerateDistinctNumbersRandomOrder(int From, int To)
        {
            List<int> RandomNumbers = new List<int>();

            for (int i = From; i <= To; i++)
            {
                RandomNumbers.Add(i);
            }

            var result = from r in RandomNumbers orderby Guid.NewGuid() select r;

            return result.ToList();
        }

        public List<int> GenerateDistinctNumbersRandomOrder(int From, int To, int Take, List<int> RandomNumbers)
        {
            for (int i = From; i <= To; i++)
            {
                RandomNumbers.Add(i);
            }

            var result = from r in RandomNumbers orderby Guid.NewGuid() select r;
            return result.Take(Take).ToList();
        }
    }
}
