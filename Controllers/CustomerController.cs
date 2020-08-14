using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetWebApiWithRedis.Context;
using DotNetWebApiWithRedis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;

namespace DotNetWebApiWithRedis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ContentResult Get(
            [FromServices]IDistributedCache cache)
        {
            string valorJSON = cache.GetString("Actors");
            
            if (valorJSON == null)
            {
                IQueryable<Actor> query = _context.Actor;
                
                query = query.AsNoTracking()
                         .OrderBy(a => a.Id);

                valorJSON = query.ToArray().ToString();

                DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
                opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                cache.SetString("Actors", valorJSON, opcoesCache);
            }

            return Content(valorJSON, "application/json");
        }
    }
}