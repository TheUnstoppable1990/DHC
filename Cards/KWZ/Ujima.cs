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
    class Ujima : CustomCard
    {
        internal static CardInfo self = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
                      
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            int numberOfPlayers = PlayerManager.instance.players.Count();
            characterStats.attackSpeedMultiplier = 1f + (0.1f * numberOfPlayers);
        }
        public override void OnRemoveCard()
        {
            //base.OnRemoveCard();
        }
        protected override string GetTitle()
        {
            return "Ujima\n(Collective Work and Responsibility)";
        }
        protected override string GetDescription()
        {
            return "Gain attack speed for each player";
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
                CardTools.FormatStat(true,"Attack Speed","10% per player")
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
