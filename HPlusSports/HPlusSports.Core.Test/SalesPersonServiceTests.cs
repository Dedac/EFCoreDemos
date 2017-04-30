using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HPlusSports.DAL;
using Microsoft.EntityFrameworkCore;
using HPlusSports.Models;
using System.Threading.Tasks;

namespace HPlusSports.Core.Test
{
    [TestClass]
    public class SalesPersonServiceTests
    {
        [TestMethod]
        public async Task MoveSalesPersonWithoutGroupToExistingGroup()
        {
            using (var context = GetContext("MovePersonTest"))
            {
                context.Add(new SalesGroup() { State = "TEST", Type = 1, Id = 1 });
                context.Add(new Salesperson() { Id = 1 });
                await context.SaveChangesAsync();

                var repo = new SalesPersonRepository(context);
                var groupRepo = new TrackingRepository<SalesGroup>(context);
                var service = new SalesPersonService(repo, groupRepo);

                await service.MoveSalesPersonToGroup(1, 1);
            }

            using (var context = GetContext("MovePersonTest"))
            {
                var person = context.Find<Salesperson>(1);
                Assert.IsTrue(person.SalesGroupState == "TEST");
            }

        }

        private static HPlusSportsContext GetContext(string name)
        {
            var dbOptions = new DbContextOptionsBuilder<HPlusSportsContext>()
                .UseInMemoryDatabase(name).Options;
            return new HPlusSportsContext(dbOptions);
        }
    }
}
