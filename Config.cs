using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace PlayerInfo
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        
        [Description("Tags: {nick} | {unit}")]
        public Dictionary<RoleType, string> PlayerInfo { get; set; } = new Dictionary<RoleType, string>
        {
            [RoleType.ClassD] = "<color=#EE7600>{nick}\nDboiii</color>",
            [RoleType.Scp049] = "<color=#228B22>{nick}\nDoctor</color>",
            [RoleType.Scp173] = "<color=#960018>{nick}\nMatthew</color>",
            [RoleType.NtfCaptain] = "<color=#00FFFF>{nick}\nCaptain {unit}</color>"
        };
    }
}