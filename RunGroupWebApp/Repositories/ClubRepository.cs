using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Data.InterfaceRepository;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDBContext _context;
        public ClubRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club?> GetByIdAsync(int id)
        {
            return await _context.Clubs.Include(s => s.Address).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(c => c.Address.City.Contains(city)).Distinct().ToListAsync();
        }

        public bool Save()
        {
            int save = _context.SaveChanges();
            return save > 0;
        }

        public bool Update(Club club)
        {
           _context.Update(club);
            return Save();
        }

    }
}
