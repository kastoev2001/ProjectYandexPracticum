
using Microsoft.AspNetCore.Mvc;
using ProjectYandexPracticum.Interfaces;
using ProjectYandexPracticum.Models;

namespace ProjectYandexPracticum.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Produces("application/json")]
  public class EventsController : ControllerBase
  {
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
      _eventService = eventService;
    }

    public ActionResult<Event> GetById(int id)
    {
      Event existedEvent = _eventService.GetEvent(id);
      bool isExistedEvent = existedEvent != null;

      if (!isExistedEvent)
      {
        return NotFound($"Событие с ID {id} не найдено.");
      }

      return Ok(existedEvent);
    }

    public IActionResult GetAll()
    {
      return Ok(_eventService.GetAllEvents());
    }

    public IActionResult Update(int id, [FromBody] Event updateEvent)
    {
      Event existedEvent = _eventService.GetEvent(id);
      bool isExistedEvent = existedEvent != null;

      if (!isExistedEvent)
      {
        return NotFound($"Событие с ID {id} не найдено.");
      }

      try
      {
        _eventService.UpdateEvent(updateEvent);

        return NoContent();
      } catch(ArgumentException ex)
      {
        ModelState.AddModelError(
          nameof(Event.EndAt),
          ex.Message
        );

        return BadRequest(ModelState);
      }
    }

    public IActionResult Delete(int id)
    {
      _eventService.DeleteEvent(id);

      return Ok();
    }

    public IActionResult Create([FromBody] Event newEvent)
    {
      try
      {
        _eventService.CreateEvent(newEvent);

        return Ok();
      }
      catch (ArgumentException ex)
      {
        ModelState.AddModelError(
          nameof(Event.EndAt),
          ex.Message
        );

        return BadRequest(ModelState);
      }
    }
  }
}
