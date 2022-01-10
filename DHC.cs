using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using Photon.Pun;
using HarmonyLib;
using UnboundLib.GameModes;
using Jotunn.Utils;
using DHC.MonoBehaviours;
using DHC.Cards;
using DHC.Cards.KWZ;


namespace DHC
{
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(ModID, ModName, ModVersion)]
    [BepInProcess("Rounds.exe")]
    public class DHC : BaseUnityPlugin
    {
        private const string ModID = "com.theunstoppable1990.rounds.dhc";
        private const string ModName = "Dope Holiday Cards (DHC)";
        public const string ModVersion = "0.1.0";

        public static DHC instance { get; private set; }
        void Awake()
        {
            var harmony = new Harmony(ModID);
            harmony.PatchAll();
            GameModeManager.AddHook(GameModeHooks.HookGameEnd, ResetEffects);
        }
        IEnumerator ResetEffects(IGameModeHandler gm)
        {
            DestroyAll<Kuumba_Effect>();
            DestroyAll<Imani_Effect>();
            yield break;
        }
        void DestroyAll<T>() where T : UnityEngine.Object
        {
            var objects = GameObject.FindObjectsOfType<T>();
            for (int i = objects.Length - 1; i >= 0; i--)
            {
                UnityEngine.Debug.Log($"Attempting to Destroy {objects[i].GetType().Name} number {i}");
                UnityEngine.Object.Destroy(objects[i]);
            }
        }
        void Start()
        {
            //Cards go here
            Unbound.RegisterCredits(ModName,
                new string[] { "TheUnstoppable1990 (HatchetDaddy himself)" },
                new string[] { "GitHub"},
                new string[] { "https://github.com/TheUnstoppable1990/DHC"}
            );


            //
            CustomCard.BuildCard<Christmas>();
            CustomCard.BuildCard<Hanukkah>();
            CustomCard.BuildCard<Kwanzaa>();

            CustomCard.BuildCard<Imani>(card => { Imani.self = card; ModdingUtils.Utils.Cards.instance.AddHiddenCard(Imani.self); });
            CustomCard.BuildCard<Kujichagulia>(card => { Kujichagulia.self = card; ModdingUtils.Utils.Cards.instance.AddHiddenCard(Kujichagulia.self); });
            CustomCard.BuildCard<Kuumba>(card => { Kuumba.self = card; ModdingUtils.Utils.Cards.instance.AddHiddenCard(Kuumba.self); });
            CustomCard.BuildCard<Nia>(card => { Nia.self = card; ModdingUtils.Utils.Cards.instance.AddHiddenCard(Nia.self); });
            CustomCard.BuildCard<Ujamaa>(card => { Ujamaa.self = card; ModdingUtils.Utils.Cards.instance.AddHiddenCard(Ujamaa.self); });
            CustomCard.BuildCard<Ujima>(card => { Ujima.self = card; ModdingUtils.Utils.Cards.instance.AddHiddenCard(Ujima.self); });
            CustomCard.BuildCard<Umoja>(card => { Umoja.self = card; ModdingUtils.Utils.Cards.instance.AddHiddenCard(Umoja.self); });

            

        }

        static public string FormatStat(float value)
        {

            return value.ToString();
        }
    }
}
