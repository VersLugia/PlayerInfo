using System;
using Exiled.API.Features;

namespace PlayerInfo
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "PlayerInfo";
        public override string Author => "VersLugia";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);
        public static Plugin Singleton { get; private set; }
        private EventHandlers Events { get; set; }

        public override void OnEnabled()
        {
            Singleton = this;
            Events = new EventHandlers();
            Exiled.Events.Handlers.Player.ChangingRole += Events.OnChangingRole;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= Events.OnChangingRole;
            Singleton = null;
            Events = null;
            base.OnDisabled();
        }
    }
}