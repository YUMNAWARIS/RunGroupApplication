using RunGroupWebApp.Data;
using RunGroupWebApp.Data.InterfaceRepository;
using RunGroupWebApp.Models;
using Microsoft.EntityFrameworkCore;


namespace RunGroupWebApp.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDBContext _context;

        public RaceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool add(Race race)
        {
            _context.Add(race);
            return Save();
        }

        public bool delete(int id)
        {
            _context.Remove(id);
            return Save();
        }

        public async Task<IEnumerable<Race>> getAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race?> getByIDAsync(int id)
        {
            return await _context.Races.Include(s => s.Address).FirstOrDefaultAsync(s => s.Id==id);
        }

        public async Task<IEnumerable<Race>> GetRaceByCity(string city)
        {
            return await _context.Races.Where(r => r.Address.City.Contains(city)).Distinct().ToListAsync();
        }

        public bool Save()
        {
            int save = _context.SaveChanges();
            return save > 0;
        }

        public bool update(Race race)
        {
            _context.Update(race);
            return Save();
        }
    }
}
