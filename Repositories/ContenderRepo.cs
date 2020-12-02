using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingAdminService.Models;

namespace VotingAdminService.Repositories
{
    public class ContenderRepo : IRepository<Contender>
    {
        private static List<Contender> contenders = new List<Contender>()
        {
            new Contender(){ContenderID = 1,ContenderName = "abc"},
            new Contender(){ContenderID = 2,ContenderName = "def"},
            new Contender(){ContenderID = 3,ContenderName = "ghi"},
            new Contender(){ContenderID = 4,ContenderName = "jkl"},
            new Contender(){ContenderID = 5,ContenderName = "xyz"}
        };

        
        public bool Add(Contender entity)
        {
            entity.ContenderID = contenders.Count + 1;
            contenders.Add(entity);
            return true;
        }

        public IEnumerable<Contender> GetAll()
        {
            return contenders;
        }

        public Contender GetByID(int id)
        {
            Contender contender = contenders.FirstOrDefault(c => c.ContenderID == id);
            return contender;
        }
    }
}
