using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.Business.Enumerators
{
    public enum EnumReturnCode
    {
        [Description("S")]
        SUCCESS = 'S',
        [Description("E")]
        ERROR = 'E',
        [Description("W")]
        WARNING = 'W',
    }
}
