using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Card;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class CardDAL
    {
        private readonly ContextDB _context;
        private readonly MemberDAL _memberDAL;
        public CardDAL(ContextDB context, MemberDAL memberDAL)
        {
            _context = context;
            _memberDAL = memberDAL;
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
                        MemberId = _memberDAL.isExistedMember(card.MemberId ?? 0) == true? card.MemberId:null,
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
