namespace Online_Ticket_App.Models.IRepository
{
    public interface ISportRepository : IRepository<Sport>
    {
        void Save();
    }
}
