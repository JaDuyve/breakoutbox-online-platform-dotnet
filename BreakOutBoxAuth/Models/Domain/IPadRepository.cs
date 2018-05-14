namespace BreakOutBoxAuth.Models.Domain
{
    public interface IPadRepository
    {
        Pad GetById(int padId);
        void SaveChanges();
    }
}