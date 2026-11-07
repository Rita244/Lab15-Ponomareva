// ### Часть 1. Первый JSON

// Player player = new()
// {
//     Name = "Артём",
//     Level = 5
// };

// string json = JsonSerializer.Serialize(player);
// Console.WriteLine(json);

// JsonSerializerOptions options = new()
// {
//     WriteIndented = true
// };

// string prettyJson = JsonSerializer.Serialize(player, options);
// Console.WriteLine(prettyJson);

// // результат Serialize имеет тип string,
// // потому что JSON — это обычный текст, а не объект
// // Serialize не меняет объект, а создаёт его текстовое представление

// class Player
// {
//     public string Name { get; set; } = "";
//     public int Level { get; set; }
// }


// ### Часть 2. JSON → объект

// Player? restored = JsonSerializer.Deserialize<Player>(json);

// if (restored != null)
// {
//     Console.WriteLine($"{restored.Name}, уровень {restored.Level}");
// }

// string manualJson = """
// {
//   "Name": "Мария",
//   "Level": 50
// }
// """;

// Player? manualRestored = JsonSerializer.Deserialize<Player>(manualJson);

// if (manualRestored != null)
// {
//     Console.WriteLine($"{manualRestored.Name}, уровень {manualRestored.Level}");
// }

// ### Часть 3. JSON + файл

// string fileJson = JsonSerializer.Serialize(player, options);

// File.WriteAllText("player.json", fileJson);

// Console.WriteLine(Path.GetFullPath("player.json"));

// string loadedJson = File.ReadAllText("player.json");

// Player? loadedPlayer = JsonSerializer.Deserialize<Player>(loadedJson);

// if (loadedPlayer != null)
// {
//     Console.WriteLine("Восстановлено из файла:");
//     Console.WriteLine($"{loadedPlayer.Name}, уровень {loadedPlayer.Level}");
// }

// ### Часть 4. Коллекция объектов

// using System.Text.Json;
// List<Player> players =
// [
//     new() { Name = "Артём", Level = 5 },
//     new() { Name = "Мария", Level = 50 },
//     new() { Name = "Иван", Level = 12 }
// ];
// string listJson = JsonSerializer.Serialize(players, options);
// File.WriteAllText("players.json", listJson);

// string loadedListJson = File.ReadAllText("players.json");
// List<Player>? loadedPlayers = JsonSerializer.Deserialize<List<Player>>(loadedListJson);

// if (loadedPlayers != null)
// {
//     Console.WriteLine($"Загружено игроков: {loadedPlayers.Count}");

//     Console.WriteLine($"Первый игрок: {loadedPlayers[0].Name}");

//     Console.WriteLine($"Уровень второго игрока: {loadedPlayers[1].Level}");
// }

// ### Эксперимент: некорректный JSON

// try
// {
//     string brokenJson = File.ReadAllText("players.json");
//     List<Player>? broken = JsonSerializer.Deserialize<List<Player>>(brokenJson);
//     Console.WriteLine("Десериализация прошла");
// }
// catch (JsonException ex)
// {
//     Console.WriteLine($"Ошибка разбора JSON: {ex.Message}");
// }
// // исключение JsonException
// // Оно появляется, когда JSON нет скобки/кавычки
// // или не соответствует ожидаемому типу (вместо числа — слово)

// // ## Итоговая задача. Сохранение настроек игры

// using System.Text.Json;

// string settingsPath = "settings.json";

// GameSettings settings = new()
// {
//     PlayerName = "Артём",
//     Volume = 80,
//     FullScreen = true,
//     Difficulty = Difficulty.Hard
// };

// if (!File.Exists(settingsPath))
// {
//     Console.WriteLine("Файла настроек нет — создаём и сохраняем.");

//     JsonSerializerOptions options = new()
//     {
//         WriteIndented = true
//     };

//     string settingsJson = JsonSerializer.Serialize(settings, options);

//     File.WriteAllText(settingsPath, settingsJson);
// }
// else
// {
//     Console.WriteLine("Файл настроек найден — используем его.");
// }

// Console.WriteLine();
// Console.WriteLine("Загрузка настроек...");
// Console.WriteLine();

// string loadJson = File.ReadAllText(settingsPath);

// GameSettings? loaded = JsonSerializer.Deserialize<GameSettings>(loadJson);

// if (loaded != null)
// {
//     Console.WriteLine($"Игрок: {loaded.PlayerName}");
//     Console.WriteLine($"Громкость: {loaded.Volume}");
//     Console.WriteLine($"Полный экран: {(loaded.FullScreen ? "да" : "нет")}");
//     Console.WriteLine($"Сложность: {loaded.Difficulty}");
// }


// class GameSettings
// {
//     public string PlayerName { get; set; } = "";
//     public int Volume { get; set; }
//     public bool FullScreen { get; set; }
//     public Difficulty Difficulty { get; set; }
// }

// enum Difficulty
// {
//     Easy,
//     Normal,
//     Hard
// }

// ## Самостоятельные задания

// ### ★ JSON объекта

// Book myBook = new()
// {
//     Title = "Мастер и Маргарита",
//     Author = "Булгаков",
//     Pages = 480,
//     Year = 1967
// };

// string bookJson = JsonSerializer.Serialize(myBook, options);
// Console.WriteLine("Сериализованный объект:");
// Console.WriteLine(bookJson);

// Book? restoredBook = JsonSerializer.Deserialize<Book>(bookJson);

// if (restoredBook != null)
// {
//     Console.WriteLine("Восстановленный объект:");
//     Console.WriteLine($"{restoredBook.Title}, автор {restoredBook.Author}, {restoredBook.Pages} стр., {restoredBook.Year} г.");
// }

// ### ★★ JSON коллекции

List<Book> books =
[
    new() { Title = "Война и мир", Author = "Толстой", Pages = 1200, Year = 1869 },
    new() { Title = "1984", Author = "Оруэлл", Pages = 328, Year = 1949 },
    new() { Title = "Фауст", Author = "Гёте", Pages = 500, Year = 1808 }
];

File.WriteAllText("books.json", JsonSerializer.Serialize(books, options));

List<Book>? loadedBooks = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText("books.json"));

if (loadedBooks != null)
{
    Console.WriteLine($"Количество книг: {loadedBooks.Count}");
    Console.WriteLine($"Первая книга: {loadedBooks[0].Title}");
    Console.WriteLine($"Год выхода последней: {loadedBooks[^1].Year}");
}

### ★★★ JSON + существующая коллекция

using System.Text.Json;

Library library = new()
{
    Books =
    [
        new Book { Title = "Война и мир",   Author = "Толстой",  Pages = 1200, Year = 1869 },
        new Book { Title = "1984",          Author = "Оруэлл",   Pages = 328,  Year = 1949 },
        new Book { Title = "Мастер и Маргарита", Author = "Булгаков", Pages = 480, Year = 1967 }
    ],
    Copies = new Dictionary<string, int>
    {
        ["Война и мир"] = 3,
        ["1984"] = 5,
        ["Мастер и Маргарита"] = 2
    }
};

JsonSerializerOptions options = new()
{
    WriteIndented = true
};

string json = JsonSerializer.Serialize(library, options);

File.WriteAllText("library.json", json);
Console.WriteLine("Библиотека сохранена в library.json");
Console.WriteLine(new string('-', 40));

string loadedJson = File.ReadAllText("library.json");

Library? restored = JsonSerializer.Deserialize<Library>(loadedJson);

if (restored != null)
{
    Console.WriteLine($"Книг в фонде: {restored.Books.Count}");

    Console.WriteLine();
    Console.WriteLine("Книги:");
    foreach (Book book in restored.Books)
    {
        Console.WriteLine($"- {book.Title} ({book.Author}, {book.Year} г.), {book.Pages} стр.");
    }

    Console.WriteLine();
    Console.WriteLine("Экземпляры по названиям:");
    foreach (KeyValuePair<string, int> pair in restored.Copies)
    {
        Console.WriteLine($"- {pair.Key}: {pair.Value} экз.");
    }
}

class Library
{
    public List<Book> Books { get; set; } = [];
    public Dictionary<string, int> Copies { get; set; } = [];
}

class Book
{
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public int Pages { get; set; }
    public int Year { get; set; }
}
