using System;
using System.Collections.Generic;

static class SortingAlgorithms
{

    //Sorts list of generic type in quadratic time. Good for relatively short collections
    //This implementation assumes an indexed parameter type
    public static void InsertionSort<T>(IList<T> values) where T : IEquatable<T>, IComparable<T>, IComparable
    {
        for (int i = 1; i < values.Count; i++)
        {
            T key = values[i];
            int j = i - 1;

            while (j >= 0 && values[j].CompareTo(key) > 0)
            {
                values[j + 1] = values[j];
                j--;
            }

            values[j] = key;
        }
    }

}

