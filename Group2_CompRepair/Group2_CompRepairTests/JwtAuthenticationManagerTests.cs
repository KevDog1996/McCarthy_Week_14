using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group2_CompRepair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Group2_CompRepair.Controllers.AuthenticationController;

namespace Group2_CompRepair.Tests
{
    [TestClass()]
    public class JwtAuthenticationManagerTests
    {
        [TestMethod()]
        public void AuthenticateTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("fakeKeyNotLogin111");

            User user = new User
            {
                username = "testUsername",
                password = "testpassword!!!"
            };

            var ret = manager.Authenticate(user.username, user.password);

            Assert.IsNull(ret);

        }

        [TestMethod()]
        public void AuthenticateTest_Throws()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("compRepairTestKey$$$");

            User user = new User
            {
                username = "test",
                password = "password"
            };

            var ret = manager.Authenticate(user.username, user.password);

            Assert.IsNotNull(ret);

        }
    }
}