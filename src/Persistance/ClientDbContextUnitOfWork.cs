using Domain.Repositories;
using System.Threading.Tasks;

namespace Persistance
{
    public class ClientDbContextUnitOfWork : IUnitOfWork
    {
        private readonly ClientDbContext context;

        public ClientDbContextUnitOfWork(ClientDbContext context)
        {
            this.context = context;
        }

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}