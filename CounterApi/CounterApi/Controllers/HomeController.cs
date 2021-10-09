using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounterApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        static int ctr = 0;
        static Dictionary<int, int> clientCounter = new Dictionary<int, int>();

        [Route("request")]
        [HttpGet]
        public async Task<ActionResult<int>> Get()
        {
            return Ok(ctr++);
        }
        [Route("request/{id:int}")]
        [HttpGet]
        public async Task<ActionResult> GetClientCounter(int id)
        {
            int clientCtr = 0;

            if (clientCounter.ContainsKey(id))
            {
                    clientCtr = clientCounter[id] + 1;
                    await Task.Delay(2000);
                    if((clientCounter[id] + 1) != clientCtr)
                    {
                      clientCtr = clientCounter[id] + 1;
                    }
                    clientCounter[id] = clientCtr;
            }
            else
            {
                    clientCounter.Add(id, clientCtr);
            }
            return Ok(clientCtr);
        }
    }
}
