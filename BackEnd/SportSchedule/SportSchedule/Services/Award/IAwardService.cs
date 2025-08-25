using SportSchedule.DataTranserferObject.Award;

namespace SportSchedule.Services.Award
{
    public interface IAwardService
    {
        Task<List<AwardDTOFEAdmin>> getGuessExactly(int matchId);
        Task<List<AwardStatusDTOFEAdmin>> getListAward();
        Task<bool> addAward(int guessId);
        Task<bool> updateStatusAward(int guessId);
        Task sendMail(int guessId);
    }
}
