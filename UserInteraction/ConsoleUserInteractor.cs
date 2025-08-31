public class ConsoleUserInteractor : IUserInteractor {
    public void PrintMessage(string message)
    {
        System.Console.WriteLine(message);
      }

    public void PrintError(string message)
    {
            var originalColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Red;
      System.Console.WriteLine(message);
      Console.ForegroundColor = originalColor;
    }
       public string ReadValidFilePath()
    {
      bool isFilePathValid = false;
      string fileName;
      do
      {
        System.Console.WriteLine("Enter the path to the JSON file: ");
      fileName = Console.ReadLine();
        if (fileName is null)
      {
        System.Console.WriteLine("The file name cannot be null");
      }
      else if (fileName == string.Empty)
      {
        System.Console.WriteLine("The file name cannot be empty");
      }
      else if (!File.Exists(fileName))
      {
        System.Console.WriteLine("The file does not exist");
      }
      else
      {
        isFilePathValid = true;
      }
      } while (!isFilePathValid);
      return fileName;
    }
}
