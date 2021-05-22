namespace BooksCatalog.Shared
{
    public class Guard : IGuardClause
    {
        public static readonly IGuardClause Against = new Guard();

        private Guard()
        {
        }
    }
}