namespace ParseDontValidate.UI;

internal class Bad1
{

    public static void Run()
    {
        string[] array = GetListFromUser();

        string? first = GetFirstElement(array);

        Console.WriteLine($"The first element in uppercase: {first?.ToUpper()}");
    }

    private static string[] GetListFromUser()
    {
        while (true)
        {

            Console.Write("Enter a comma separated list: ");
            string[] array = Console.ReadLine()!.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (array.Length > 0)
                return array;

        }
    }

    private static string? GetFirstElement(string[] array)
    {
        // Problem: This function has to handle problematic input (if the array is empty)

        if (array.Length == 0)
            return null;

        return array[0];
    }
}
