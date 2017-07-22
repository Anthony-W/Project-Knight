using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.CameraUI.Quests
{
    public class QuestController : MonoBehaviour
    {
        Quest[] currentQuests;

        public delegate void OnQuestTrigger(string trigger);
        public static event OnQuestTrigger onQuestTrigger;

        // Use this for initialization
        void Start()
        {
            currentQuests = new Quest[20];
            /*
            foreach (Quest quest in currentQuests)
            {
                quest.Init();
            }
            */
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < currentQuests.Length; i++)
            {
                if (currentQuests[i] && currentQuests[i].IsCompleted())
                {
                    if (currentQuests[i] && currentQuests[i].IsCompleted())
                        FinishQuest(i);
                }
            }
        }


        /*
         * returns true if quest successfully assigned, false if quest controller is full
         */
        public bool TryStartQuest(Quest newQuest)
        {
            for (int i = 0; i < currentQuests.Length; i++)
            {
                if (!currentQuests[i])
                {
                    currentQuests[i] = newQuest;
                    currentQuests[i].Init();
                    print(currentQuests[i].dialogueStart);
                    return true;
                }
            }
            return false;
        }

        void FinishQuest(int questIndex)
        {
            currentQuests[questIndex].RemoveFromDelegate();
            print(currentQuests[questIndex].dialogueEnd);
            currentQuests[questIndex] = null;
        }

        void UpdateQuestList()
        {
            for (int i = 0; i < currentQuests.Length; i++)
            {
                if (i <= currentQuests.Length - 2 && !currentQuests[i] && currentQuests[i + 1])
                {
                    currentQuests[i] = currentQuests[i + 1];
                    currentQuests[i + 1] = null;
                }
            }
        }

        public static void Trigger(string trigger)
        {
            onQuestTrigger(trigger);
            print("Trigger: " + trigger);
        }
    }
}