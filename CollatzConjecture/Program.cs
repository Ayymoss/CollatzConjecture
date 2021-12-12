namespace CollatzConjecture;

internal static class CollatzConjecture
{
    private static void Main()
    {
        var index = 0;
        var indexValueHighStore = 0;
        long valueHighStore = 0;
        var indexTreeSizeStore = 0;
        long treeSizeStore = 0;
        Console.WriteLine("\nProcessing...\n");
        Parallel.For(1, 100000000000, value =>
        {
            var collatzLogic = CollatzLogic(value);
            if (collatzLogic[0] <= 1100) return;
            Console.WriteLine("\nIndex: {0:N0}\n - Value: \t{1:N0}\n - Value High: \t{2:N0}\n - Tree Size: \t{3:N0}",
                index, value, collatzLogic[1], collatzLogic[0]);

            if (value > valueHighStore)
            {
                indexValueHighStore = index;
                valueHighStore = value;
            }

            if (collatzLogic[0] > treeSizeStore)
            {
                indexTreeSizeStore = index;
                treeSizeStore = collatzLogic[0];
            }

            index++;
        });
        Console.WriteLine("\nComplete...\n");
        Console.WriteLine("Index ID: {0} - Highest Tree: {1}", indexTreeSizeStore, treeSizeStore);
        Console.WriteLine("Index ID: {0} - Highest Value High: {1}", indexValueHighStore, valueHighStore);
    }

    private static long[] CollatzLogic(long value)
    {
        var treeLength = 1;
        var valueHigh = value;
        while (value > 1)
        {
            if (value > valueHigh) valueHigh = value;

            if (value % 2 != 0)
            {
                treeLength++;
                value = value * 3 + 1;
            }
            else
            {
                treeLength++;
                value /= 2;
            }
        }

        return new[] {treeLength, valueHigh};
    }
}