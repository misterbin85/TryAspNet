using System;
using AccessSoftekCore.BasePageObjects;
using AccessSoftekCore.Configs.AppConfigs;
using OpenQA.Selenium;

namespace AccessSoftekPages.Pages
{
    public class CheckoutFormPage : BasePage
    {
        public override By ContainerBy => By.CssSelector("");
        public override Uri PageUri => TestAppConfig.MainPageUri;
    }
}