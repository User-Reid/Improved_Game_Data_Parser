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

System.Console.WriteLine("What file would you like to read from big dog?");
var filePath = Console.ReadLine();
var readContentsOfFilePath = File.ReadAllText(filePath);
var reincarnatedObject = JsonSerializer.Deserialize<List<VideoGame>>(readContentsOfFilePath);

if (reincarnatedObject.Count > 0)
{
  foreach (VideoGame videoGame in reincarnatedObject)
  {
    System.Console.WriteLine(videoGame);
  }
}
else
{
  System.Console.WriteLine("You aint got shit in here homie.");
}

Console.ReadKey();

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

  public override string ToString() => $"{Title}; Which was release in {ReleaseYear} and was rated a {Rating}/5";
}
