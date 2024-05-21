﻿using Newtonsoft.Json;
using System.Net;

namespace Http.Request.Builder.Response
{
    public class BaseHttpResponse
    {
        public HttpStatusCode StatusCode { get; }

        #region Ctor

        public BaseHttpResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        #endregion

    }

    public class HttpResponse : BaseHttpResponse, IHttpResponse
    {
        public string Content { get; }

        #region Ctor

        public HttpResponse(HttpStatusCode statusCode, string content)
            : base(statusCode)
        {
            Content = content;
        }

        #endregion

    }

    public class HttpResponse<TSuccessContent> : BaseHttpResponse, IHttpResponse<TSuccessContent> where TSuccessContent : class
    {
        public TSuccessContent Content { get; private set; } = default;

        #region Ctor

        public HttpResponse(HttpStatusCode statusCode, TSuccessContent content)
            : base(statusCode)
        {
            Content = content;
        }

        public HttpResponse(HttpStatusCode statusCode, string content)
            : base(statusCode)
        {
            Content = DeserializeToTSuccess(content);
        }

        #endregion

        #region Methods

        private TSuccessContent DeserializeToTSuccess(string content)
        {
            return JsonConvert.DeserializeObject<TSuccessContent>(content);
        }

        #endregion

        #region Implicit

        public static implicit operator HttpResponse(HttpResponse<TSuccessContent> response)
            => new HttpResponse(response.StatusCode, JsonConvert.SerializeObject(response.Content));

        public static implicit operator HttpResponse<TSuccessContent>(HttpResponse response)
            => new HttpResponse<TSuccessContent>(response.StatusCode, response.Content);

        #endregion

    }
}
