using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProjectYandexPracticum.Models;

namespace ProjectYandexPracticum.Interfaces
{
public interface IEventService
  {
    public Event? GetEvent(int id);
    public void CreateEvent(Event evet);
    public List<Event> GetAllEvents();
    public void DeleteEvent(int id);
    public void UpdateEvent(Event evet);
    public void ValidateEvent(Event newEvent);
  }
}