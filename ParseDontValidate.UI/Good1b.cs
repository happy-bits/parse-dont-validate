namespace ParseDontValidate.UI;

internal class Good1b
{

    public static void Run()
    {
        NonEmptyList list = GetListFromUser();

        string first = GetFirstElement(list);

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
        return list.Value[0];
    }

    // Same as Good1 but with "pattern matching"

    class NonEmptyList
    {
        private readonly List<string> _items;

        public NonEmptyList(IEnumerable<string> items)
        { 
            _items = items.ToList() switch {
                var x when x.Count > 0 => x,
                _ => throw new ArgumentException("The list cannot be empty", nameof(items))
            };
        }

        public List<string> Value => _items;
    }
}
