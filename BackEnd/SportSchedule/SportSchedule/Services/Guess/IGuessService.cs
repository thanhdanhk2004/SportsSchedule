using SportSchedule.DataTranserferObject.Guess;

namespace SportSchedule.Services.Guess
{
    public interface IGuessService
    {
        Task<bool> addGuess(GuessDTO guess, string username, int matchId);
        Task<List<GuessDTOFE>> matchGuess(string time);
    }
}
