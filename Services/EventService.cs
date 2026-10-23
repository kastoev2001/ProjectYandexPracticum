using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProjectYandexPracticum.Interfaces;
using ProjectYandexPracticum.Models;
using System.Data.Common;

namespace ProjectYandexPracticum.Services
{
  public class EventService : IEventService
  {
    private IEventRepository _eventRepository;
    public EventService(IEventRepository eventRepository)
    {
      _eventRepository = eventRepository;
    }

    public Event? GetEvent(int id)
    {
      return _eventRepository.GetById(id);
    }

    public List<Event> GetAllEvents()
    {
      return _eventRepository.GetAll();
    }

    public void DeleteEvent(int id)
    {
      _eventRepository.Delete(id);
    }

    public void UpdateEvent(int id)
    {
      Event exitedEvent = GetEvent(id);

      ValidateEvent(exitedEvent);
      _eventRepository.Update(exitedEvent);
    }

    public void CreateEvent(Event newEvent)
    {
      ValidateEvent(newEvent);

      _eventRepository.Add(newEvent);
    }

    public void ValidateEvent(Event evet)
    {
      if (evet.EndAt <= evet.StartAt)
      {
        throw new ArgumentException(
          "Дата окончания должна быть позже даты начала."
        );
      }
    }
  }
}
