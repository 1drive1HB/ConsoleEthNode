namespace Eth02.Utils
{
    public static class TableHelperAddressEth
    {
        public static void DisplayTable(List<string[]> data)
        {
            if (data.Count == 0)
            {
                Console.WriteLine("\t\t\t\t\tNo data to display.");
                return;
            }

            int[] columnWidths = new int[data[0].Length];

            for (int i = 0; i < data[0].Length; i++)
            {
                columnWidths[i] = data.Max(x => x[i].Length) + 2;
            }

            foreach (var row in data)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    Console.Write(row[i].PadRight(columnWidths[i]));
                }
                Console.WriteLine();
            }
        }
    }
}
