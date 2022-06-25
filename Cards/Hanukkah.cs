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

namespace DHC.Cards
{
    class Hanukkah : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            cardInfo.allowMultiple = false;
            cardInfo.GetAdditionalData().canBeReassigned = false;
            cardInfo.categories = new CardCategory[]
            {
                CardChoiceSpawnUniqueCardPatch.CustomCategories.CustomCardCategories.instance.CardCategory("CardManipulation")
            };
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            for(int i = 0; i< 8; i++)
            {
                CardInfo randomCard = ModdingUtils.Utils.Cards.instance.NORARITY_GetRandomCardWithCondition(player, gun, gunAmmo, data, health, gravity, block, characterStats, this.condition);
                ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, randomCard, addToCardBar: true);
            }
        }
        public override void OnRemoveCard()
        {
            //base.OnRemoveCard();
        }
        protected override string GetTitle()
        {
            return "Hanukkah";
        }
        protected override string GetDescription()
        {
            return "Get 8 random common cards";
        }
        protected override GameObject GetCardArt()
        {
            return DHC.ArtAssets.LoadAsset<GameObject>("C_Hanukkah");
        }
        protected override CardInfo.Rarity GetRarity()
        {
            if (DateTools.DayOf(Holidays.GetHanukkah()))
            {
                return CardInfo.Rarity.Uncommon;
            }
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public bool condition(CardInfo card, Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            return (card.rarity == CardInfo.Rarity.Common) && !card.categories.Intersect(Christmas.noLotteryCategories).Any();
        }
        public override string GetModName()
        {
            return "DHC";
        }
    }
}
