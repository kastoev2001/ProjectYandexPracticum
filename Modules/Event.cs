using System.ComponentModel.DataAnnotations;

namespace ProjectYandexPracticum.Models
{
  public class Event
  {
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Заголовок обязателен для заполнения.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Описание обязательно для заполненеия.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Дата начала обязательна.")]
    public DateTime StartAt { get; set; }

    [Required(ErrorMessage = "Дата окончания обязательна.")]
    public DateTime EndAt { get; set; }
  }
}