using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.CameraUI.Quests;
using Fungus;

public class NPC : MonoBehaviour
{

    [SerializeField] float triggerRadius = 5f;
    [SerializeField] Quest quest;
    [SerializeField] Flowchart flowchart;

    bool questAccepted = false;

    // Use this for initialization
    void Start ()
    {
        SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = triggerRadius;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            AssignQuest(other.GetComponent<QuestController>());
            flowchart.SendFungusMessage("test");
        }
    }

    void AssignQuest(QuestController qc)
    {
        if (!questAccepted)
        {
            if (qc.TryStartQuest(quest))
                questAccepted = true;
            else
                print("You cannot accept any more quests.");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 255f, 0, .5f);
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
