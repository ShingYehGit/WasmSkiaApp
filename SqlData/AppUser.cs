using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SqlData
{

    public enum UserPrivilege : uint
    {
        Empty_Key = (uint)0,
        Read_Gua = (uint)(1 << 1),
        Browser_Gua = (uint)(1 << 2),
        Edit_Gua = (uint)(1 << 3),
        Manage_Solver = ((uint)1 << 4),
        Manage_Money = ((uint)1 << 5)
    }

    public class AppUser : Cosmos<AppUser>
    {

        //[ForeignKey(nameof(Solver))]//this User is a Customer belong to a Solver with SolverId in Solver Table/Container
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? SolverId { get; set; } = null;//primary Key in Solver Container/Table; null for There is no solver for this AppUser

        public int CoinTypeIdx { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public string Language { get; set; } = string.Empty;//English / Traditional Chinese / Simplifed Chinese

        public decimal AnualTotal { get; set; } = 0.0M;//
        public decimal EarnBonus { get; set; } = 0.0M;//free charge quantity

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ICollection<DqSolve>? DqSolves { get; set; } = null;

        public void SetDataBaseData(AppUser DbUserData )
        {
            AnualTotal = DbUserData.AnualTotal;
            EarnBonus = DbUserData.EarnBonus;  
        }

        public void Copy( AppUser RegisterUser )
        {
            id = RegisterUser.id;

            GeoLocation.Copy( RegisterUser.GeoLocation );

            SolverId = RegisterUser.SolverId;
            CoinTypeIdx = RegisterUser.CoinTypeIdx;

            Email = RegisterUser.Email;
            Password = RegisterUser.Password;
            PhoneNumber = RegisterUser.PhoneNumber;

            Gender = RegisterUser.Gender;
            UserName = RegisterUser.UserName;
            BirthDate = RegisterUser.BirthDate;
            StartDate = RegisterUser.StartDate;
            Language = RegisterUser.Language;

            AnualTotal = RegisterUser.AnualTotal;
            EarnBonus = RegisterUser.EarnBonus;  

        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static AppUser ToAppUser( string JsonString )
        {
            //Convert the JSON data/Jason format into an AppUser object and return the User
            //AppUser User = (AppUser)JsonConvert.DeserializeObject( JsonString );
            var User = JsonConvert.DeserializeObject<AppUser>( JsonString );
            return User;
        }

    }

}
