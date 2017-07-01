using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Weapons
{
    [CreateAssetMenu(menuName = ("RPG/Weapon"))]
    public class RPGWeapon : ScriptableObject
    {

        public Transform gripTransform;

        [SerializeField] GameObject weaponPrefab;
        [SerializeField] AnimationClip attackAnimation;
        [SerializeField] float minTimeBetweenHits = .5f;
        [SerializeField] float maxAttackRange = 2f;

        public GameObject GetWeaponPrefab()
        {
            return weaponPrefab;
        }

        public AnimationClip getAttackAnimclip()
        {
            RemoveAnimationEvents();
            return attackAnimation;
        }

        public float getMinTimeBetweenHits()
        {
            return minTimeBetweenHits;
        }

        public float getMaxAttackRange()
        {
            return maxAttackRange;
        }

        //so that asset packs cannot cause bugs / crashes
        private void RemoveAnimationEvents()
        {
            attackAnimation.events = new AnimationEvent[0];
        }
    }
}