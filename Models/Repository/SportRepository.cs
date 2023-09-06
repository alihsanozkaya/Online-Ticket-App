using Online_Ticket_App.Models.IRepository;
using Online_Ticket_App.Utility;

namespace Online_Ticket_App.Models.Repository
{
    public class SportRepository : Repository<Sport>, ISportRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public SportRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
