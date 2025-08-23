using SportSchedule.DataTranserferObject.Award;

namespace SportSchedule.Services.Award
{
    public interface IAwardService
    {
        Task<List<AwardDTOFEAdmin>> getGuessExactly(int matchId);
        Task<bool> addAward(int guessId);
        Task<bool> updateStatusAward(int awardId);
    }
}
