using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeServeyApp;
using SqaSoft;
using SqaSoft.Properties;

namespace EmployeeServeyApp
{
    [TestFixture]
    class TestClass
    {
        
        Parse p = new Parse();
        EmptyString e = new EmptyString();
        CalculateCurrentSalary C = new CalculateCurrentSalary();
        CalculateTotalSalary c = new CalculateTotalSalary();
 
        [TestCase(121,"121")]
        [TestCase(-1, "abc")]
        public void test1(int expected,string value)
        {
            Assert.AreEqual(expected, p.StringToInt(value));
        }

        [TestCase("")]
        [TestCase("Asdasd")]
        public void test2(string value)
        {
            Assert.AreEqual(true, e.isEmptyString(value));
        }

        [TestCase(2928,2000,4)]
        public void test3(int ans,int initialSalary,int workingYear)
        {
            Assert.AreEqual(ans, C.Calculate(initialSalary, workingYear));
        }


        [TestCase("1000000000000")]
        [TestCase("10000000")]
        public void test4(string s)
        {
            Assert.IsFalse(p.TooLong(s));
        }
    }
}
