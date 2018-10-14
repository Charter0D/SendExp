using Rocket.API.Collections;
using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SendExp
{
    public class Plugin : RocketPlugin
    {
        public static Plugin Instance;
        protected override void Load()
        {
            Instance = this;
        }

        protected override void Unload()
        {
            base.Unload();
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {
            { "invalid_args", "Invalid args." },
            { "success_0", "Вы отправили {0} опыта игроку {1}" },
            { "success_1", "Игрок {0} вам отправил {1} опыта" },
            { "not_found", "Игрок не найден" },
            { "no_money", "У вас недостаточно опыта" }
        };
    }
}
