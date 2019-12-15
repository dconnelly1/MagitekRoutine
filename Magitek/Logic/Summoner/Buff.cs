﻿using System;
using System.Threading.Tasks;
using ff14bot;
using ff14bot.Managers;
using Magitek.Extensions;
using Magitek.Models.Summoner;
using Magitek.Utilities;
using Magitek.Utilities.Routines;

namespace Magitek.Logic.Summoner
{
    internal static class Buff
    {
        public static async Task<bool> DreadwyrmTrance()
        {
            if (Core.Me.ClassLevel < 58) return false;

            if (ActionResourceManager.Arcanist.AetherAttunement == 2) return false;

            if ((int)PetManager.ActivePetType == 10) return false;
            if (Spells.Ruin.Cooldown.TotalMilliseconds < 850)
                return false;

            if (Spells.TriDisaster.Cooldown.TotalMilliseconds < 2000) return false;

            if (Casting.LastSpell != Spells.Bio || Casting.LastSpell != Spells.Ruin2 || Casting.LastSpell != Spells.EgiAssault || Casting.LastSpell != Spells.EgiAssault2)
                if (!ActionResourceManager.Summoner.DreadwyrmTrance)
                    if (await Spells.SmnRuin2.Cast(Core.Me.CurrentTarget))
                        return true;
            return await Spells.Trance.Cast(Core.Me);
        }

        public static async Task<bool> LucidDreaming()
        {
            if (Core.Me.ClassLevel < 24) return false;

            if (Core.Me.CurrentManaPercent > SummonerSettings.Instance.LucidDreamingManaPercent) return false;

            if (!ActionResourceManager.Summoner.DreadwyrmTrance)
                return false;

            return await Spells.LucidDreaming.Cast(Core.Me);
        }

        public static async Task<bool> Aetherpact()
        {
            if (Core.Me.ClassLevel < 64) return false;
            if (Casting.LastSpell != Spells.Bio || Casting.LastSpell != Spells.Ruin2 || Casting.LastSpell != Spells.EgiAssault || Casting.LastSpell != Spells.EgiAssault2)
                if (!ActionResourceManager.Summoner.DreadwyrmTrance)
                    if (await Spells.SmnRuin2.Cast(Core.Me.CurrentTarget))
                        return true;
            return await Spells.Aetherpact.Cast(Core.Me);
        }
    }
}