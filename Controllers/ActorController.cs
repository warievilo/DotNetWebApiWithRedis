using System;
using System.Linq;
using DotNetWebApiWithRedis.Context;
using DotNetWebApiWithRedis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DotNetWebApiWithRedis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly DataContext _context;

        public ActorController([FromServices]IDistributedCache cache, DataContext context)
        {
            this._cache = cache;
            this._context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            string cachedValue = _cache.GetString("Actors");
            
            if (cachedValue != null) 
                return Ok(cachedValue);
            
            var actors = _context.Actor.ToList();

            var serializedResult = JsonConvert.SerializeObject(actors);

            var options = new DistributedCacheEntryOptions();
            options.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

            _cache.SetString("Actors", serializedResult, options);

            return Ok(serializedResult);
        }

        [HttpPost]
        public ActionResult Post(Actor actor)
        {
            _context.Actor.Add(actor);            
            _context.SaveChanges();
            
            var actors = _context.Actor.ToList();
            
            var serializedResult = JsonConvert.SerializeObject(actors);

            var options = new DistributedCacheEntryOptions();
            options.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

            _cache.SetString("Actors", serializedResult, options);   

            return Ok();         
        }
    }
}