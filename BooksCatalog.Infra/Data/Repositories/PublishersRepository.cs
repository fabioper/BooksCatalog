using BooksCatalog.Domain;
using BooksCatalog.Domain.Interfaces;
using BooksCatalog.Domain.Interfaces.Repositories;
using BooksCatalog.Domain.Publisher;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class PublishersRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublishersRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}