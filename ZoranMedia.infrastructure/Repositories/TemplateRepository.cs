using Microsoft.EntityFrameworkCore;
using ZoranMedia.Application.Repositories;
using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Infrastructure.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly ZoranMediaDataContext _context;
        public TemplateRepository(ZoranMediaDataContext context)
        {
            _context = context;
        }
        public async Task<Template> Add(Template template)
        {
            await _context.AddAsync(template);
            await _context.SaveChangesAsync();
            return template;
        }

        public async Task<bool> Delete(Template template)
        {
            try
            {
                _context.Templates.Remove(template);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<IEnumerable<Template>> GetAll()
        {
            return await _context.Templates.ToListAsync();
        }

        public async Task<Template> GetByID(int id)
        {
            return await _context.Templates.Where(e => e.TemplateID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Template template)
        {
            try
            {
                _context.Update(template);
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
