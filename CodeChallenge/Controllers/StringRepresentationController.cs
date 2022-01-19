using CodeChallenge.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace CodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringRepresentationController : ControllerBase
    {
        private readonly IStringRepresentationRepository _repository;

        public StringRepresentationController(IStringRepresentationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{limit}")]
        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
        public List<string> Get(int limit)
        {
            var result = new List<string>();
            for (int i = 1; i <= limit; i++)
            {
                //Multiple of 3
                var item = IsMultipleOf(i, 3) ? "Fizz" : "";
                //Multiple of 5
                item = IsMultipleOf(i, 5) ? $"{item}Buzz" : item;
                //Multiple of 7
                item = IsMultipleOf(i, 7) ? $"{item}Jazz" : item;

                if (string.IsNullOrWhiteSpace(item))
                {
                    item = $"{i}";
                }
                result.Add(item);
            }

            //_repository.Insert(new StringRepresentation {
            //    Limit = limit,
            //    RequestDt = DateTime.UtcNow
            //});

            return result;
        }

        private bool IsMultipleOf(int number, int baseNumber)
        {
            return number % baseNumber == 0;
        }
    }
}
