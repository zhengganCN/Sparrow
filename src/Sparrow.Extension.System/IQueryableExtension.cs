using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sparrow.Extension.System
{
    /// <summary>
    /// IQueryable接口扩展
    /// </summary>
    public static class IQueryableExtension
    {
        /// <summary>
        /// Concatenates two sequences.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="condition"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Concat<TSource>(this IQueryable<TSource> source1, bool condition, IEnumerable<TSource> source2)
        {
            return condition ? source1.Concat(source2) : source1;
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the type parameter's default value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<TSource> DefaultIfEmpty<TSource>(this IQueryable<TSource> source, bool condition)
        {
            return condition ? source.DefaultIfEmpty() : source;
        }


        /// <summary>
        /// Returns the elements of the specified sequence or the specified value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static IQueryable<TSource> DefaultIfEmpty<TSource>(this IQueryable<TSource> source, bool condition, TSource defaultValue)
        {
            return condition ? source.DefaultIfEmpty(defaultValue) : source;
        }
        /// <summary>
        /// Returns distinct elements from a sequence by using the default equality comparer to compare values.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Distinct<TSource>(this IQueryable<TSource> source, bool condition)
        {
            return condition ? source.Distinct() : source;
        }


        /// <summary>
        /// Returns distinct elements from a sequence by using a specified System.Collections.Generic.IEqualityComparer`1
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Distinct<TSource>(this IQueryable<TSource> source, bool condition, IEqualityComparer<TSource> comparer)
        {
            return condition ? source.Distinct(comparer) : source;
        }


        /// <summary>
        /// Produces the set difference of two sequences by using the default equality comparer to compare values.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Except<TSource>(this IQueryable<TSource> source, bool condition, IEnumerable<TSource> source2)
        {
            return condition ? source.Except(source2) : source;
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the specified System.Collections.Generic.IEqualityComparer`1
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="source2"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Except<TSource>(this IQueryable<TSource> source, bool condition, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
        {
            return condition ? source.Except(source2, comparer) : source;
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the default equality comparer to compare values.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="condition"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Intersect<TSource>(this IQueryable<TSource> source1, bool condition, IEnumerable<TSource> source2)
        {
            return condition ? source1.Intersect(source2) : source1;
        }
        /// <summary>
        /// Produces the set intersection of two sequences by using the specified System.Collections.Generic.IEqualityComparer`1
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="condition"></param>
        /// <param name="source2"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Intersect<TSource>(this IQueryable<TSource> source1, bool condition, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
        {
            return condition ? source1.Intersect(source2, comparer) : source1;
        }

        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Reverse<TSource>(this IQueryable<TSource> source, bool condition)
        {
            return condition ? source.Reverse() : source;
        }

        /// <summary>
        /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Skip<TSource>(this IQueryable<TSource> source, bool condition, int count)
        {
            return condition ? source.Skip(count) : source;
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<TSource> SkipWhile<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, int, bool>> predicate)
        {
            return condition ? source.SkipWhile(predicate) : source;
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<TSource> SkipWhile<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            return condition ? source.SkipWhile(predicate) : source;
        }


        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Take<TSource>(this IQueryable<TSource> source, bool condition, int count)
        {
            return condition ? source.Take(count) : source;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<TSource> TakeWhile<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            return condition ? source.TakeWhile(predicate) : source;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<TSource> TakeWhile<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, int, bool>> predicate)
        {
            return condition ? source.TakeWhile(predicate) : source;
        }


        /// <summary>
        /// Produces the set union of two sequences by using the default equality comparer.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="condition"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Union<TSource>(this IQueryable<TSource> source1, bool condition, IEnumerable<TSource> source2)
        {
            return condition ? source1.Union(source2) : source1;
        }

        /// <summary>
        /// Produces the set union of two sequences by using a specified System.Collections.Generic.IEqualityComparer`1.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source1"></param>
        /// <param name="condition"></param>
        /// <param name="source2"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Union<TSource>(this IQueryable<TSource> source1, bool condition, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
        {
            return condition ? source1.Union(source2, comparer) : source1;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, int, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
    }
}
