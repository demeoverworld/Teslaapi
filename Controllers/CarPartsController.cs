using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TST_API.Models;
using System.Linq;

namespace TST_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarPartsController : ControllerBase
    {
        private static readonly List<CarParts> Parts = new List<CarParts>
        {
                 new CarParts { Id = 1, Name = "Engine", Model="Model X",url="https://www.gearpatrol.com/wp-content/uploads/sites/2/2017/08/A-Better-911-Engine-Singer-gear-patrol-1-jpg.webp?crop=16.5,0,67,100&quality=100",year=2021,  Stock = 10, Cost = 5000 },
                 new CarParts { Id = 2, Name = "Tire",  Model="Model 3",url="https://autobani.com/wp-content/uploads/2023/01/023577.webp",year=2021, Stock = 50, Cost = 200 },
                 new CarParts { Id = 3, Name = "Brake Pad",  Model="Model X",url="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcEYNTkuNhD-g1f35iPIS-LSgp6Ko1YxaPsA&s",year=2020, Stock = 30, Cost = 100 },
                 new CarParts { Id = 3, Name = "Brake Pad",  Model="Model X",url="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcEYNTkuNhD-g1f35iPIS-LSgp6Ko1YxaPsA&s",year=2024, Stock = 30, Cost = 100 },
                 new CarParts { Id = 4, Name = "Brake Pad",  Model="Model X",url="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcEYNTkuNhD-g1f35iPIS-LSgp6Ko1YxaPsA&s",year=2021, Stock = 30, Cost = 100 },
                 new CarParts { Id = 5, Name = "Brake Pad",  Model="Model X",url="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcEYNTkuNhD-g1f35iPIS-LSgp6Ko1YxaPsA&s",year=2020, Stock = 30, Cost = 100 },
                 new CarParts { Id = 6, Name = "Brake Pad",  Model="Model X",url="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcEYNTkuNhD-g1f35iPIS-LSgp6Ko1YxaPsA&s",year=2025, Stock = 30, Cost = 100 },
                 new CarParts { Id = 7, Name = "Brake Pad",  Model="Model X",url="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcEYNTkuNhD-g1f35iPIS-LSgp6Ko1YxaPsA&s",year=2014, Stock = 30, Cost = 100 },

        };

   
        [HttpGet]
        public IActionResult GetAllParts()
        {
            return Ok(Parts);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetPartById(int id)
        {
            var part = Parts.FirstOrDefault(p => p.Id == id);
            if (part == null) return NotFound();
            return Ok(part);
        }

     
        [HttpPost]
        public IActionResult CreatePart([FromBody] CarParts newPart)
        {
            newPart.Id = Parts.Max(p => p.Id) + 1;
            Parts.Add(newPart);
            return CreatedAtAction(nameof(GetPartById), new { id = newPart.Id }, newPart);
        }

  
        [HttpPut("{id:int}/UpdateStock")]
        public IActionResult UpdateStock(int id, [FromBody] int newStock)
        {
            var part = Parts.FirstOrDefault(p => p.Id == id);
            if (part == null) return NotFound();
            part.Stock = newStock;
            return Ok(part);
        }

      
        [HttpDelete("{id:int}")]
        public IActionResult DeletePart(int id)
        {
            var part = Parts.FirstOrDefault(p => p.Id == id);
            if (part == null) return NotFound();
            Parts.Remove(part);
            return NoContent();
        }
    }

 
}
