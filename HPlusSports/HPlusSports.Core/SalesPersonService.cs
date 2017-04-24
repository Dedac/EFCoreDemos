using HPlusSports.DAL;
using HPlusSports.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HPlusSports.Core
{
    public class SalesPersonService : ISalesPersonService
    {
        ISalesPersonRepository _salesRepo;
        ITrackingRepository<SalesGroup> _salesGroupRepo;

        public SalesPersonService(ISalesPersonRepository salesPersonRepository, ITrackingRepository<SalesGroup> salesGroupRepo)
        {
            _salesRepo = salesPersonRepository;
            _salesGroupRepo = salesGroupRepo;
        }

        public async Task MoveSalesPersonToGroup(int salesPersonId, int groupId)
        {
            var person = await _salesRepo.GetByID(salesPersonId);
            var group = await _salesGroupRepo.GetByID(groupId);
            person.SalesGroup = group;
            _salesRepo.Save(person);
        }

        public async Task AddGroupAndPerson(Salesperson person, SalesGroup group)
        {
            using (var transaction = await _salesRepo.StartTransaction())
            {
                _salesRepo.Add(person);
                group.Salespeople.Add(person);
                _salesGroupRepo.Add(group);
                transaction.Commit();
            }
        }

    }
}
