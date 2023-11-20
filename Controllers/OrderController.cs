using Microsoft.AspNetCore.Mvc;
using Order_Customers_Assignment.Models;
using Order_Customers_Assignment.Utils;

namespace Order_Customers_Assignment.Controllers
{
    public class OrderController : Controller
    {
        private RandomManager _randomManager { get; set; }
        public OrderController(RandomManager randomManager) 
        {
            _randomManager = randomManager;
        }

        [Route("order")]
        public IActionResult Order([FromForm] Order order)
        {
            if (ModelState.IsValid == false)
            {
                List<string> errors = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                return BadRequest(string.Join("\n", errors));
            }

            return Json(_randomManager.Exec());
        }
    }
}
