using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core; //TODO: consider rewiring

namespace RPG.Weapons
{
    public class Projectile : MonoBehaviour
    {

        public float projectileSpeed; // Note other classes can set
        public GameObject shooter;

        float damageCaused;

        public void SetDamage(float damage)
        {
            damageCaused = damage;
        }

        void OnTriggerEnter(Collider collider)
        {
            if (shooter && collider.gameObject.layer == shooter.layer)
                return;

            Component damagableComponent = collider.gameObject.GetComponent(typeof(IDamageable));
            if (damagableComponent)
            {
                (damagableComponent as IDamageable).TakeDamage(damageCaused);
            }
            Destroy(gameObject);
        }
    }
}