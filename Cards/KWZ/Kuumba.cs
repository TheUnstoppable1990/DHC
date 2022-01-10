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
    class Kuumba : CustomCard
    {
        internal static CardInfo self = null;
        private Kuumba_Effect kuumba_Effect;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            //base.SetupCard(cardInfo, gun, cardStats, statModifiers);           
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            this.kuumba_Effect = player.gameObject.AddComponent<Kuumba_Effect>();
        }
        public override void OnRemoveCard()
        {
            Destroy(this.kuumba_Effect);
        }
        protected override string GetTitle()
        {
            return "Kuumba\n(Creativity)";
        }
        protected override string GetDescription()
        {
            return "Your bullets are all colorful now.";
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
