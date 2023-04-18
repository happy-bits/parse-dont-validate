namespace ParseDontValidate.UI;

internal class Good1
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
        // Good: GetFirstElement will always succeed since we limit the parmeter
        // Small problem: we need to write ".Value"

        return list.Value[0];
    }

    class NonEmptyList
    {
        private readonly List<string> _items; 

        public NonEmptyList(IEnumerable<string> items) 
        { 
            // Problem: We might call ToList even if it's not necessary (performance problem)
            var list  = items.ToList();  

            if (!list.Any())
            {
                throw new ArgumentException("The list cannot be empty", nameof(items));
            }

            _items = list;
        }

        public List<string> Value => _items;
    }
}
