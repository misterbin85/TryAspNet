using System;
using AccessSoftekCore.Configs.AppConfigs;
using AccessSoftekCore.HttpClient.Models;

namespace AccessSoftekCore.HttpClient
{
    public class CheckoutClient : BaseHttpClient
    {
        protected override Uri BaseUri { get; set; } = new Uri("https://community.dynamics.com/"); //ApiConfig.BaseUri;

        public CouponValueResponse GetCouponDiscount(string coupon)
        {
            var request = CreateBasePost($"{ApiConfig.CouponUri}?coupon={coupon}");

            var resp = ExecuteRequest<CouponValueResponse>(request);

            return resp;
        }
    }
}