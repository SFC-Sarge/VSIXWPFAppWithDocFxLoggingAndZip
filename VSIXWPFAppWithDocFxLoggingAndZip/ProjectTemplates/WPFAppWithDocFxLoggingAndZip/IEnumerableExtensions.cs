using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace $safeprojectname$
{
    /// <summary>Class IEnumerableExtensions</summary>
    public static class IEnumerableExtensions
    {
        /// <summary>Adds the specified item.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="item">The item.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> Add<T>(this IEnumerable<T> collection, T item)
        {
            foreach (T currentItem in collection) yield return currentItem;
            yield return item;
        }
        /// <summary>Distincts the by.</summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns>IEnumerable&lt;TSource&gt;.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            return source.Where(element => seenKeys.Add(keySelector(element)));
        }
        /// <summary>Finds all children.</summary>
        /// <param name="obj">The object.</param>
        /// <returns>IEnumerable&lt;DependencyObject&gt;.</returns>
        public static IEnumerable<DependencyObject> FindAllChildren(this DependencyObject obj) => obj.FindChildren().SelectAllRecursively(o => o.FindChildren());
        /// <summary>Selects all recursively.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="func">The function.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> SelectAllRecursively<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> func) => (items ?? Enumerable.Empty<T>()).SelectMany(o => new[] { o }.Concat(SelectAllRecursively(func(o), func)));
        /// <summary>Skips the exceptions.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> SkipExceptions<T>(this IEnumerable<T> values)
        {
            using IEnumerator<T> enumerator = values.GetEnumerator();
            bool next = true;
            while (next)
            {
                try
                {
                    next = enumerator.MoveNext();
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
                if (next) yield return enumerator.Current;
            }
        }
        /// <summary>Finds the children.</summary>
        /// <param name="obj">The object.</param>
        /// <returns>IEnumerable&lt;DependencyObject&gt;.</returns>
        public static IEnumerable<DependencyObject> FindChildren(this DependencyObject obj) => Enumerable.Range(0, VisualTreeHelper.GetChildrenCount(obj))
                .Select(i => VisualTreeHelper.GetChild(obj, i));
        /// <summary>Determines whether the specified data is any.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns><c>true</c> if the specified data is any; otherwise, <c>false</c>.</returns>
        public static bool IsAny<T>(this IEnumerable<T> data) => data?.Any() == true;
        /// <summary>Determines whether [is null or empty] [the specified list].</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns><c>true</c> if [is null or empty] [the specified list]; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list) => !(list?.Any() ?? false);
        /// <summary>Nots the null any.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public static bool NotNullAny<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate) => enumerable?.Any(predicate) == true;
        /// <summary>Compares the specified second.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>System.Int32.</returns>
        public static int Compare<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first is null || second is null)
                return Comparer.Default.Compare(first, second);

            Comparer<T> elementComparer = Comparer<T>.Default;
            int compareResult;
            using (IEnumerator<T> firstEnum = first.GetEnumerator())
            using (IEnumerator<T> secondEnum = second.GetEnumerator())
                do
                {
                    bool gotFirst = firstEnum.MoveNext();
                    bool gotSecond = secondEnum.MoveNext();
                    if (!gotFirst && !gotSecond)
                        return 0;
                    if (gotFirst != gotSecond)
                        return gotFirst ? 1 : -1;

                    compareResult = elementComparer.Compare(firstEnum.Current, secondEnum.Current);
                } while (compareResult == 0);
            return compareResult;
        }
        /// <summary>Counts the specified collection.</summary>
        /// <param name="collection">The collection.</param>
        /// <returns>System.Int32.</returns>
        public static int Count(this IEnumerable collection)
        {
            int count = 0;
            foreach (object item in collection) count++;
            return count;
        }
    }
}
