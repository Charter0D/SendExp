using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SendExp
{
    public class CommandEx : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "ex";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length != 2)
            {
                UnturnedChat.Say(caller, Plugin.Instance.Translate("invalid_args"));
            }
            else
            {
                UnturnedPlayer p = (UnturnedPlayer)caller;
                UnturnedPlayer second = UnturnedPlayer.FromName(command[0]);
                if (second == null)
                {
                    UnturnedChat.Say(caller, Plugin.Instance.Translate("not_found"));
                }
                else
                {
                    if (uint.TryParse(command[1], out var count))
                    {
                        if (p.Experience >= count)
                        {
                            p.Experience -= count;
                            second.Experience += count;
                            UnturnedChat.Say(p, Plugin.Instance.Translate("success_0", count, second.CharacterName ));
                            UnturnedChat.Say(second, Plugin.Instance.Translate("success_1", p.CharacterName, count ));
                        }
                        else
                        {
                            UnturnedChat.Say(caller, Plugin.Instance.Translate("no_money"));
                        }
                    }
                    else
                    {
                        UnturnedChat.Say(caller, Plugin.Instance.Translate("invalid_args"));
                    }
                }
            }
        }
    }
}
