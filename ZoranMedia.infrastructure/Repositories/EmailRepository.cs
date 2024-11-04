using Microsoft.EntityFrameworkCore;
using ZoranMedia.Application.Repositories;
using ZoranMedia.Domain.Entities;


namespace ZoranMedia.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ZoranMediaDataContext _context;
        public EmailRepository(ZoranMediaDataContext context)
        {
           _context = context;
        }
        public async Task<Email> Add(Email email)
        {
            await _context.AddAsync(email);
            await _context.SaveChangesAsync();
            return email;
        }

        public async Task<bool> Delete(Email email)
        {
            try
            {
                _context.Emails.Remove(email);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<IEnumerable<Email>> GetAll()
        {
            return await _context.Emails.ToListAsync();
        }

        public async Task<Email> GetByID(int id)
        {
            return await _context.Emails.Where(e => e.EmailID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Email email)
        {
            try
            {
                _context.Update(email);
                await _context.SaveChangesAsync(); 
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
