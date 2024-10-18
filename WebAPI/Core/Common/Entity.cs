namespace Core.Common
{
    public class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
