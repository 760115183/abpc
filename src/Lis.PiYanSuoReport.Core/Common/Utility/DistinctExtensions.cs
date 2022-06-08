﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LXG.Core.Common.Utilities
{
    public static class DistinctExtensions
    {
        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> keySelector)
        {
            return source.Distinct(new CommonEqualityComparer<T, V>(keySelector));
        }
    }  
}
