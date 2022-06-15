using Exiled.Events.EventArgs;

namespace PlayerInfo
{
    class EventHandlers
    {
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (Plugin.Singleton.Config.PlayerInfo.TryGetValue(ev.NewRole, out string customInfo))
            {
                ev.Player.InfoArea &= ~PlayerInfoArea.Nickname;
                ev.Player.InfoArea &= ~PlayerInfoArea.Role;
                ev.Player.InfoArea &= ~PlayerInfoArea.PowerStatus;
                ev.Player.InfoArea &= ~PlayerInfoArea.UnitName;
                ev.Player.CustomInfo = customInfo
                    .Replace("{nick}", ev.Player.DisplayNickname ?? ev.Player.Nickname)
                    .Replace("{unit}", ev.Player.UnitName);
            }
            else
            {
                ev.Player.InfoArea |= ~PlayerInfoArea.Nickname;
                ev.Player.InfoArea |= ~PlayerInfoArea.Role;
                ev.Player.InfoArea |= ~PlayerInfoArea.PowerStatus;
                ev.Player.InfoArea |= ~PlayerInfoArea.UnitName;
                ev.Player.CustomInfo = string.Empty;
            }
        }
    }
}