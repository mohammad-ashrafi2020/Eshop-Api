namespace Common.Domain
{
    public class BaseEntity
    {
        public long Id { get; protected set; }
        public DateTime CreationDate { get; }

        public BaseEntity()
        {
            CreationDate = new DateTime();
        }
    }
}