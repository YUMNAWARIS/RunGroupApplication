using RunGroupWebApp.Models;

namespace RunGroupWebApp.Data.InterfaceRepository
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> getAll();
        Task<Race?> getByIDAsync(int id);
        Task<IEnumerable<Race>> GetRaceByCity(string city);
        bool add(Race race);
        bool update(Race race);
        bool delete(int id);
        bool Save();
    }
}
