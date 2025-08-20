using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Guess;
using Microsoft.Extensions.Caching.Memory;

namespace SportSchedule.Services.Guess
{
    public class GuessService : IGuessService
    {
        private readonly GuessDAL _guessDAL;
        private readonly IMemoryCache _cache;
        public GuessService(GuessDAL guessDAL, IMemoryCache cache)
        {
            _guessDAL = guessDAL;
            _cache = cache;
        }

        public async Task<bool> addGuess(GuessDTO guess, string username, int matchId)
        {
            return _guessDAL.addGuess(guess, username, matchId);
        }

        public async Task<List<GuessDTOFE>> matchGuess(string time)
        {
            string cache_key = $"list_guess_{time}";
            if(_cache.TryGetValue(cache_key, out List<GuessDTOFE> listGuess))
                return listGuess;

            var data = _guessDAL.getMatchsGuess();
            _cache.Set(cache_key, data, TimeSpan.FromMinutes(30));
            return data;
        }

    }
}
