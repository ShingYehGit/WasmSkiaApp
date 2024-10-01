using System;
using Newtonsoft.Json;

namespace SqlData
{

    public abstract class Cosmos<T> where T : Cosmos<T>
    {
        //Here are some quick rules when naming a database:
        // Keep database names between 3 and 63 characters long
        //Database names can only contain lowercase letters, numbers, or the dash(-) character.
        //Database names must start with a lowercase letter or number.
        [JsonIgnore]
        public static string DatabaseId => "wenwang0db";

        [JsonIgnore]
        public static string PartitionKeyPath { get; set; } = "/GeoLocation/CountryKey";

        [JsonIgnore]
        public static string CollectionId => typeof(T).Name;//Container Name;

        [JsonIgnore]
        public string TypeName => typeof(T).Name;

        //Cosmos DB complusory: should have a field names “id”
        //Primary key in Tdata's Container/Table
        public string id { get; set; } = string.Empty;//Guid.NewGuid().ToString();

        public GLocation GeoLocation { get; set; } = new GLocation();

    }

}
