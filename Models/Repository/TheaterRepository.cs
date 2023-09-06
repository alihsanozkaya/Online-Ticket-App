using Online_Ticket_App.Models.IRepository;
using Online_Ticket_App.Utility;

namespace Online_Ticket_App.Models.Repository
{
    public class TheaterRepository : Repository<Theater>, ITheaterRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public TheaterRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
