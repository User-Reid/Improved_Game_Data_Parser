var userInteractor = new ConsoleUserInteractor();
var app = new GameDataParserApp(userInteractor, new GamesPrinter(userInteractor), new VideoGamesDeserializer(userInteractor), new LocalFileReader());
var logger = new Logger("log.txt");

try
{
  app.Run();
}
catch (Exception ex)
{
  System.Console.WriteLine("Sorry fam, the application experienced an error" +
  "and will have to be closed :()");
  logger.Log(ex);
}

System.Console.WriteLine("Press any key to close.");
Console.ReadKey();