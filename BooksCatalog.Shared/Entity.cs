namespace BooksCatalog.Shared
{
    public abstract class Entity
    {
        public int Id { get; set; }

        private bool Equals(Entity other) => Id == other.Id;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Entity) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}