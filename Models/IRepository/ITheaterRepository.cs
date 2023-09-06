namespace Online_Ticket_App.Models.IRepository
{
    public interface ITheaterRepository : IRepository<Theater>
    {
        void Save();
    }
}
