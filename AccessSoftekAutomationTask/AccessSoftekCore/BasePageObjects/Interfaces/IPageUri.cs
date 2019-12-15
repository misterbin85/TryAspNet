using System;

namespace AccessSoftekCore.BasePageObjects.Interfaces
{
    public interface IPageUri
    {
        Uri PageUri { get; }

        string GetCurrentUrl();
    }
}