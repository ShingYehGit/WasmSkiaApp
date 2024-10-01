using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlData
{
    public enum UserDoingState : uint
    {
        NoAction = 0,
        ToAccessAzure = 1,
        CastGuaPlaying = 2,
        ReadPlayingGua = 3,

        SelectQueryType = 4,
        EditingQuery = 5,
        SelectEqQuery = 6,
        EditingGua = 7,
        CastingGua = 8,

        EditingEqGua = 9,
        CastingEqGua = 10,
        ToSolveEqGua = 11,//ToSolveEqGua
        DisplaySolveEqGua = 12,//ReadSolveEqGua = 12,

        ReadSQLiteGuas = 13,
        SelectSQLiteGua = 14,
        DisplaySQLiteGua = 15
    }

}
