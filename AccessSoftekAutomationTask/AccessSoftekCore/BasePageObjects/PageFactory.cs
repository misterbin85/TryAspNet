using System;

namespace AccessSoftekCore.BasePageObjects
{
    public class PageFactory
    {
        public static T OpenPage<T>() where T : BasePage, new()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}