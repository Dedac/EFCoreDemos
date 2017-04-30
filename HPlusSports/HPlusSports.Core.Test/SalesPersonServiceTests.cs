using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HPlusSports.DAL;
using Microsoft.EntityFrameworkCore;
using HPlusSports.Models;
using System.Threading.Tasks;
using Moq;
using HPlusSports.Core.Test.Mocks;

namespace HPlusSports.Core.Test
{
    [TestClass]
    public class SalesPersonServiceTests
    {
        [TestMethod]
        public async Task MoveSalesPersonWithoutGroupToExistingGroup()
        {
            var salesRepo = new SalesPersonRepositoryMock();
            var salesGroupRepo = new SalesGroupRepositoryMock();

                salesGroupRepo.Add(new SalesGroup() { State = "TEST", Type = 1, Id = 1 });
                salesRepo.Add(new Salesperson() { Id = 1 });

                var service = new SalesPersonService(salesRepo, salesGroupRepo);

                await service.MoveSalesPersonToGroup(1, 1);

                var person = await salesRepo.GetByID(1);
             
                Assert.IsTrue(person.SalesGroup.State == "TEST");
        }

    }
}
