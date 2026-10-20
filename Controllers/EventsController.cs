
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

    /// <summary>
    /// Метод возвращает событие по идентификатору из коллекции
    /// </summary>
    /// <param name="id">Идентификатор события для поиска события</param>
    /// <response code="200">Возвращается JSON-структура Event с данными события.</response>
    /// <response code="404">Возвращается сообщение об отсутствии события.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Метод возвращает все события из коллекции
    /// </summary>
    /// <response code="200">Возвращается JSON-массив объектов Event.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
      return Ok(_eventService.GetAllEvents());
    }

    /// <summary>
    /// Метод обновляет существующее событие в коллекции
    /// </summary>
    /// <param name="id">Идентификатор события, которое необходимо обновить</param>
    /// <param name="updateEvent">Объект Event с обновлёнными данными события</param>
    /// <response code="204">Событие успешно обновлено.</response>
    /// <response code="400">Возвращается JSON-структура с ошибками валидации.</response>
    /// <response code="404">Возвращается сообщение об отсутствии события.</response>
    [HttpPut("{id:int}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Метод удаляет событие по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор события, которое необходимо удалить.</param>
    /// <response code="200">Запрос на удаление события обработан.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Delete(int id)
    {
      Event? existedEvent = _eventService.GetEvent(id);
      bool isExistedEvent = existedEvent != null;

      if (!isExistedEvent)
      {
        return BadRequest();
      }

      _eventService.DeleteEvent(id);

      return NoContent();
    }

    /// <summary>
    /// Метод создаёт новое событие
    /// </summary>
    /// <param name="newEvent">Объект Event с данными нового события.</param>
    /// <response code="201">Объект создан.</response>
    /// <response code="400">Возвращается JSON-структура с ошибками валидации.</response>
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Event), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] Event newEvent)
    {
      try
      {
        _eventService.CreateEvent(newEvent);

        return CreatedAtAction(nameof(GetById), new { id = newEvent.Id }, newEvent);
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
