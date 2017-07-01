using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters
{
    public class AOEBehavior : MonoBehaviour, ISpecialAbility
    {

        AOEConfig config;

        public void SetConfig(AOEConfig configToSet)
        {
            config = configToSet;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Use(AbilityUseParams useParams)
        {
            float damagePerEnemy = config.GetDamgePerEnemy();
            float radius = config.GetRadius();
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, Vector3.up);
            Enemy[] enemies = new Enemy[hits.Length];
            for (int i = 0; i < hits.Length; i++)
            {
                enemies[i] = hits[i].collider.gameObject.GetComponent<Enemy>();
                if (enemies[i]) enemies[i].TakeDamage(damagePerEnemy);
            }
        }
    }
}