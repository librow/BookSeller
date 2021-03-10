using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSeller.Infrastructure
{
    public static class UrlExtensions
    {
        // HTTP being passed in, generating a url tp return to the browser after the Cart has been updated
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
