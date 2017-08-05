using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.CameraUI.Quests;
using Fungus;

namespace RPG.Characters
{
    public class QuestGiver : NPC
    {
        [SerializeField] Quest quest;
        [SerializeField] Flowchart flowchart;

        bool questAccepted = false;

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


        public override void StartInteraction()
        {
            AssignQuest(GameObject.FindGameObjectWithTag("Player").GetComponent<QuestController>());
            flowchart.SendFungusMessage("test");
        }
    }
}