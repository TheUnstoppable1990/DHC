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
    class Kuumba_Effect : MonoBehaviour
    {
        internal Player player;
        internal Gun gun;
        internal GunAmmo gunAmmo;
        internal Color[] colors = new Color[]
        {
            Color.red,
            Color.red,
            Color.red,
            Color.black,
            Color.green,
            Color.green,
            Color.green
        };
        private float timePass = 0.0f;
        private int secondCount = 0;
        private void Start()
        {

        }
        private void Awake()
        {
            this.player = gameObject.GetComponent<Player>();
            this.gun = player.GetComponent<Holding>().holdable.GetComponent<Gun>();
            this.gunAmmo = this.gun.GetComponentInChildren<GunAmmo>();
        }
        private void Update()
        {
            timePass += Time.deltaTime;
            if (timePass > 1.0f)  //every second
            {
                this.gun.projectileColor = colors[secondCount];
                timePass = 0.0f;
                secondCount++;
                if (secondCount > 6)
                {
                    secondCount = 0;
                }
            }
        }
        public void Destroy()
        {
            UnityEngine.Object.Destroy(this);
        }
    }
   

}
