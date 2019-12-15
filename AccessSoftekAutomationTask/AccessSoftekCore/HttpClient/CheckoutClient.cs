using System;
using System.Net;
using AccessSoftekCore.Configs.AppConfigs;
using AccessSoftekCore.HttpClient.Models;
using AccessSoftekPages.Models;
using Newtonsoft.Json;
using RestSharp;

namespace AccessSoftekCore.HttpClient
{
    public class CheckoutClient : BaseHttpClient
    {
        protected override Uri BaseUri { get; set; } = ApiConfig.BaseUri;

        #region Methods

        public CouponValueResponse GetCouponDiscount(string coupon)
        {
            var request = CreateBasePost($"{ApiConfig.CouponUri}?coupon={coupon}");

            var resp = ExecuteRequest<CouponValueResponse>(request);

            return resp;
        }

        public CheckoutResponse Checkout(CheckoutModel model)
        {
            var request = CreateBasePost($"{ApiConfig.CheckoutUri}");

            request.AddParameter("Body", JsonConvert.SerializeObject(model), "application/json", ParameterType.RequestBody);

            var resp = Client.Execute(request);

            if (resp.StatusCode.Equals(HttpStatusCode.OK) && !string.IsNullOrWhiteSpace(resp.Content))
            {
                return JsonConvert.DeserializeObject<CheckoutResponse>(resp.Content);
            }

            return default;
        }

        #endregion Methods
    }
}