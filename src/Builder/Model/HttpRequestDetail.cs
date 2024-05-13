﻿using System.Net.Http.Headers;

namespace HttpRequestBuilder.Model
{
    /// <summary>
    /// Stores the data required to create the Http Client.
    /// </summary>
    internal class HttpRequestDetail
    {
        public UriBuilder Uri { get; set; } = new UriBuilder();
        public HttpMethod Method { get; set; } = HttpMethod.Get;
        public AuthenticationHeaderValue? Authentication { get; set; }
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public HttpContent? Content { get; set; }

        #region Ctor

        public HttpRequestDetail(string url)
        {
            Uri = new UriBuilder(url);
        }

        #endregion
    }
}