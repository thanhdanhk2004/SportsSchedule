using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Card;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class CardDAL
    {
        private readonly ContextDB _context;
        public CardDAL(ContextDB context)
        {
            _context = context;
        }

        public void addCard(CardDTO card)
        {
            try
            {
                if(card != null)
                {
                    CardModel model = new CardModel
                    {
                        TypeCard = card.TypeCard,
                        Time = card.Time,
                        Status = card.Status,
                        MatchId = card.MatchId,
                        MemberId = card.MemberId,
                    };
                    _context.Cards.Add(model);
                    _context.SaveChanges();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
