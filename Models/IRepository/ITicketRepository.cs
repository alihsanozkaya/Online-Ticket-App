namespace Online_Ticket_App.Models.IRepository
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        void Save();
    }
}
