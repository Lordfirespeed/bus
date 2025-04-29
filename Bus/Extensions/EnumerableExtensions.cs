/*
 * Copyright (c) 2024 Sigurd Team
 * The Sigurd Team licenses this file to you under the LGPL-3.0-OR-LATER license.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Bus.Extensions;

/// <summary>
/// Extension methods for <see cref="IEnumerable{T}"/> instances.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>Execute code for every element in a collection and pass-through the original value.</summary>
    /// <typeparam name="TSource">The inner type of the collection</typeparam>
    /// <param name="source">The collection</param>
    /// <param name="action">The action to execute</param>
    /// <returns>The collection, unchanged</returns>
    public static IEnumerable<TSource> Tap<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (action is null) throw new ArgumentNullException(nameof(action));
        return TapIterator(source, action);
    }

    private static IEnumerable<TSource> TapIterator<TSource>(IEnumerable<TSource> source, Action<TSource> action)
    {
        foreach (TSource element in source) {
            action(element);
            yield return element;
        }
    }
}
