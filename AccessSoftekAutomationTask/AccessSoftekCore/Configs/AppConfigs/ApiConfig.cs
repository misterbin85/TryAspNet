using System;
using AccessSoftekCore.Configs.Interfaces;

namespace AccessSoftekCore.Configs.AppConfigs
{
    public class ApiConfig : BaseConfig
    {
        public new static IApplication Application => Config.Properties.MainApplication;

        public new static Uri BaseUri => BaseUriFor(Application);

        public static Uri CouponUri => UriFor(Application, "coupon");
    }
}