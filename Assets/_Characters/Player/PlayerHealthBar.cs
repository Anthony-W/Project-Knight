using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Characters
{
    public class PlayerHealthBar : MonoBehaviour
    {
        Image healthOrb = null;
        Player player = null;

        // Use this for initialization
        void Start()
        {
            player = FindObjectOfType<Player>(); // Different to way player's health bar finds player
            healthOrb = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            healthOrb.fillAmount = player.healthAsPercentage;
            //float xValue = -(player.healthAsPercentage / 2f) - 0.5f;
        }
    }
}