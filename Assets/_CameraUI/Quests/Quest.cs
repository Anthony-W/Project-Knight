using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.CameraUI.Quests
{
    public abstract class Quest : ScriptableObject
    {
        [SerializeField] string trigger = "testTrigger";
        [SerializeField] int numTriggers = 1;
        public string dialogueStart = "Help us!";
        public string dialogueEnd = "Thank you!";

        public int currentTriggers = 0;
        bool completed = false;

        public void Init()
        {
            QuestController.onQuestTrigger += OnTrigger;
            currentTriggers = 0;
            completed = false;
        }

        public void RemoveFromDelegate()
        {
            QuestController.onQuestTrigger -= OnTrigger;
        }

        void OnTrigger(string trigger)
        {
            if (trigger == this.trigger)
            {
                currentTriggers++;
                if (currentTriggers >= numTriggers)
                {
                    completed = true;
                } else
                {
                    completed = false;
                }
            }
        }

        public bool IsCompleted()
        {
            return completed;
        }
    }
}