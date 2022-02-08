using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using DHC.Utilities;

namespace DHC.Cards.KWZ
{
    class Kujichagulia : CustomCard
    {
        internal static CardInfo self = null;
        private float health_boost = 1.25f;

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            statModifiers.health = health_boost;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            
        }
        public override void OnRemoveCard()
        {
            //base.OnRemoveCard();
        }
        protected override string GetTitle()
        {
            return "Kujichagulia\n(Self-Determination)";
        }
        protected override string GetDescription()
        {
            return "Build yourself up";
        }
        protected override GameObject GetCardArt()
        {
            return DHC.ArtAssets.LoadAsset<GameObject>("C_Red_Candle");
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                CardTools.FormatStat(true,"Health",health_boost)
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DestructiveRed;
        }
        public override bool GetEnabled()
        {
            return false;
        }
        public override string GetModName()
        {
            return "DHC";
        }
    }
}
