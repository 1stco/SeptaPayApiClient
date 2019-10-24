using System;

namespace SeptaPay.Api.Client.Net45.Infrastructure {
    public interface IHttpRestClient<T, TResult> : IDisposable where T : class {
        TResult PostJson(T request);
        TResult Post();
    }
}
