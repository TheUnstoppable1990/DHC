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

namespace DHC.Cards
{
    class Christmas : CustomCard
    {
        public static CardCategory[] noLotteryCategories = new CardCategory[] { 
            CardChoiceSpawnUniqueCardPatch.CustomCategories.CustomCardCategories.instance.CardCategory("CardManipulation"), 
            CardChoiceSpawnUniqueCardPatch.CustomCategories.CustomCardCategories.instance.CardCategory("NoRandom") 
        };
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            //base.SetupCard(cardInfo, gun, cardStats, statModifiers);
            cardInfo.allowMultiple = false;
            cardInfo.GetAdditionalData().canBeReassigned = false;
            cardInfo.categories = new CardCategory[]
            {
                CardChoiceSpawnUniqueCardPatch.CustomCategories.CustomCardCategories.instance.CardCategory("CardManipulation")
            };
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //CardInfo randomCard1 = ModdingUtils.Utils.Cards.instance.NORARITY_GetRandomCardWithCondition(player, gun, gunAmmo, data, health, gravity, block, characterStats, this.condition);
            int count = 0;
            DHC.instance.ExecuteAfterFrames(20, () =>
            {
                foreach (var person in PlayerManager.instance.players.Where(other => other.playerID != player.playerID).ToList())
                {
                    var pData = person.data;
                    var pHealth = pData.healthHandler;
                    var pGun = person.GetComponent<Gun>();
                    var pGunAmmo = person.GetComponent<GunAmmo>();
                    var pGrav = person.GetComponent<Gravity>();
                    var pBlock = person.GetComponent<Block>();
                    var pStats = person.GetComponent<CharacterStatModifiers>();
                    CardInfo randomCard1 = ModdingUtils.Utils.Cards.instance.NORARITY_GetRandomCardWithCondition(person, pGun, pGunAmmo, pData, pHealth, pGrav, pBlock, pStats, this.condition);
                    ModdingUtils.Utils.Cards.instance.AddCardToPlayer(person, randomCard1, addToCardBar: true);
                    count++;
                }
                for (var i = 0; i < count; i++)
                {
                    CardInfo randomCard2 = ModdingUtils.Utils.Cards.instance.NORARITY_GetRandomCardWithCondition(player, gun, gunAmmo, data, health, gravity, block, characterStats, this.condition);
                    ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, randomCard2, addToCardBar: true);
                }
            });
        }
        public override void OnRemoveCard()
        {
            //base.OnRemoveCard();
        }
        protected override string GetTitle()
        {
            return "Christmas Day";
        }
        protected override string GetDescription()
        {
            return "Presents for Everyone!";
        }
        protected override GameObject GetCardArt()
        {
            return DHC.ArtAssets.LoadAsset<GameObject>("C_Christmas");
        }
        protected override CardInfo.Rarity GetRarity()
        {
            if (DateTools.DayOf(Holidays.GetChristmas()))
            {
                return CardInfo.Rarity.Uncommon;
            }
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat [] GetStats()
        {
            return new CardInfoStat[]
            {
                CardTools.FormatStat(false,"1 Rare Card ","to everyone else"),
                CardTools.FormatStat(true, "1 Rare Card ","per everyone else")
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.PoisonGreen;
        }
        public bool condition(CardInfo card, Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            // do not allow duplicates of cards with allowMultiple == false (handled by moddingutils)
            // card rarity must be as desired
            // card cannot be another cardmanipulation card
            // card cannot be from a blacklisted catagory of any other card (handled by moddingutils)

            return (card.rarity == CardInfo.Rarity.Rare) && !card.categories.Intersect(Christmas.noLotteryCategories).Any();

        }
        public override string GetModName()
        {
            return "DHC";
        }
    }
}
