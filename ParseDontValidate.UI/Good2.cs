namespace ParseDontValidate.UI;

internal class Good2
{

    public static void Run()
    {
        // The same solution as Good1 but with "generics"

        NonEmptyList<string> list = GetListFromUser();

        string first = GetFirstElement(list);

        Console.WriteLine($"The first element in uppercase: {first.ToUpper()}");

    }


    private static NonEmptyList<string> GetListFromUser()
    {
        while (true)
        {

            Console.Write("Enter a comma separated list: ");
            string[] array = Console.ReadLine()!.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (array.Length > 0)
                return new NonEmptyList<string>(array);

        }
    }

    private static T GetFirstElement<T>(NonEmptyList<T>  list)
    {
        return list.Value[0];
    }

    class NonEmptyList<T>
    {
        private readonly List<T> _items; 

        public NonEmptyList(IEnumerable<T> items) 
        { 
            var list  = items.ToList();  

            if (!list.Any())
            {
                throw new ArgumentException("The list cannot be empty", nameof(items));
            }

            _items = list;
        }

        public List<T> Value => _items;
    }
}
