using System.IO;

public class SaveToFile
{
    public static void AppendToFile(string expression, double result)
    {
        using (StreamWriter file = File.AppendText("miniräknare.txt"))
        {
            file.WriteLine($"{expression} = {result}");
        }
    }
}
