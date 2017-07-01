using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    [CreateAssetMenu(menuName = ("RPG/Special Ability/AOE"))]
    public class AOEConfig : SpecialAbility
    {
        [Header("AOE Specific")]
        [SerializeField] float damagePerEnemy = 10f;
        [SerializeField] float radius = 5f;

        public override void AddComponent(GameObject gameObjectToAttachTo)
        {
            var behaviorComponent = gameObjectToAttachTo.AddComponent<AOEBehavior>();
            behaviorComponent.SetConfig(this);
            behavior = behaviorComponent;
        }

        public float GetDamgePerEnemy()
        {
            return damagePerEnemy;
        }

        public float GetRadius()
        {
            return radius;
        }

    }
}