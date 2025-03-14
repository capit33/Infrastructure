using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Extension;

public static class PredicateExtenions
{
    public static Predicate<T> Combine<T>(this List<Predicate<T>> predicates, bool orElse = false, bool returnTrueIfEmpty = false)
    {
        var predicatesCount = predicates?.Count ?? 0;
        if (predicates == null || predicatesCount == 0)
        {
            return returnTrueIfEmpty ? _ => true : null;
        }

        if (predicatesCount == 1)
            return predicates.First();

        return obj => orElse ? predicates.Any(f => f(obj)) : predicates.All(f => f(obj));
    }
}
