using BooksCatalog.Core.Interfaces;
using BooksCatalog.Core.Publishers;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class PublishersRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublishersRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}