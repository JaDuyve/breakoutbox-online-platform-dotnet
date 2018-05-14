namespace BreakOutBoxAuth.Models.Domain
{
    public interface IGroepstateRepository
    {
        void Delete(Groepstate groepstate);
        void SaveChanges();
        void SaveChangesAsync();
    }
}