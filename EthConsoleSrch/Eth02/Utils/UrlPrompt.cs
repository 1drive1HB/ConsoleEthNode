namespace Eth02.Utils
{
    public static class UrlPrompt
    {
        public static string GetUserCustomUrl()
        {
            Console.Write("\t\t\t\t\tEnter custom URL: ");
            return Console.ReadLine();
        }
    }
}
