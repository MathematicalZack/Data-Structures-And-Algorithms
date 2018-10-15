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

            values[j + 1] = key;
        }
    }

    public static void MergeSort<T>(IList<T> _values) where T : IEquatable<T>, IComparable<T>, IComparable
    {
        MergeSort(_values, 0, _values.Count - 1);
    }

    private static void MergeSort<T>(IList<T> _values, int _leftBound, int _rightBound) where T : IEquatable<T>, IComparable<T>, IComparable
    {
        if (_leftBound < _rightBound)
        {
            int midPoint = (_rightBound + _leftBound) / 2;
            MergeSort(_values, _leftBound, midPoint);
            MergeSort(_values, midPoint + 1, _rightBound);
            Merge(_values, _leftBound, midPoint, _rightBound);
        }
    }

    private static IList<T> Merge<T>(IList<T> _values, int _leftBound, int _midPoint, int _rightBound) where T : IEquatable<T>, IComparable<T>, IComparable
    {
        Queue<T> left = new Queue<T>(_midPoint - _leftBound + 1);
        Queue<T> right = new Queue<T>(_rightBound - _midPoint);
        for (int i = _leftBound; i <= _rightBound; i++)
        {
            if (i <= _midPoint)
                left.Enqueue(_values[i]);
            else
                right.Enqueue(_values[i]);
        }

        for (int j = _leftBound; j <= _rightBound; j++)
        {
            if (left.Count > 0)
            {
                if (right.Count > 0)
                {
                    if (left.Peek().CompareTo(right.Peek()) < 0)
                        _values[j] = left.Dequeue();
                    else
                        _values[j] = right.Dequeue();

                    continue;
                }

                _values[j] = left.Dequeue();
                continue;
            }

            if (right.Count > 0)
                _values[j] = right.Dequeue();
        }

        return _values;
    }

}

