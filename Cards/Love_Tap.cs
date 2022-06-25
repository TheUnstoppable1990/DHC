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
    class Love_Tap : CustomCard
    {
        private float damage_reduction = 0.5f;
        public Love_Tap_Effect effect = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            cardInfo.allowMultiple = false;            
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.bulletDamageMultiplier = (1 - damage_reduction);
            gun.projectileColor = Color.magenta;
            effect = player.gameObject.GetOrAddComponent<Love_Tap_Effect>();

        }
        public override void OnRemoveCard()
        {
            effect.Destroy();
        }
        protected override string GetTitle()
        {
            return "Love Tap";
        }
        protected override string GetDescription()
        {
            return "Your Bullets Now Heal Your Loved Ones";
        }
        protected override GameObject GetCardArt()
        {
            return DHC.ArtAssets.LoadAsset<GameObject>("C_Love_Tap");
        }
        protected override CardInfo.Rarity GetRarity()
        {
            if (DateTools.WeekOf(Holidays.GetValentine()))
            {
                return CardInfo.Rarity.Uncommon;
            }
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                 CardTools.FormatStat(false,"Damage",-damage_reduction)
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.MagicPink;
        }        
        public override string GetModName()
        {
            return "DHC";
        }
    }
}
