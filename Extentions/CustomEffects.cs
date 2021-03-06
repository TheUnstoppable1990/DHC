using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DHC.Cards;
using DHC.MonoBehaviours;
using DHC.Effects;

namespace HDC.Extentions
{
    public static class CustomEffects
    {
        public static void DestroyAllEffects(GameObject gameObject)
        {
            DestroyAllAppliedEffects(gameObject);
        }
        public static void DestroyAllAppliedEffects(GameObject gameObject)
        {
            Imani_Effect[] imani_Effects = gameObject.GetComponents<Imani_Effect>();
            foreach (Imani_Effect ie in imani_Effects)
            {
                if (ie != null)
                {
                    ie.Destroy();
                }
            }
            Kuumba_Effect[] kuumba_Effects= gameObject.GetComponents<Kuumba_Effect>();
            foreach (Kuumba_Effect ke in kuumba_Effects)
            {
                if (ke != null)
                {
                    ke.Destroy();
                }
            }
            Love_Tap_Effect[] love_tap_Effects = gameObject.GetComponents<Love_Tap_Effect>();
            foreach (Love_Tap_Effect lte in love_tap_Effects)
            {
                if (lte != null)
                {
                    lte.Destroy();
                }
            }
            Four_Leaf_Clover_Effect[] four_Leaf_Clover_Effects = gameObject.GetComponents<Four_Leaf_Clover_Effect>();
            foreach(Four_Leaf_Clover_Effect flce in four_Leaf_Clover_Effects)
            {
                if (flce != null)
                {
                    flce.Destroy();
                }
            }
        }

    }
}