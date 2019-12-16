using System;
using AccessSoftekCore.Configs.Interfaces;

namespace AccessSoftekCore.Configs.AppConfigs
{
    public class TestAppConfig : BaseConfig
    {
        public new static IApplication Application => Config.Properties.MainApplication;

        public new static Uri BaseUri => BaseUriFor(Application);

        public static Uri MainPageUri => UriFor(Application, "index");
    }
}