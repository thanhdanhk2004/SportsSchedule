using Microsoft.AspNetCore.Mvc;
using SportSchedule.Services.Statistic;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("/statistic")]
    public class StatisticControler : Controller
    {
        private readonly IStatisticService _statisticService;
        public StatisticControler(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        
    }
}
