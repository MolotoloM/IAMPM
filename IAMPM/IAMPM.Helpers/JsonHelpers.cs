using System;
using Newtonsoft.Json;

namespace IAMPM.Helpers
{
    public static class JsonHelpers
    {
        //возможность добавления extension метода в любой клас, который наследуется от object 
        public static string Serialize(this object source)
        {
            return JsonConvert.SerializeObject(source);
        }

        public static T Deserialize<T>(this string source) where T: class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(source);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}