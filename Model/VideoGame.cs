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

  public override string ToString() => $"{Title}; Which was released in {ReleaseYear} and was rated a {Rating}/5.";
}
