using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookSeller.Infrastructure
{
    // Tool to convert Cart object to Json (string) file and then back to object (b/c can't store Carts in a session)
    public static class SessionExtensions
    {
        // Set Json method
        public static void SetJson (this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // Get Json method
        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
