using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group2_CompRepair.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group2_CompRepair.Data;
using Group2_CompRepair.Models;
using Microsoft.AspNetCore.Authorization;

namespace Group2_CompRepair.Controllers.Tests
{
    [TestClass()]
    public class ComputerPartsControllerTests
    {
        [TestMethod()]
        public void GetComputerPart_WithUnexistingItem_ReturnsNotFound()
        {
            //arrange
            
            

            //act

            //assert
        }
    }
}