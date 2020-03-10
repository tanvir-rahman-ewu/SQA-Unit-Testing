using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqaSoft
{
    public class Parse
    {
        

        public int StringToInt(string s)
        {
             int ans = 0;
             int x = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] < 48 || s[i] > 57)
                {
                    ans = -1;
                    break;
                }
       
                double y = Math.Pow(10.0, x) * (s[i] - '0');
                int temp = Convert.ToInt32(y);
                ans = ans + temp;
                x++;
            }

            return ans;
        }

        public bool TooLong(string s)
        {
            if(s.Length>9)
            {
                return true;
            }
            return false;
        }
    }
}
