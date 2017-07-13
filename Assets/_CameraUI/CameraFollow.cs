using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.CamerUI
{
    public class CameraFollow : MonoBehaviour
    {

        GameObject player;
        Vector3 rotate;

        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            rotate = new Vector3(0, 1, 0);
            transform.Rotate(rotate * 150);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
                transform.Rotate(-rotate);
            if (Input.GetKey(KeyCode.D))
                transform.Rotate(rotate);
        }

        void LateUpdate()
        {
            transform.position = player.transform.position;
        }
    }
}