namespace breakoutbox.Models.Domain
{
    public interface IGroepRepository
    {
        Groep GetById(decimal ID);
    }
}