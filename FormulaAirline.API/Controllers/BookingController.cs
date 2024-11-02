using FormulaAirline.API.Models;
using FormulaAirline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        

        private readonly ILogger<BookingController> _logger;
        private readonly IMessageProducer _messageProducer;
        
        public static readonly List<Booking> _bookings = new List<Booking>();    
        public BookingController(ILogger<BookingController> logger, IMessageProducer messageProducer)
        {
            _logger = logger;
            this._messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult CreatinBooking (Booking newBook)
        {
            if (!ModelState.IsValid)
           return BadRequest();
 
            _bookings.Add(newBook);

            _messageProducer.SendingMessage<Booking>(newBook);
            
            return Ok();    

        }
        
        
    }
}
