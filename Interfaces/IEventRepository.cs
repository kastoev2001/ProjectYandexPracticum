using ProjectYandexPracticum.Models;

namespace ProjectYandexPracticum.Interfaces
{
  public interface IEventRepository
  {
    Event? GetById(int id);
    List<Event> GetAll();
    void Add(Event evet);
    void Update(Event evet);
    void Delete(int id);
  }
}