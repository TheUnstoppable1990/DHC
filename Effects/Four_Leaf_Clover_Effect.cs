using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ModdingUtils.MonoBehaviours;

namespace DHC.Effects
{
    public class Four_Leaf_Clover_Effect: CounterReversibleEffect
    {
        public bool lukcy_active;
        public float multiplier = 17f;

        private System.Random rand;
        public override CounterStatus UpdateCounter()
        {
            rand = new System.Random();
            int num = rand.Next(1, 5);
            if (num == 4) //1 in 4 odds
            {
                return CounterStatus.Apply;
            }
            return CounterStatus.Remove;
        }

        public override void UpdateEffects()
        {
            gunStatModifier.damage_mult = this.multiplier;
            gunStatModifier.projectileColor = Color.green;
        }

        public override void OnStart()
        {
            base.OnStart();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnApply()
        {
            //throw new NotImplementedException();
        }
        public override void Reset()
        {
            //throw new NotImplementedException();
        }       
    }
}
