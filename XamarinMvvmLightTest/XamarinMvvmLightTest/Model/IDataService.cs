using System;

namespace XamarinMvvmLightTest.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}