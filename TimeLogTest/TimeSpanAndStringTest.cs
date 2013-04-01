using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLog;

namespace TimeLogTest
{
    [TestClass]
    public class TimeSpanAndStringTest
    {
        [TestMethod]
        public void Timespan2String()
        {
            //Setup
            TimeSpan timespan = new TimeSpan(0, 1, 1, 1);

            //Execute
            string result = TimeHelper.Timespan2String(timespan);

            //Test
            Assert.AreEqual<string>("01:01:01", result);
        }

        [TestMethod]
        public void String2Timespan()
        {
            //Setup
            string time = "01:01:01";

            //Execute
            TimeSpan result = TimeHelper.String2Timespan(time);

            //Test
            Assert.AreEqual<TimeSpan>(new TimeSpan(1, 1, 1), result);
        }
    }
}
