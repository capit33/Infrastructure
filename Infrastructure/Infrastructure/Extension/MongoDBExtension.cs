using MongoDB.Driver;
using System;
using System.Linq.Expressions;

namespace Infrastructure.Extension;

public static class MongoDBExtension
{
    public static UpdateDefinition<TDocument> SetIfNotNull<TDocument, TField>(this UpdateDefinition<TDocument> update,
    Expression<Func<TDocument, TField>> field,
    TField value)
    {
        return value == null ? update : update.Set(field, value);
    }
}
