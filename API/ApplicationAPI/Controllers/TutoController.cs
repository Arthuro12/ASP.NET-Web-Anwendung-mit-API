using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutoController : ControllerBase
    {
        Tuto[] tutosArr1 = new Tuto[]
        {
            new Tuto { Title = "wpf", Price = 49, Image = "wpf.png", Description = "Blalabla....." },
            new Tuto { Title = "Unity", Price = 27, Image = "unity.png", Description = "Lalala....." },
            new Tuto { Title = "JavaScript", Price = 49, Image = "js.png", Description = "Blobloblo....." },
            new Tuto { Title = "Java", Price = 40, Image = "java.png", Description = "Lololo....." },
            new Tuto { Title = "DevOps", Price = 23, Image = "devo.png", Description = "Buuuuzzzzz....." },
            new Tuto { Title = "web development", Price = 50, Image = "web.png", Description = "Okkkkkkkkkk....." }
        };

        private readonly ILogger<TutoController> _logger;

        public TutoController(ILogger<TutoController> logger)
        {
            _logger = logger;
        }
       
        // Possible api calls

        [HttpGet]
        public IEnumerable<Tuto> Get()
        {
            // Connection to database
            string connectionString = @"server=localhost;userid=root;password=root;database=ausbildung";
            MySqlConnection connectionObject = new MySqlConnection(connectionString); 
            try
            {               
                connectionObject.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string requestString = "SELECT title, price, image, description FROM tutos";
            using var cmd = new MySqlCommand(requestString, connectionObject);
            using MySqlDataReader reader = cmd.ExecuteReader(); // Get the result of the request

            //Get the data in a loop
            int numberOfTutoToShow = 5;
            Tuto[] tutoArr2 = new Tuto[numberOfTutoToShow];
            int count = 0;

            while (reader.Read())
            {
                Tuto tutoObject = new Tuto { Title = reader[0].ToString(), Price = (int)reader[1], Image = reader[2].ToString(), Description = reader[3].ToString() };
                if(count < 5)
                {
                    tutoArr2[count] = tutoObject;
                    count++;
                }              
            }
            tutosArr1 = tutosArr1.Concat(tutoArr2).ToArray();

            //return tutosArr1;
            return tutosArr1;
        }

        [HttpGet]
        [Route("index")]
        public Tuto GetByIndex(int i = 0)
        {
            return tutosArr1[i];
        }
    }
}
