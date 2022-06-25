using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using DHC.Utilities;
using DHC.Cards.KWZ;
using ModdingUtils.Extensions;

namespace DHC.Cards
{
    class Kwanzaa : CustomCard
    {
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
            //throw new NotImplementedException();
            CardInfo[] kwanzaaCards = new CardInfo[]
            {
                Umoja.self,
                Kujichagulia.self,
                Ujima.self,
                Ujamaa.self,
                Nia.self,
                Kuumba.self,
                Imani.self
            };
            ModdingUtils.Utils.Cards.instance.AddCardsToPlayer(player, kwanzaaCards,false,null,null,null,true);
            

        }
        public override void OnRemoveCard()
        {
            //base.OnRemoveCard();
        }
        protected override string GetTitle()
        {
            return "Kwanzaa";
        }
        protected override string GetDescription()
        {
            return "Get a Kwanzaa candle card for every day of Kwanzaa.";
        }
        protected override GameObject GetCardArt()
        {
            return DHC.ArtAssets.LoadAsset<GameObject>("C_Kwanzaa");
        }
        protected override CardInfo.Rarity GetRarity()
        {
            if (DateTools.DayOf(Holidays.GetKwanzaa()))
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
            return CardThemeColor.CardThemeColorType.DestructiveRed;
        }
        public override string GetModName()
        {
            return "DHC";
        }
    }
}
