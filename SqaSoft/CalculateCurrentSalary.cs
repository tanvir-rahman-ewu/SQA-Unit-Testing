using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqaSoft
{
    public class CalculateCurrentSalary
    {
        public int Calculate(int initialSalary,int workingYear)
        {
            double currentSalary = initialSalary;

            for (int i = 0; i < workingYear; i++)
            {
                currentSalary = currentSalary + currentSalary * 0.10;
            }
            int sal = Convert.ToInt32(currentSalary);

            return sal;
        }
    }
}
