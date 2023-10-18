using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLaptopApi.Data;
using MyLaptopApi.Model;

namespace MyLaptopApi.Controllers
{
    
    
    
    [Route("/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly LaptopDetailsDBContext context;

        public LaptopController(LaptopDetailsDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Route("GetAllRecords")]
        public IActionResult GetAllRecords() 
        {
            var data = context.LaptopDetails.ToList();
            if(data.Count()==0)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
         [HttpGet]
        [Route("GetAllRecordsfromID/{ID}")]
        public IActionResult GetAllRecordsfromID(int ID) 
        {
            if(ID==0)

            {
                return NotFound();

            }
            else
            {
               var result =  context.LaptopDetails.Where(e =>e.Id==ID).SingleOrDefault();
                if(result==null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(result);
                }
                
            }
        }
        [HttpPost]
        [Route("InsertAllRescors")]
        public IActionResult InsertAllRescors([FromBody] LaptopDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new LaptopDetails()
                {
                    
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price
                };
                context.LaptopDetails.Add(result);
                context.SaveChanges();
                return Ok(result);
            }
         }
        [HttpDelete]
        [Route("DeletebyID")]
        public IActionResult DeletebyID([FromRoute] int id)
        {
            if(id==0) 
            {
                return NotFound();
            }
            else
            {
                var del = context.LaptopDetails.Where(e => e.Id == id).SingleOrDefault();
                context.LaptopDetails.Remove(del);
                context.SaveChanges();
                return Ok(del);

            }
            
        }
        [HttpPut]
        [Route("RecordofLaptopupdate")]
        public IActionResult RecordofLaptopupdate([FromBody] LaptopDetails model)
        {

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            else
            {
                
                var lap = context.LaptopDetails.Where(e=>e.Id==model.Id).SingleOrDefault();
                if(lap==null)
                {
                    return BadRequest();
                }
                else 
                {
                    lap.Name = model.Name;
                    lap.Description = model.Description;
                    lap.Price = model.Price;

                }

                
                context.Update(lap);
                context.SaveChanges();
                return Ok(lap);
            }
        }
        [HttpPut]
        [Route("Updatebyid")]
        public IActionResult Updatebyid([FromBody] LaptopDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var lap = context.LaptopDetails.Where(e => e.Id == model.Id).SingleOrDefault();
                if (lap == null)
                {
                    return BadRequest();
                }
                else
                {
                    lap.Name = model.Name;
                    lap.Description = model.Description;
                    lap.Price = model.Price;


                }
                context.Update(lap);
                context.SaveChanges();
                return Ok(lap);
            }
        }
    }

    
}
