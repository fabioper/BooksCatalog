using BooksCatalog.Core;
using BooksCatalog.Core.Interfaces;
using BooksCatalog.Core.Interfaces.Repositories;
using BooksCatalog.Core.Publisher;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class PublishersRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublishersRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}