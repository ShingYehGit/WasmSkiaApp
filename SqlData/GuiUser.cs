using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

//using Hex64Gua;

namespace SqlData
{

    public enum Gender : uint
    {
        None = 0, Female = 0x01, Male = 0x02
    }

    public class GuiUser
    {

        public static readonly string[,] Linguals = new string[,]
                                                    { { "English", "en" },
                                                      { "Traditional Chinese", "zh-Hant" },
                                                      { "Simple Chinese", "zh-Hans" } };
        /*
                                                  { "", "cs" },
                                                  { "", "de" },
                                                  { "", "es" },
                                                  { "French", "fr" },
                                                  { "", "hu" },
                                                  { "Italy", "it" },
                                                  { "Japan", "ja" },
                                                  { "Korea", "ko" },
                                                  { "", "no" },
                                                  { "", "pl" },
                                                  { "", "pt" } };
        */
        public AppUser appUser = new AppUser();
        public Gender Sex { get; set; }
        public CultureInfo? Culture { get; set; }//Lingual / "en", "zh-Hant", "zh-Hans", "ja", "ko"
        public UserDoingState UserState { get; set; }// Old ActionState

        public GuiUser()
        {
            UserState = UserDoingState.NoAction;
            Culture = null;
        }

        public void SetUserAction(UserDoingState State)
        {
            UserState = State;
        }

        public string RecordToString()
        {
            String TextForFile = string.Empty;

            TextForFile += appUser.id + ',';

            TextForFile += ((appUser.GeoLocation.City != null) ? appUser.GeoLocation.City : "null") + ',';
            TextForFile += ((appUser.GeoLocation.State != null) ? appUser.GeoLocation.State : "null") + ',';
            TextForFile += appUser.GeoLocation.Country + ',';
            TextForFile += appUser.GeoLocation.CountryKey + ',';
            TextForFile += appUser.GeoLocation.PostCode + ',';
            TextForFile += appUser.GeoLocation.Region + ',';

            TextForFile += ((appUser.SolverId != null) ? appUser.SolverId : "null") + ',';

            TextForFile += appUser.CoinTypeIdx.ToString() + ',';
            TextForFile += appUser.Email + ',';
            TextForFile += appUser.Password + ',';
            TextForFile += appUser.PhoneNumber + ',';

            TextForFile += appUser.Gender + ',';//"Male/Female"
            TextForFile += appUser.UserName + ',';
            TextForFile += appUser.BirthDate.ToString() + ',';
            TextForFile += appUser.StartDate.ToString() + ',';
            TextForFile += appUser.Language;

            return TextForFile;
        }

        public void StringToRecord(string TextFromFile)
        {
            bool B_Exit;
            int BgnAtIdx, EndAtIdx, subLength, DataIdx;
            string SubString, DateSz, GenderSz;

            DateSz = GenderSz = string.Empty;
            B_Exit = false; BgnAtIdx = DataIdx = 0;
            do{
                if ((EndAtIdx = TextFromFile.IndexOf(',', BgnAtIdx)) != -1)
                    subLength = EndAtIdx - BgnAtIdx;
                else
                {
                    subLength = TextFromFile.Length - BgnAtIdx;
                    B_Exit = true;
                }

                SubString = TextFromFile.Substring(BgnAtIdx, subLength);
                if (DataIdx == 0)
                    appUser.id = SubString;

                else if (DataIdx == 1)
                    appUser.GeoLocation.City = (SubString != "null") ? SubString : null;
                else if (DataIdx == 2)
                    appUser.GeoLocation.State = (SubString != "null") ? SubString : null;
                else if (DataIdx == 3)
                    appUser.GeoLocation.Country = SubString;
                else if (DataIdx == 4)
                    appUser.GeoLocation.CountryKey = SubString;
                else if (DataIdx == 5)
                    appUser.GeoLocation.PostCode = SubString;
                else if (DataIdx == 6)
                    appUser.GeoLocation.Region = SubString;

                else if (DataIdx == 7)
                    appUser.SolverId = (SubString != "null") ? SubString : null;

                else if (DataIdx == 8)
                    appUser.CoinTypeIdx = int.Parse( SubString );
                else if (DataIdx == 9)
                    appUser.Email = SubString;
                else if (DataIdx == 10)
                    appUser.Password = SubString;
                else if (DataIdx == 11)
                    appUser.PhoneNumber = SubString;

                else if (DataIdx == 12)
                {
                    appUser.Gender = SubString;
                    Sex = SubString == "Male" ? Gender.Male : Gender.Female;
                }
                else if (DataIdx == 13)
                    appUser.UserName = SubString;
                else if (DataIdx == 14)
                    appUser.BirthDate = DateTime.Parse(SubString);
                else if (DataIdx == 15)
                    appUser.StartDate = DateTime.Parse(SubString);
                else if (DataIdx == 16)
                {
                    appUser.Language = SubString;
                    Culture = new CultureInfo(GetLanguageCulture(SubString));//"en", "zh-Hant", "zh-Hans", "ja", "ko"
                }

                BgnAtIdx = EndAtIdx + 1; DataIdx++;
            } while (!B_Exit);

        }

        public string GetLanguageCulture(string LanguageString)
        {
            string Lingual = "en";
            for (int n = 0; n < Linguals.Length; n++)
            {
                if (Linguals[n, 0] == LanguageString)
                {
                    Lingual = Linguals[n, 1];
                    Culture = new CultureInfo( Lingual );
                }
            }
            return Lingual;
        }

    }

}
