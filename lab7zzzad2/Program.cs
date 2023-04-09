using System.Linq;

internal class Program
{

    struct SortTypeTimeCount
    {
        public long ViborSortTimeCount = 0;
        public long ViborSortSwapCount = 0;
        public long InsertationSortTimeCount = 0;
        public long InsertationSortSwapCount = 0;
        public long BubleSortTimeCount = 0;
        public long BubleSortSwapCount = 0;
        public long ShakerSortTimeCount = 0;
        public long ShakerSortSwapCount = 0;
        public long ShellSortTimeCount = 0;
        public long ShellSortSwapCount = 0;

        public SortTypeTimeCount()
        {

        }
    }

    static SortTypeTimeCount count;

    static int[] ViborSort(int[] mas, bool direction = true)
    {
        long tmpTime1 = DateTime.Now.Ticks;

        for (int i = 0; i < mas.Length - 1; i++)
        {

            if (direction)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
                count.ViborSortSwapCount++;
            }
            else
            {
                //поиск минимального числа
                int max = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] > mas[max])
                    {
                        max = j;
                    }
                }
                //обмен элементов
                int temp = mas[max];
                mas[max] = mas[i];
                mas[i] = temp;
                count.ViborSortSwapCount++;
            }


        }
        long tmpTime2 = DateTime.Now.Ticks;

        count.ViborSortTimeCount = tmpTime2 - tmpTime1;
        return mas;
    }

    static int[] InsertationSort(int[] a, bool direction = true)
    {
        long tmpTime1 = DateTime.Now.Ticks;
        for (int i = 1; i < a.Length; i++)
        {
            if (direction)
            {
                int k = a[i];
                int j = i - 1;

                while (j >= 0 && a[j] > k)
                {
                    a[j + 1] = a[j];
                    a[j] = k;
                    j--;
                    count.InsertationSortSwapCount++;
                }
            }
            else
            {
                int k = a[i];
                int j = i - 1;

                while (j >= 0 && a[j] < k)
                {
                    a[j + 1] = a[j];
                    a[j] = k;
                    j--;
                    count.InsertationSortSwapCount++;
                }
            }

        }

        long tmpTime2 = DateTime.Now.Ticks;

        count.InsertationSortTimeCount = tmpTime2 - tmpTime1;
        return a;
    }

    static int[] BubleSort(int[] arr, bool direction = true)
    {
        long tmpTime1 = DateTime.Now.Ticks;
        int temp = 0;
        for (int write = 0; write < arr.Length; write++)
        {
            for (int sort = 0; sort < arr.Length - 1; sort++)
            {
                if (direction)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;

                        count.BubleSortSwapCount++;
                    }
                }

                else
                {
                    if (arr[sort] < arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                        count.BubleSortSwapCount++;
                    }
                }

            }
        }

        long tmpTime2 = DateTime.Now.Ticks;

        count.BubleSortTimeCount = tmpTime2 - tmpTime1;
        return arr;
    }


    static bool CheckSort(int[] arr, bool direction = true)
    {
        for (int write = 0; write < arr.Length; write++)
        {
            for (int sort = 0; sort < arr.Length - 1; sort++)
            {
                if (!direction)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        return false;


                    }
                }

                else
                {
                    if (arr[sort] < arr[sort + 1])
                    {
                        return false;
                    }
                }

            }
        }


        return true;
    }

    static void Swap(ref int e1, ref int e2, string sortType = "shaker")
    {
        var temp = e1;
        e1 = e2;
        e2 = temp;

        if (sortType == "shaker")
            count.ShakerSortSwapCount++;
        if (sortType == "shell")
            count.ShellSortSwapCount++;

    }

    static int[] ShellSort(int[] array, bool direction = true)
    {
        long tmpTime1 = DateTime.Now.Ticks;
        //расстояние между элементами, которые сравниваются
        var d = array.Length / 2;
        while (d >= 1)
        {
            for (var i = d; i < array.Length; i++)
            {
                if (direction)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d], "shell");
                        j = j - d;
                    }
                }
                else
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] < array[j]))
                    {
                        Swap(ref array[j], ref array[j - d], "shell");
                        j = j - d;
                    }
                }

            }

            d = d / 2;
        }


        long tmpTime2 = DateTime.Now.Ticks;

        count.ShellSortTimeCount = tmpTime2 - tmpTime1;
        return array;
    }

    //сортировка перемешиванием
    static int[] ShakerSort(int[] array, bool direction = true)
    {
        long tmpTime1 = DateTime.Now.Ticks;
        for (var i = 0; i < array.Length / 2; i++)
        {
            var swapFlag = false;

            if (direction)
            {
                //проход слева направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1], "shaker");
                        swapFlag = true;
                    }
                }

                //проход справа налево
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j], "shaker");
                        swapFlag = true;
                    }
                }
            }
            else
            {
                //проход слева направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1], "shaker");
                        swapFlag = true;
                    }
                }

                //проход справа налево
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] < array[j])
                    {
                        Swap(ref array[j - 1], ref array[j], "shaker");
                        swapFlag = true;
                    }
                }
            }

            //если обменов не было выходим
            if (!swapFlag)
            {
                break;
            }
        }

        long tmpTime2 = DateTime.Now.Ticks;

        count.ShakerSortTimeCount = tmpTime2 - tmpTime1;

        return array;
    }

    static int[] GenerateArray(int count)
    {
        int[] array = new int[count];

        Random random = new Random();

        int index = 0;
        array.ToList().ForEach(item =>
        {
            array[index] = random.Next(0, 999999);
            index++;
        });

        array.ToList().ForEach(item => Console.WriteLine(item));

        return array;
    }

    static void saveToFile(string fileName = @"D:\файлы\sorted.dat", int[] array = null)
    {

        using (StreamWriter sw = new StreamWriter(@"D:\файлы\sorted.dat"))
        {
            array.ToList().ForEach(item =>
            {
                sw.WriteLine(item);
            });
        }
    }

    static int[] loadFromFile(string fileName = @"D:\файлы\sorted.dat")
    {
        List<int> tmp = new List<int>();
        using (StreamReader sr = new StreamReader(fileName))
        {
            while (sr.Peek() != -1)
            {
                tmp.Add(Int32.Parse(sr.ReadLine()));
            }
        }
        return tmp.ToArray();
    }
    private static void Main(string[] args)
    {
        int[] array = GenerateArray(100000);

        array = ViborSort(array);

        saveToFile("vibor-sorted.dat", array);

        array = GenerateArray(100000);

        array = InsertationSort(array);

        saveToFile("insertation-sorted.dat", array);

        array = GenerateArray(100000);
        array = BubleSort(array);

        saveToFile("bubble-sorted.dat", array);

        array = GenerateArray(100000);
        array = ShakerSort(array);

        saveToFile("shaker-sorted.dat", array);

        array = GenerateArray(100000);
        array = ShellSort(array);
        saveToFile("shell-sorted.dat", array);


        Console.WriteLine($"Сортировка выбором: {count.ViborSortTimeCount / 1000}с \\ {count.ViborSortTimeCount} мс, колличество перестановок ${count.ViborSortSwapCount}");
        Console.WriteLine($"Сортировка вставками: {count.InsertationSortTimeCount / 1000}с \\ {count.InsertationSortTimeCount} мс, колличество перестановок ${count.InsertationSortSwapCount}");
        Console.WriteLine($"Сортировка пузырьком: {count.BubleSortTimeCount / 1000}с \\ {count.BubleSortTimeCount} мс, колличество перестановок ${count.BubleSortSwapCount}");
        Console.WriteLine($"Сортировка Шелла: {count.ShellSortTimeCount / 1000}с \\ {count.ShellSortTimeCount} мс, колличество перестановок ${count.ShellSortSwapCount}");
        Console.WriteLine($"Сортировка шейкер: {count.ShakerSortTimeCount / 1000}с \\ {count.ShakerSortTimeCount} мс, колличество перестановок ${count.ShakerSortSwapCount}");

        bool isSort = false;

        isSort = CheckSort(loadFromFile("vibor-sorted.dat"), true);
        Console.WriteLine($"vibor-sorted.dat > {(isSort ? "Сортированно" : "Не сортированно")}");
        isSort = CheckSort(loadFromFile("vibor-sorted.dat"), false);
        Console.WriteLine($"vibor-sorted.dat < {(isSort ? "Сортированно" : "Не сортированно")}");

        isSort = CheckSort(loadFromFile("insertation-sorted.dat"), true);
        Console.WriteLine($"insertation-sorted.dat > {(isSort ? "Сортированно" : "Не сортированно")}");
        isSort = CheckSort(loadFromFile("insertation-sorted.dat"), false);
        Console.WriteLine($"insertation-sorted.dat < {(isSort ? "Сортированно" : "Не сортированно")}");


        isSort = CheckSort(loadFromFile("bubble-sorted.dat"), true);
        Console.WriteLine($"bubble-sorted.dat > {(isSort ? "Сортированно" : "Не сортированно")}");
        isSort = CheckSort(loadFromFile("bubble-sorted.dat"), false);
        Console.WriteLine($"bubble-sorted.dat < {(isSort ? "Сортированно" : "Не сортированно")}");


        isSort = CheckSort(loadFromFile("shaker-sorted.dat"), true);
        Console.WriteLine($"shaker-sorted.dat > {(isSort ? "Сортированно" : "Не сортированно")}");
        isSort = CheckSort(loadFromFile("shaker-sorted.dat"), false);
        Console.WriteLine($"shaker-sorted.dat < {(isSort ? "Сортированно" : "Не сортированно")}");


        isSort = CheckSort(loadFromFile("shell-sorted.dat"), true);
        Console.WriteLine($"shell-sorted.dat > {(isSort ? "Сортированно" : "Не сортированно")}");
        isSort = CheckSort(loadFromFile("shell-sorted.dat"), false);
        Console.WriteLine($"shell-sorted.dat < {(isSort ? "Сортированно" : "Не сортированно")}");
    }
}