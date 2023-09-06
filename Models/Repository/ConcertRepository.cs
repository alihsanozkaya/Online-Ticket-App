using Online_Ticket_App.Models.IRepository;
using Online_Ticket_App.Utility;

namespace Online_Ticket_App.Models.Repository
{
    public class ConcertRepository : Repository<Concert>, IConcertRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public ConcertRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
