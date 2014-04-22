﻿using Com.Ericmas001.Game.Poker.DataTypes.Enums;
using Com.Ericmas001.Util.Options;

namespace Com.Ericmas001.Game.Poker.DataTypes.Parameters
{
    public abstract class BlindOptions : IOption<BlindTypeEnum>
    {
        public int MoneyUnit { get; set; }
        public abstract BlindTypeEnum OptionType { get; }

        public BlindOptions(int moneyUnit)
        {
            MoneyUnit = moneyUnit;
        }
        public BlindOptions()
        {
        }

        
    }
}
