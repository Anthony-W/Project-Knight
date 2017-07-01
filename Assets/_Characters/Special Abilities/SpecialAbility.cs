using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Characters
{

    public struct AbilityUseParams
    {
        public IDamageable target;
        public float baseDamage;

        public AbilityUseParams(IDamageable target, float baseDamage)
        {
            this.target = target;
            this.baseDamage = baseDamage;
        }
    }

    public abstract class SpecialAbility : ScriptableObject {

        [Header("Special Ability General")]
        [SerializeField] float cooldown = 5f;
        float currentCooldown = 0;

        protected ISpecialAbility behavior;

        abstract public void AddComponent(GameObject gameObjectToAttachTo);
        
        public void Use(AbilityUseParams useParams)
        {
            behavior.Use(useParams);
        }

        public float getCooldownRemaining()
        {
            return currentCooldown;
        }
    }

    public interface ISpecialAbility
    {
        void Use(AbilityUseParams useParams);
    }
}