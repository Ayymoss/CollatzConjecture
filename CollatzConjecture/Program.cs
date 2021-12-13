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
            if (collatzLogic[0] <= 1000) return;
            Console.WriteLine("\nIndex: {0:N0}\n - Value: \t\t{1:N0}\n - Value Range: \t{2:N0}\n - Tree Size: \t\t{3:N0}",
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
        Console.WriteLine("Index ID: {0:N0} - Highest Tree: {1:N0}", indexTreeSizeStore, treeSizeStore);
        Console.WriteLine("Index ID: {0:N0} - Highest Value High: {1:N0}", indexValueHighStore, valueHighStore);
    }

    private static long[] CollatzLogic(long value)
    {
        var treeLength = 1;
        var valueStart = value;
        var valueRange = value;
        while (value > 1)
        {
            if (value > valueRange) valueRange = value;

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

        valueRange -= valueStart;
        return new[] {treeLength, valueRange};
    }
}