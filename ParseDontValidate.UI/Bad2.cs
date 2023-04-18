namespace ParseDontValidate.UI;

internal class Bad2
{

    public static void Run()
    {
        // Solution with NonEmptyList that inherits from List<string>

        NonEmptyList list = GetListFromUser();
        string first = GetFirstElement(list);

        // Problem: here "list" might be a list that isn't empty

        list.RemoveAt(0);

        Console.WriteLine($"The first element in uppercase: {first.ToUpper()}");

    }


    private static NonEmptyList GetListFromUser()
    {
        while (true)
        {

            Console.Write("Enter a comma separated list: ");
            string[] array = Console.ReadLine()!.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (array.Length > 0)
                return new NonEmptyList(array);

        }
    }

    private static string GetFirstElement(NonEmptyList list)
    {
        return list[0];
    }

    class NonEmptyList: List<string>
    {
        public NonEmptyList(IEnumerable<string> items) 
        { 
            var list = items.ToList();  

            if (!list.Any())
            {
                throw new ArgumentException("The list cannot be empty", nameof(items));
            }

            AddRange(items);
        }
    }
}
