using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace KargorERP.Utilities
{
    public static class ResponseUtilities
    {
        public static async Task<ObjectResult> TryOkResultAsync<T>(Func<Task<T>> method)
        {
            return await TryResultCommonAsync(200, method);
        }

        private static async Task<ObjectResult> TryResultCommonAsync<T>(int statusCode, Func<Task<T>> method)
        {
            var result = new ObjectResult(null);
            
            try
            {
                result.Value = await method();
                result.StatusCode = statusCode;
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}