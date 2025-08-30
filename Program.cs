// using System.Text.Json;

// Console.WriteLine("Enter the name of the file you want to read: ");
// var fileName = Console.ReadLine();

// var fileContents = File.ReadAllText(fileName);

// var videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);

// if (videoGames.Count > 0)
// {
//   System.Console.WriteLine();
//   System.Console.WriteLine("Loaded games are:");
//   foreach (VideoGame videoGame in videoGames)
//   {
//     System.Console.WriteLine(videoGame);
//     System.Console.WriteLine("XXXXXXXX");
//   }
// }
// else
// {
//   System.Console.WriteLine("No games are present in the input file.");
// }

// Console.ReadKey();

// public class VideoGame
// {
//   public string Title { get; }
//   public int ReleaseYear { get; }
//   public decimal Rating { get; }

//   public VideoGame(string title, int releaseYear, decimal rating)
//   {
//     Title = title;
//     ReleaseYear = releaseYear;
//     Rating = rating;
//   }

//   public override string ToString() => $"{Title}; Which was released in {ReleaseYear} and was rated a {Rating}/5.";
// }
using System.Text.Json;

System.Console.WriteLine("What file would you like to read from?");
string filePath = Console.ReadLine();
string fileContents;

if (File.Exists(filePath))
{
  fileContents = File.ReadAllText(filePath);
}
else
{
  WritingEmptyFiles.WriteFile(filePath);
  fileContents = File.ReadAllText(filePath);
}

var videoGameList = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);

if (videoGameList.Count > 0)
{
  foreach (VideoGame videoGame in videoGameList)
  {
    System.Console.WriteLine(videoGame);
  }
}
else
{
  System.Console.WriteLine("You aint got shit in here homie💀");
}

Console.ReadKey();

public static class WritingEmptyFiles
{
  public static void WriteFile(string filePath)
  {
    File.WriteAllText(filePath, "[]");
  }
}

public class VideoGame
{
  public string Title { get; }
  public int ReleaseYear { get; }
  public decimal Rating { get; }

  public VideoGame(string title, int releaseYear, decimal rating)
  {
    Title = title;
    ReleaseYear = releaseYear;
    Rating = rating;
  }

  public override string ToString() => $"{Title}; Which was release in {ReleaseYear} and {Rating}.5";
}