using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DHC.Cards;
using DHC.MonoBehaviours;

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
        }

    }
}