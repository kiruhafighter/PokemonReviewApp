using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByName(string name);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
        ICollection<Owner> GetOwnersFromACountryName(string name);
        bool CountryExists(int id);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country coutry);
        bool Save();
    }
}
