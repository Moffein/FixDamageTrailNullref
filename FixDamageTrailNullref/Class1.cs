using RoR2;
using UnityEngine;
using BepInEx;
using System.Linq;
using System;

namespace R2API.Utils
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ManualNetworkRegistrationAttribute : Attribute
    {
    }
}

namespace FixDamageTrailNullref
{
    [BepInPlugin("com.Moffein.FixDamageTrailNullref", "Fix DamageTrail Nullref", "1.0.0")]
    public class FixDamageTrailNullref : BaseUnityPlugin
    {
        public void Awake()
        {
            On.RoR2.DamageTrail.FixedUpdate += (orig, self) =>
            {
                self.pointsList = self.pointsList.Where(p => p.segmentTransform != null).ToList();
                orig(self);
            };
        }
    }
}
