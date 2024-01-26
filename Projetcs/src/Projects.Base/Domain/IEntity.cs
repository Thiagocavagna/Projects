namespace Upside.Base.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
        Guid GetId();
    }
}
