using ProjectYandexPracticum.Interfaces;
using ProjectYandexPracticum.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectYandexPracticum.Date
{

  public class EventRepository : IEventRepository
  {
    private readonly List<Event> _events = new List<Event>();

    public EventRepository()
    {
      _events.Add(new Event
      {
        Id = 1,
        Title = "Поход к врачу",
        Description = "Плановый осмотр у терапевта.",
        StartAt = new DateTime(2026, 11, 10, 10, 0, 0),
        EndAt = new DateTime(2026, 11, 10, 11, 0, 0)
      });

      _events.Add(new Event
      {
        Id = 2,
        Title = "Встреча с друзьями",
        Description = "Посидеть в кафе и пообщаться.",
        StartAt = new DateTime(2026, 11, 12, 18, 0, 0),
        EndAt = new DateTime(2026, 11, 12, 21, 0, 0)
      });

      _events.Add(new Event
      {
        Id = 3,
        Title = "Тренировка",
        Description = "Сходить в спортзал.",
        StartAt = new DateTime(2026, 11, 15, 17, 0, 0),
        EndAt = new DateTime(2026, 11, 15, 19, 0, 0)
      });

      _events.Add(new Event
      {
        Id = 4,
        Title = "День рождения",
        Description = "Отметить день рождения друга.",
        StartAt = new DateTime(2026, 11, 20, 16, 0, 0),
        EndAt = new DateTime(2026, 11, 20, 22, 0, 0)
      });
    }
    public Event? GetById(int id)
    {
      return _events.FirstOrDefault(e => e.Id == id);
    }

    public List<Event> GetAll()
    {
      return _events;
    }

    public void Add(Event evet)
    {
      evet.Id = _events.Any() ? _events.Max(e => e.Id) + 1 : 1;
      _events.Add(evet);
    }

    public void Update(Event evet)
    {
      Event? existedEvent = GetById(evet.Id);
      bool isExistedEvent = existedEvent != null;

      if (isExistedEvent)
      {
        existedEvent.Title = evet.Title;
        existedEvent.Description = evet.Description;
        existedEvent.StartAt = evet.StartAt;
        existedEvent.EndAt = evet.EndAt;
      }
    }

    public void Delete(int id)
    {
      Event? existedEvent = GetById(id);
      bool isExistedEvent = existedEvent != null;
      if (isExistedEvent)
      {
        _events.Remove(existedEvent);
      }
    }
  }
}