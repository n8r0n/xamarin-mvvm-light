using System;

namespace XamarinMvvmLightTest.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("MVVM Light Sample App!");
            callback(item, null);
        }
    }
}