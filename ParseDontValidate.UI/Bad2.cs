namespace ParseDontValidate.UI;

internal class Bad2
{

    public static void Run()
    {
        NonEmptyList list = GetListFromUser();
        string first = GetFirstElement(list);

        // Problem: kan av misstag ta bort ett element och då är det inte en NonEmptyList längre
        list.RemoveAt(0);

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
        // Fördel, slipper punkt Value

        return list[0];
    }

    // Lösning med arv

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
