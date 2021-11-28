using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    /// <summary>Class ICollectionExtensions</summary>
    public static class ICollectionExtensions
    {
        /// <summary>Adds the specified range.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="range">The range.</param>
        public static void Add<T>(this ICollection<T> collection, IEnumerable<T> range)
        {
            for (int index = 0; index < range.Count(); index++) collection.Add(range.ElementAt(index));
        }
        /// <summary>Adds the range.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="range">The range.</param>
        public static void AddRange<T>(this ICollection<T> collection, ICollection<T> range)
        {
            foreach (T item in range) collection.Add(item);
        }
        /// <summary>Fills the with members.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <exception cref="System.ArgumentException">The FillWithMembers&gt;T&lt; method can only be called with an enum as the generic type.</exception>
        public static void FillWithMembers<T>(this ICollection<T> collection)
        {
            if (typeof(T).BaseType != typeof(Enum)) throw new ArgumentException("The FillWithMembers<T> method can only be called with an enum as the generic type.");
            collection.Clear();
            foreach (string name in Enum.GetNames(typeof(T))) collection.Add((T)Enum.Parse(typeof(T), name));
        }
        /// <summary>Removes the specified range.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="range">The range.</param>
        public static void Remove<T>(this ICollection<T> collection, IEnumerable<T> range)
        {
            for (int index = 0; index < range.Count(); index++) collection.Remove(range.ElementAt(index));
        }
    }
}
