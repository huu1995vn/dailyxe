using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.API.Models;
using MongoDB.Bson;
 
namespace WebCore.API.Controllers
{
   [Route("api/[controller]")]
    public class ProductAPIController : Controller
    {
        DataAccess objds=new DataAccess();
 
        public ProductAPIController()
        {
            //objds = d; 
        }
 
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            
            return objds.GetProducts();
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var product = objds.GetProduct(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }
 
       /* [HttpPost]
        public IActionResult Post([FromBody]Product p)
        {
            objds.Create(p);
            return new HttpOkObjectResult(p);
        }*/
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Product p)
        {
            var recId = new ObjectId(id);
            var product = objds.GetProduct(recId);
            if (product == null)
            {
                return null;
            }
            
            objds.Update(recId, p);
            return new OkResult();
        }
 
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var product = objds.GetProduct(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }
 
            objds.Remove(product.Id);
            return new OkResult();
        }
    }
}