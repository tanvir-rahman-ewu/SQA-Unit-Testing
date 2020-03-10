using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqaSoft
{
    public class CalculateTotalSalary
    {
        public int calculate(List<Employee> li)
        {
            int total = 0;
            CalculateCurrentSalary C = new CalculateCurrentSalary();

            foreach (Employee var in li)
            {
                int initialSalary = var.InitialSalary.Value;
                int workingMonth = var.WorkingMonth.Value;

                int workingYear = workingMonth / 12;

                total = total + C.Calculate(initialSalary, workingYear);
            }
            return total;
            
        }
    }
}
