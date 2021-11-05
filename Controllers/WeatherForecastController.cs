using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Sample_Web_APP_MongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private IMongoCollection<Shipwreck> _shipwreckCollection;

        public WeatherForecastController(IMongoClient client) //Dependency Injection in constructor
        {
            var database = client.GetDatabase("sample_geospatial");
            _shipwreckCollection = database.GetCollection<Shipwreck>("shipwrecks");
        }

        [HttpGet]
        public IEnumerable<Shipwreck> Get()
        {                            
            return _shipwreckCollection.Find(s => s.FeatureType == "Wrecks - Visible").ToList();

        }
    }
}
