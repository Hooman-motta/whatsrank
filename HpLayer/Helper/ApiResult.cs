using System.Collections.Generic;

// layer
using HpLayer.Extensions;

namespace HpLayer.Helper {
    public class ApiResult {
        public bool IsSuccess { get; set; }

        public object Data { get; set; } = null;

        public ApiMessage Result { get; set; }

        public List<ApiMessage> Errors { get; set; }

        public static ApiResult Failed (int errorCode) {
            switch (errorCode) {
                case 400:
                    return Failed (ApiStatusCode.BadRequest, EnumExtensions.GetDisplayName (ApiStatusCode.BadRequest));
                case 401:
                    return Failed (ApiStatusCode.Unauthorized, EnumExtensions.GetDisplayName (ApiStatusCode.Unauthorized));
                case 403:
                    return Failed (ApiStatusCode.Forbid, EnumExtensions.GetDisplayName (ApiStatusCode.Forbid));
                case 404:
                    return Failed (ApiStatusCode.NotFound, EnumExtensions.GetDisplayName (ApiStatusCode.NotFound));
                case 500:
                default:
                    return Failed (ApiStatusCode.ServerError, EnumExtensions.GetDisplayName (ApiStatusCode.ServerError));
            }
        }

        public static ApiResult Failed (ApiStatusCode apiStatusCode = ApiStatusCode.ServerError) {
            switch (apiStatusCode) {
                case ApiStatusCode.BadRequest:
                    return Failed (ApiStatusCode.BadRequest, EnumExtensions.GetDisplayName (ApiStatusCode.BadRequest));
                case ApiStatusCode.Unauthorized:
                    return Failed (ApiStatusCode.Unauthorized, EnumExtensions.GetDisplayName (ApiStatusCode.Unauthorized));
                case ApiStatusCode.Forbid:
                    return Failed (ApiStatusCode.Forbid, EnumExtensions.GetDisplayName (ApiStatusCode.Forbid));
                case ApiStatusCode.NotFound:
                    return Failed (ApiStatusCode.NotFound, EnumExtensions.GetDisplayName (ApiStatusCode.NotFound));
                case ApiStatusCode.Conflict:
                    return Failed (ApiStatusCode.Conflict, EnumExtensions.GetDisplayName (ApiStatusCode.Conflict));
                default:
                    return Failed (ApiStatusCode.ServerError, EnumExtensions.GetDisplayName (ApiStatusCode.ServerError));
            }
        }

        public static ApiResult Failed (params ApiMessage[] errors) {
            var result = new ApiResult { IsSuccess = false };
            if (errors != null) {
                result.Errors = new List<ApiMessage> ();
                result.Errors.AddRange (errors);
            }
            return result;
        }

        public static ApiResult Succeeded (object data = null) =>
            new ApiResult {
                IsSuccess = true,
                Data = data,
                Result = new ApiMessage { Key = (int) ApiStatusCode.Success, Value = EnumExtensions.GetDisplayName (ApiStatusCode.Success) }
            };

        public static ApiResult Failed (object key, string message) =>
            Failed (new ApiMessage { Key = key, Value = message });
    }

    public class ApiMessage {
        public ApiMessage () { }
        public object Key { get; set; }
        public string Value { get; set; }
    }
}