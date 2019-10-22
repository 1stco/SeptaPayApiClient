namespace SeptaPay.Api.Client.Net4.Infrastructure
{
    public interface IHttpRestClient<T, TResult> where T : class
    {
        TResult PostJson(T request);
        TResult Post();
    }
}
