namespace ParseDontValidate.UI;

internal class Good1
{

    public static void Run()
    {
        /*
         Fördel: GetFirstElement lyckas alltid, pga har rätt typ direkt
         Fördel: Om det smäller så smäller det tidigt, redan vid "list", vi behöver inte ens anropa GetFirstElement
         Nackdel: ToList i fall där det kanske inte behövs, prestandaproblem
         */
        
        NonEmptyList list = GetListFromUser();

        string first = GetFirstElement(list);

        Console.WriteLine($"The first element in uppercase: {first.ToUpper()}");

    }


    private static NonEmptyList GetListFromUser()
    {
        while (true)
        {

            Console.Write("Enter a comma separated list: ");
            string[] array = Console.ReadLine()!.Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (array.Length > 0)
                return new NonEmptyList(array);

        }
    }

    private static string GetFirstElement(NonEmptyList list)
    {
        // Nackdel: punkt Value

        return list.Value[0];
    }

    // Nackdel: ganska mycket kod, går det att förenkla?

    class NonEmptyList
    {
        private readonly List<string> _items; 

        public NonEmptyList(IEnumerable<string> items) 
        { 
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
