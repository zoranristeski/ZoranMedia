using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Application.Repositories
{
    public interface IEmailRepository
    {
        public Task<Email> Add(Email email);
        public Task<bool> Update(Email email);
        public Task<bool> Delete(Email email);
        public Task<IEnumerable<Email>> GetAll();
        public Task<Email> GetByID(int id);
    }
}
