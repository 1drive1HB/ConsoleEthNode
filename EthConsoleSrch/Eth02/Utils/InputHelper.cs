namespace Eth02.Utils
{
    public class InputHelper
    {
        public static string GetUserInput(string? prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}