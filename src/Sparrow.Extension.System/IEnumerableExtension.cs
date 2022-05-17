using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Extension.System
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Appends a value to the end of the sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, bool confition, TSource element)
        {
            return confition ? source.Append(element) : source;
        }

        /// <summary>
        /// Returns the input typed as System.Collections.Generic.IEnumerable`1.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source, bool confition)
        {
            return confition ? source.AsEnumerable() : source;
        }

        /// <summary>
        /// Concatenates two sequences.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="confition"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, bool confition, IEnumerable<TSource> second)
        {
            return confition ? first.Concat(second) : first;
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the specified value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, bool confition)
        {
            return confition ? source.DefaultIfEmpty() : source;
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the specified value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException"></exception>
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, bool confition, TSource defaultValue)
        {
            return confition ? source.DefaultIfEmpty(defaultValue) : source;
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using the default equality comparer to compare values.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, bool confition)
        {
            return confition ? source.Distinct() : source;
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified System.Collections.Generic.IEqualityComparer`1 to compare values.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, bool confition, IEqualityComparer<TSource> comparer)
        {
            return confition ? source.Distinct(comparer) : source;
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the default equality comparer to compare values.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="confition"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, bool confition, IEnumerable<TSource> second)
        {
            return confition ? first.Except(second) : first;
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the specified System.Collections.Generic.IEqualityComparer`1 to compare values.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="confition"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException"></exception>
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, bool confition, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return confition ? first.Except(second, comparer) : first;
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the default equality comparer to compare values.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="confition"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, bool confition, IEnumerable<TSource> second)
        {
            return confition ? first.Intersect(second) : first;
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the specified System.Collections.Generic.IEqualityComparer`1 to compare values.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="confition"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, bool confition, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return confition ? first.Intersect(second, comparer) : first;
        }

        /// <summary>
        /// Adds a value to the beginning of the sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, bool confition, TSource element)
        {
            return confition ? source.Prepend(element) : source;
        }


        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source, bool confition)
        {
            return confition ? source.Reverse() : source;
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, bool confition, Func<TSource, bool> predicate)
        {
            return confition ? source.SkipWhile(predicate) : source;
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, bool confition, Func<TSource, int, bool> predicate)
        {
            return confition ? source.SkipWhile(predicate) : source;
        }

        /// <summary>
        /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, bool confition, int count)
        {
            return confition ? source.Skip(count) : source;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, bool confition, Func<TSource, bool> predicate)
        {
            return confition ? source.TakeWhile(predicate) : source;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, bool confition, Func<TSource, int, bool> predicate)
        {
            return confition ? source.TakeWhile(predicate) : source;
        }

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, bool confition, int count)
        {
            return confition ? source.Take(count) : source;
        }

        /// <summary>
        /// Produces the set union of two sequences by using the default equality comparer.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="confition"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, bool confition, IEnumerable<TSource> second)
        {
            return confition ? first.Union(second) : first;
        }

        /// <summary>
        /// Produces the set union of two sequences by using a specified System.Collections.Generic.IEqualityComparer`1.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="confition"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, bool confition, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return confition ? first.Union(second, comparer) : first;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, bool confition, Func<TSource, bool> predicate)
        {
            return confition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="confition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, bool confition, Func<TSource, int, bool> predicate)
        {
            return confition ? source.Where(predicate) : source;
        }
    }
}
