using RunGroupWebApp.Models;

namespace RunGroupWebApp.Data.InterfaceRepository
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();

        Task<IEnumerable<Club>> GetClubByCity(string city);

        Task<Club?> GetByIdAsync(int id);

        bool Add(Club club);

        bool Update(Club club);

        bool Delete(Club club);

        bool Save();
    }
}
