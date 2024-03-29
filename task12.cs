abstract class Sorter
{
    protected int[] data;

    public Sorter(int[] data)
    {
        this.data = data;
    }

    public void SortAndPrint()
    {
        Sort();
        PrintResult();
    }

    protected abstract void Sort();

    protected void PrintResult()
    {
        Console.WriteLine("Sorted data: {0}", string.Join(", ", data));
    }

    protected void Swap(int i, int j)
    {
        int temp = data[i];
        data[i] = data[j];
        data[j] = temp;
    }
}

class BubbleSorter : Sorter
{
    public BubbleSorter(int[] data) : base(data) { }

    protected override void Sort()
    {
        for (int i = 0; i < data.Length - 1; i++)
        {
            for (int j = 0; j < data.Length - i - 1; j++)
            {
                if (data[j] > data[j + 1])
                {
                    Swap(j, j + 1);
                }
            }
        }
    }
}

class InsertionSorter : Sorter
{
    public InsertionSorter(int[] data) : base(data) { }

    protected override void Sort()
    {
        for (int i = 1; i < data.Length; i++)
        {
            int key = data[i];
            int j = i - 1;

            while (j >= 0 && key < data[j])
            {
                data[j + 1] = data[j];
                j--;
            }

            data[j + 1] = key;
        }
    }
}

class SelectionSorter : Sorter
{
    public SelectionSorter(int[] data) : base(data) { }

    protected override void Sort()
    {
        for (int i = 0; i < data.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < data.Length; j++)
            {
                if (data[j] < data[minIndex])
                {
                    minIndex = j;
                }
            }

            Swap(i, minIndex);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int[] data = { 64, 34, 25, 1, 22, 10, 9 };

        // Bubble sort
        Console.WriteLine("Bubble Sort:");
        Sorter bubbleSorter = new BubbleSorter(data);
        bubbleSorter.SortAndPrint();

        // Insertion sort
        Console.WriteLine("\nInsertion Sort:");
        Sorter insertionSorter = new InsertionSorter(data);
        insertionSorter.SortAndPrint();

        // Selection sort
        Console.WriteLine("\nSelection Sort:");
        Sorter selectionSorter = new SelectionSorter(data);
        selectionSorter.SortAndPrint();
    }
}
