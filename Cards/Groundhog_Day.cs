using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using DHC.Utilities;
using ModdingUtils.Extensions;
using DHC.Effects;

namespace DHC.Cards
{
    class Groundhog_Day : CustomCard
    {
        private int extra_lives = 4;
        private float health_reduction = 0.5f;
        private float movement_reduction = 0.5f;
        private float jump_reduction = 0.25f;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            cardInfo.allowMultiple = false;
            statModifiers.health = 1f - health_reduction;
            statModifiers.movementSpeed = 1f - movement_reduction;
            statModifiers.jump = 1f - jump_reduction;

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            characterStats.respawns += extra_lives;
        }
        public override void OnRemoveCard()
        {
            
        }
        protected override string GetTitle()
        {
            return "Groundhog Day";
        }
        protected override string GetDescription()
        {
            return "\"Okay campers, rise, and shine, and don\'t forget your booties \'cause it\'s cold out there… it\'s cold out there every day.\"";
        }
        protected override GameObject GetCardArt()
        {
            return DHC.ArtAssets.LoadAsset<GameObject>("C_Groundhog_Day");
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                 CardTools.FormatStat(true,"Extra Lives",extra_lives),
                 CardTools.FormatStat(false,"Health",-health_reduction),
                 CardTools.FormatStat(false,"Movement Speed",movement_reduction),
                 CardTools.FormatStat(false,"Jump Heigh",jump_reduction)
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.FirepowerYellow;
        }        
        public override string GetModName()
        {
            return "DHC";
        }
    }
}
