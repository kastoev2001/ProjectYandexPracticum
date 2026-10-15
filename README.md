# ProjectYandexPracticum

Учебный REST API для управления событиями на ASP.NET Core. Проект предоставляет операции создания, просмотра, обновления и удаления событий. Для работы с API используется Swagger UI.

## Требования

- .NET SDK 8.0.
- Терминал или среда разработки с поддержкой .NET 8.

База данных не требуется. События хранятся в памяти приложения в `List<Event>`.

## Запуск

Откройте терминал в каталоге, содержащем `ProjectYandexPracticum.csproj`, и выполните:

```powershell
dotnet restore
dotnet build
dotnet run --launch-profile http
```

После успешного запуска откройте Swagger UI:

`http://localhost:port/swagger`

Базовый адрес API: `http://localhost:port/api/events`.

Swagger UI для HTTPS: https://localhost:7193/swagger/index.html.

Порты и профили запуска заданы в `Properties/launchSettings.json`. Для остановки приложения нажмите `Ctrl+C`.

## Структура проекта

| Путь | Назначение |
| --- | --- |
| `Modules/` | Модель события, пространство имён `ProjectYandexPracticum.Models` |
| `Controllers/` | HTTP-эндпоинты |
| `Services/` | Бизнес-логика |
| `Interfaces/` | Контракты |
| `Date/` | Хранение моковых данных |
| `Program.cs` | Настройка приложения, DI и Swagger |