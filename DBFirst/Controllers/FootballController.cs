using DBFirst.MyDbContext;
using DBFirst.MyDbContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DBFirst.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FootballController : ControllerBase
    {
       
        private readonly ILogger<FootballController> _logger;
        private readonly DataBaseFirstContext _dataBaseFirstContext;
        public FootballController(ILogger<FootballController> logger, DataBaseFirstContext dataBaseFirstContext)
        {
            _logger = logger;
            _dataBaseFirstContext = dataBaseFirstContext;
        }

        [HttpGet("path")]
        public IEnumerable <Player> GetPlayer()
        {
            return _dataBaseFirstContext.Players.ToList();
        }

        [HttpGet("path")]
        public IEnumerable<Team> GetTeam()
        {
            return _dataBaseFirstContext.Teams.ToList();
        }
    }
}