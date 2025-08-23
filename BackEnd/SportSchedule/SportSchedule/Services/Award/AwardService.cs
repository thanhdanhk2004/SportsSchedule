using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Award;

namespace SportSchedule.Services.Award
{
    public class AwardService : IAwardService
    {
        private readonly AwardDAL _awardDAL;
        public AwardService(AwardDAL awardDAL)
        {
            _awardDAL = awardDAL;
        }
        public async Task<bool> addAward(int guessId)
        {
            try
            {
                if(guessId == null)
                    return false;
                return _awardDAL.addAward(guessId);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<AwardDTOFEAdmin>> getGuessExactly(int matchId)
        {
            try
            {
                if (matchId == null)
                    return null!;
                return _awardDAL.getGuessExactly(matchId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        public async Task<bool> updateStatusAward(int awardId)
        {
            try
            {
                if (awardId == null)
                    return false;
                return _awardDAL.updateAward(awardId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
