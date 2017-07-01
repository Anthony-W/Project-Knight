using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using System.Collections;

//TODO: Consider rewiring...
using RPG.CameraUI;
using RPG.Core;
using RPG.Weapons;

namespace RPG.Characters
{
    public class Player : MonoBehaviour, IDamageable
    {

        [SerializeField] float maxHealthPoints = 100f;
        [SerializeField] float baseDamage = 10f;

        [SerializeField] RPGWeapon weaponInUse;
        [SerializeField] GameObject weaponSocket;

        [SerializeField] AnimatorOverrideController animatorOverrideController;

        //temp
        [SerializeField] SpecialAbility[] abilities;

        float currentHealthPoints;
        CameraRaycaster cameraRaycaster;
        Animator animator;
        float lastHitTime = 0f;

        public float healthAsPercentage { get { return currentHealthPoints / maxHealthPoints; } }

        void Start()
        {
            animator = GetComponent<Animator>();
            RegisterForMouseClick();
            currentHealthPoints = maxHealthPoints;
            PutWeaponInHand();
            OverrideAnimatorController();
            foreach(SpecialAbility ability in abilities) ability.AddComponent(gameObject);
        }

        void Update()
        {
            if (Input.GetKeyUp(KeyCode.F)) AttempSpecialAbility(1, null);
        }

        void AttempSpecialAbility(int index, Enemy enemy)
        {
            //if (cooldown == 0)
            var abilityParams = new AbilityUseParams(enemy, baseDamage);
            abilities[index].Use(abilityParams);
        }

        private void OverrideAnimatorController()
        {
            animator.runtimeAnimatorController = animatorOverrideController;
            animatorOverrideController["DEFAULT ATTACK"] = weaponInUse.getAttackAnimclip();
        }

        private void PutWeaponInHand()
        {
            var weaponPrefab = weaponInUse.GetWeaponPrefab();
            GameObject dominantHand = RequestDominantHand();
            var weapon = Instantiate(weaponPrefab, dominantHand.transform);
            weapon.transform.localPosition = weaponInUse.gripTransform.localPosition;
            weapon.transform.localRotation = weaponInUse.gripTransform.localRotation;
        }

        private GameObject RequestDominantHand()
        {
            var dominantHands = GetComponentsInChildren<DominantHand>();
            int numberOfDominantHands = dominantHands.Length;
            Assert.AreNotEqual(numberOfDominantHands, 0, "No dominant hand found on player, please add one");
            Assert.IsFalse(numberOfDominantHands > 1, "Multiple dominant hands found on player, please remove one");
            return dominantHands[0].gameObject;
        }

        private void RegisterForMouseClick()
        {
            cameraRaycaster = FindObjectOfType<CameraRaycaster>();
            cameraRaycaster.onMouseOverEnemy += OnMouseOverEnemy;
        }

        void OnMouseOverEnemy(Enemy enemy)
        {
            if (Input.GetMouseButton(0) && TargetIsInRange(enemy.gameObject))
            {
                    attackTarget(enemy);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                AttempSpecialAbility(0, enemy);
            }
        }

        bool TargetIsInRange(GameObject enemy)
        {
            return (enemy.transform.position - transform.position).magnitude < weaponInUse.getMaxAttackRange();
        }

        void attackTarget(Enemy enemy)
        {
            var enemyComponent = enemy.GetComponent<Enemy>();
            if (Time.time - lastHitTime > weaponInUse.getMinTimeBetweenHits())
            {
                animator.SetTrigger("Attack");
                enemy.TakeDamage(baseDamage);
                lastHitTime = Time.time;
            }
        }

        public void TakeDamage(float damage)
        {
            currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, maxHealthPoints);
            if (currentHealthPoints <= 0)
            {
                StartCoroutine(KillPlayer());
            }
            else
            {
                //damage sound
                //damage animation
            }
        }

        IEnumerator KillPlayer()
        {
            //kill player
            //death sound
            //death animation
            //wait then reload scene

            print("DEAD");
            yield return new WaitForSecondsRealtime(2f);
            SceneManager.LoadScene(0);
        }

    }
}