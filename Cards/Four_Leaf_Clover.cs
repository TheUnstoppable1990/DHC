using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.Utils;
using UnityEngine;
using DHC.Utilities;
using ModdingUtils.Extensions;
using CardChoiceSpawnUniqueCardPatch;
using DHC.Effects;
namespace DHC.Cards
{
    class Four_Leaf_Clover : CustomCard
    {
        private float damage_multiplier = 17f;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            cardInfo.allowMultiple = false;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
           if (gunAmmo.maxAmmo < 4)
            {
                gunAmmo.maxAmmo = 4;
            }
            var fourLeaf = player.gameObject.AddComponent<Four_Leaf_Clover_Effect>();
            fourLeaf.multiplier = damage_multiplier;
        }
        public override void OnRemoveCard()
        {

        }
        protected override string GetTitle()
        {
            return "Four Leaf Clover";
        }
        protected override string GetDescription()
        {
            return $"1 in 4 chance of getting a lucky strike doing {damage_multiplier} times damage";
        }
        protected override GameObject GetCardArt()
        {
            return DHC.ArtAssets.LoadAsset<GameObject>("C_Four_Leaf_Clover");
        }
        protected override CardInfo.Rarity GetRarity()
        {
            if (DateTools.DayOf(Holidays.GetStPatrick()))
            {
                return CardInfo.Rarity.Common;
            }
            else if (DateTools.WeekOf(Holidays.GetStPatrick()))
            {
                return CardInfo.Rarity.Uncommon;
            }
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                 CardTools.FormatStat(true,"Ammo","At least 4")
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.PoisonGreen;
        }
        public override string GetModName()
        {
            return "DHC";
        }
    }
}

