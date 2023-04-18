namespace ParseDontValidate.UI;

internal class Good3
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

    // The same as Good2 but with shorter syntax

    public class NonEmptyList
    {
        private readonly List<string> _items;

        public NonEmptyList(IEnumerable<string> items) =>
            _items = items.Any() ? items.ToList() : throw new ArgumentException("The list cannot be empty", nameof(items));

        public List<string> Value => _items;
    }


}