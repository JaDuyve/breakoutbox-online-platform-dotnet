namespace BreakOutBoxAuth.Models.Domain
{
    public interface IGroepRepository
    {
        Groep GetById(decimal ID);
        void SaveChanges();
    }
}