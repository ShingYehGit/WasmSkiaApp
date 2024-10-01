using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace SqlData
{

    public class GLocation//public class Location
    {

        //Cosmos DataBase all global 13 regions and all Countries in each Regions
        [JsonIgnore]
        public static readonly string[] Regions = new string[14]
        {
                "North America", //0
                "Middle America",//1
                "South America", //2

                "Asia",                 //3 

                "East South Asia",//4
                "Middle Asia",       //5
                "Middle East",       //6

                "North Europe",     //7
                "East Europe",       //8
                "MIddle Europe",    //9
                "West Europe",       //10

                "North Africa",       //11 
                "Middle Africa",     //12
                "South Africa"       //13
        };

        [JsonIgnore]
        public static readonly string[][] CountryKeys = new string[14][]
        {
          new string[] { "Canada", "America" },
          //                                        there are 10 countries in MidAmerica
          new string[] { "Mexico", "MidAmerica10" },
          //                                        there are 6 countries in SouthAmerica, 5 countries in SouthAmerica
          new string[] { "Brazil",  "Argentina", "SouthAmerica6", "SouthAmerica5" },

          new string[] {  "Korea", "Janpan", "Mongolia", "China", "Taiwan", "Hong Kong" },

          new string[] {  "ESAsia5", "ESAsia6", "ESAsia2" },

          new string[] { "Russia", "MidAsia7", "MidAsia5", "MidAsia2" },

          new string[] { "MidEast5", "MidEast6", "MidEast7" },

          new string[] { "North Europe" },
          new string[] { "East Europe" },
          new string[] { "Middle Europe" },
          new string[] { "West Europe" },

          new string[] { "North Africa" },
          new string[] { "Middle Africa" },
          new string[] { "South Africa" }
        };

        [JsonIgnore]
        public static readonly string[][] Countrys = new string[14][]
                {
                   //0 "North America"
                   new string[] { "Canada", "America" },
                   //1 "Middle America"
                   new string[] { "Mexico",
                                         "Guatemala", "Belize", "Honduras", "El Salvador", "Nicaragua",
                                         "Costa Rica", "Panama", "Cuba", "Puerto Rico", "Dominican" },
                   //2 "South America"
                   new string[] { "Brazil",
                                         "Argentina",
                                         "Colombia", "Venezuela", "Ecuado", "Guyana", "Suriname", "French Guiana",
                                         "Bolivia", "Paraguay", "Uruguay", "Peru", "Chile" },
                   //3 "Asia"
                   new string[] { "North Korea", "South Korea", "Janpan", "Mongolia", "China", "Taiwan", "Hong Kong" },
                   //4 "East South Asia",
                   new string[] { "Myanmar", "Laos", "Thailand", "Cambodia", "Vietnam",
                                         "Philippines", "Brunei", "Indonesia", "Papua New Guinea", "Malaysia", "Singapore",
                                         "Australia", "New Zealand" },
                   //5 "Middle Asia",
                   new string[] { "Russia",
                                         "Kazakhstan", "Uzbekistan", "Turkmenistan", "Tajik", "Tashkent", "Tajikistan", "Kyrgyzstan",
                                         "Afghanistan", "Pakistan", "Bangladesh", "Bhutan", "Nepal",
                                         "India", "Sri Lanka" },                   
                   //6 "Middle East",
                   new string[] { "Georgia", "Armenia", "Azerbaijan", "Turkey",  "Cyprus",
                                         "Iraq", "Iran", "Syria", "Lebanon", "Israel", "Jordan",
                                         "Kuwait", "Saudi Arabia", "Bahrain", "Qatar", "United Arab Emirates", "Oman", "Yemen"},
                   //7 "North Europe"
                   new string[] { "Iceland", "Norway", "Finland", "Sweden" },
                   //8 East Europe
                   new string[] {  "Estonia", "Latvia", "Lithuania", "Belarus", "Ukraine", "Moldova", "Romania", "Bulgaria",
                                          "Serbia", "Montenegro", "Kosovo", "North Macedonia",
                                          "Albania", "Bosnia",  "Greece" },
                   //9 Middle Europe
                   new string[] { "Denmark", "Germany", "Poland", "Czechia", "Austria", "Slovakia",
                                         "Slovenia", "Hungary", "Switzerland",
                                         "Croatia",  "Italy" },
                   //10 West Europe
                   new string[] { "Netherlands", "Belgium", "Luxembourg", "France",  "Monaco", "Spain", "Barcelona", "Portugal",
                                         "United Kingdom", "Ireland" },
                   //11 "North Africa"
                  new string[] { "Morocco", "Tunisia", "Algeria", "Libya", "Egypt", "Western Sahara", "Mauritania", "Mali", "Niger", "Chad",
                                          "Sudan", "Ethiopia", "Djibouti" },
                  //12 "Middle Africa"
                  new string[] { "Senegal", "Gambia", "Burkina Faso", "Guinea-Bissau", "Guinea", "Sierra Leone", "Liberia", "Cote dIvoire", "Ghana",
                                        "Benin", "Cameroon", "Central African", "South Sudan", "Somalia" },
                  //13 "South Africa"
                  new string[] { "Equatorial Guinea", "Gabon", "Congo", "Uganda", "Kenya", "Tanzania", "Angola",
                                        "Guinea", "Congo", "Gabon", "Mozambique", "Botswana", "Zambia", "Malawi",
                                        "Namibia", "Botswana", "South Africa", "Madagascar" }

                };

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? City { get; set; } = null;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? State { get; set; } = null;

        public string Country { get; set; } = string.Empty;
        public string CountryKey { get; set; } = string.Empty;//Gosmos DB Partition Key
        public string Region { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;

        public static string GetCountryKey( int RegionIdx, string Country )
        {
            switch ( RegionIdx )
            {
                case 0:
                    return Country == "Canada" ? "Canada" : "America";
                case 1:
                    return Country == "Mexico" ? "Mexico" : "MidAmerica10";
                case 2:
                    return SouthAmerica(Country);
                case 3:
                    return (Country == "North Korea" || Country == "South Korea") ? "Korea" : Country;
                case 4:
                    return EastSouthAsiaKey(Country);
                case 5:
                    return MiddleAsiaKey(Country);
                case 6:
                    return MiddleEastKey(Country);
                case 7:
                    return "NorthEurope";
                case 8:
                    return "EastEurope";
                case 9:
                    return "MiddleEurope";
                case 10:
                    return "WestEurope";

                case 11:
                    return "NorthAfrica";
                case 12:
                    return "MiddleAfrica";
                case 13:
                    return "SouthAfrica";
                default:
                    return string.Empty;
            }
        }

        public void Copy( GLocation GeoLocation )
        {
           City = GeoLocation.City;
           State = GeoLocation.State;
           Country = GeoLocation.Country;
           CountryKey = GeoLocation.CountryKey;
           Region = GeoLocation.Region;
           PostCode = GeoLocation.PostCode;
        }

        static string SouthAmerica(string Country)
        {
            if (Country == "Brazil")
                return "Brazil";
            else if (Country == "Argentina")
                return "Argentina";
            else if (Country == "Colombia" || Country == "Venezuela" ||
                         Country == "Ecuado" || Country == "Guyana" || Country == "Suriname" || Country == "French Guiana")
                return "SouthAmerica6";
            else
                return "SouthAmerica5";
        }

        static string EastSouthAsiaKey( string Country )
        {
            if (Country == "Australia" || Country == "New Zealand")
                return "ESAsia2";
            else if (Country == "Myanmar" || Country == "Laos" ||
                        Country == "Thailand" || Country == "Cambodia" || Country == "Vietnam")
                return "ESAsia5";
            else
                return "ESAsia6"; 
        }

        static string MiddleAsiaKey( string Country )
        {
            if (Country == "Russia")
                return "Russia";
            else if (Country == "India" || Country == "Sri Lanka")
                return "MidAsia2";
            else if (Country == "Afghanistan" || Country == "Pakistan" ||
                        Country == "Bangladesh" || Country == "Bhutan" || Country == "Nepal")
                return "MidAsia5";
            else//"Kazakhstan", "Uzbekistan", "Turkmenistan", "Tajik", "Tashkent", "Tajikistan", "Kyrgyzstan",
                return "MidAsia7";
        }

        static string MiddleEastKey(string Country)
        {
            if (Country == "Georgia" ||
                Country == "Armenia" || Country == "Azerbaijan" || Country == "Turkey" || Country == "Cyprus")
                return "MidEast5";
            else if (Country == "Iraq" || Country == "Iran" ||
                        Country == "Syria" || Country == "Lebanon" || Country == "Israel" || Country == "Jordan")
                return "MidEast6";
            else//"Kuwait", "Saudi Arabia", "Bahrain", "Qatar", "United Arab Emirates", "Oman", "Yemen"
                return "MidEast7";
        }

        public static void CheckCityStateVisible_ByCityCountry(string CityLikeCountry, ref bool BvisibleCity, ref bool BvisibleState)
        {
            BvisibleCity = BvisibleState = true;
            if ( CityLikeCountry == "Hong Kong" ||
                  CityLikeCountry == "Singapore" || CityLikeCountry == "Barcelona")//City like a country
                BvisibleCity = BvisibleState = false;
            else
            {
                if (CityLikeCountry == "Taiwan")
                    BvisibleState = false;
            }
        }

    }

}
