namespace Online_Ticket_App.Models.IRepository
{
    public interface IConcertRepository : IRepository<Concert>
    {
        void Save();
    }
}
