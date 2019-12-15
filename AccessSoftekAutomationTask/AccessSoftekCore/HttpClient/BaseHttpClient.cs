using System;
using System.Net;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Serializers.Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using RestRequest = RestSharp.RestRequest;

namespace AccessSoftekCore.HttpClient
{
    public abstract class BaseHttpClient
    {
        public IRestClient Client { get; set; }
        protected abstract Uri BaseUri { get; set; }

        private readonly ISerializer serializer;

        protected BaseHttpClient()
        {
            Console.WriteLine("Initializing base HttpClient");

            this.Client = new RestClient
            {
                CookieContainer = new CookieContainer(),
                BaseUrl = this.BaseUri,
                FollowRedirects = true,
            };

            this.serializer = new NewtonsoftJsonSerializer(JsonSerializer.CreateDefault());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            Console.WriteLine("Base HttpClient initialization complete");
        }

        public IRestRequest CreateBaseGet(string url) => new RestRequest
        {
            Resource = url,
            Method = Method.GET,
            JsonSerializer = serializer
        };

        public IRestRequest CreateBasePost(string resource, bool addSessionId = true)
        {
            IRestRequest request = new RestRequest
            {
                Method = Method.POST,
                //JsonSerializer = serializer,
                Resource = resource
            };

            request.AddHeader("Content-Type", "application/json");

            return request;
        }

        protected T ExecuteRequest<T>(IRestRequest request) where T : new()
        {
            Console.WriteLine($"Executing request for obtain: '{typeof(T).Name}'");

            IRestResponse<T> resp = this.Client.Execute<T>(request);

            return resp.StatusCode.Equals(HttpStatusCode.OK) ? resp.Data : default;
        }
    }
}