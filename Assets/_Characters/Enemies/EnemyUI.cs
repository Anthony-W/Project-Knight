﻿using UnityEngine;

// Add a UI Socket transform to your enemy
// Attach this script to the socket
// Link to a canvas prefab
namespace RPG.Characters
{
    public class EnemyUI : MonoBehaviour
    {

        // Works around Unity 5.5's lack of nested prefabs
        [Tooltip("The UI canvas prefab")]
        [SerializeField]
        GameObject enemyCanvasPrefab = null;

        Camera cameraToLookAt;

        // Use this for initialization 
        void Start()
        {
            cameraToLookAt = Camera.main;
            GameObject canvas = Instantiate(enemyCanvasPrefab, transform.position, Quaternion.identity, transform) as GameObject;
            canvas.transform.rotation = transform.rotation;
        }

        // Update is called once per frame 
        void LateUpdate()
        {
            transform.LookAt(cameraToLookAt.transform);
            transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
        }
    }
}