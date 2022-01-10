
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using UnboundLib.Networking;
using System.Collections;
using System.ComponentModel;

namespace DHC.MonoBehaviours
{
    class Imani_Effect : MonoBehaviour
    {
        internal Player player;
        internal Gun gun;
        internal GunAmmo gunAmmo;


        internal CharacterData data;



        //private int count = 0;
        //private float distChange = 0.00f;
        private float timePass = 0.0f;


        private float healAmount = 5.0f;
        public float healRatio = 0.05f; 


        private void Start()
        {

        }
        private void Awake()
        {
            this.player = gameObject.GetComponent<Player>();
            this.data = player.GetComponent<CharacterData>();
            this.gun = player.GetComponent<Holding>().holdable.GetComponent<Gun>();
            this.gunAmmo = this.gun.GetComponentInChildren<GunAmmo>();
        }
        private void Update()
        {
            timePass += Time.deltaTime;
            if (timePass > 1.0f)  //every second
            {
                healAmount = this.data.maxHealth * healRatio;
                this.data.healthHandler.Heal(healAmount);
                timePass = 0.0f;

            }
        }
        public void Destroy()
        {
            UnityEngine.Object.Destroy(this);
        }
    }
}
