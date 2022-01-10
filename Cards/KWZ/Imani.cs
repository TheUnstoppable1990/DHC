using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using DHC.Utilities;
using DHC.MonoBehaviours;

namespace DHC.Cards.KWZ
{
    class Imani : CustomCard
    {
        public Imani_Effect imani_Effect;
        internal static CardInfo self = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            //base.SetupCard(cardInfo, gun, cardStats, statModifiers);
            
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //characterStats.regen += 0.05f * data.maxHealth;
            this.imani_Effect = player.gameObject.AddComponent<Imani_Effect>();
        }
        public override void OnRemoveCard()
        {
            Destroy(imani_Effect);
        }
        protected override string GetTitle()
        {
            return "Imani\n(Faith)";
        }
        protected override string GetDescription()
        {
            return "";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                CardTools.FormatStat(true,"Regeneration",0.05f)
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.PoisonGreen;
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
