using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    /// <summary>Class ObservableCollectionExtensions</summary>
    public static class ObservableCollectionExtensions
    {
        /// <summary>Adds the range.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oc">The oc.</param>
        /// <param name="collection">The collection.</param>
        /// <exception cref="System.ArgumentNullException">collection</exception>
        public static void AddRange<T>(this ObservableCollection<T> oc, IEnumerable<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (var item in collection)
            {
                oc.Add(item);
            }

        }
        /// <summary>Adds the unique if not empty.</summary>
        /// <param name="collection">The collection.</param>
        /// <param name="text">The text.</param>
        public static void AddUniqueIfNotEmpty(this ObservableCollection<string> collection, string text)
        {
            if (!string.IsNullOrEmpty(text) && !collection.Contains(text)) collection.Add(text);
        }
        /// <summary>Sorts the specified key selector.</summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="keySelector">The key selector.</param>
        public static void Sort<TSource, TKey>(this ObservableCollection<TSource> collection, Func<TSource, TKey> keySelector)
        {
            List<TSource> sorted = collection.OrderBy(keySelector).ToList();
            for (int i = 0; i < sorted.Count(); i++)
                collection.Move(collection.IndexOf(sorted[i]), i);
        }
        /// <summary>To the observable collection.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputCollection">The input collection.</param>
        /// <returns>ObservableCollection&lt;T&gt;.</returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> inputCollection) => new ObservableCollection<T>(inputCollection);
    }
}
