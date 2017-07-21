using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.CameraUI.Quests
{
    public class QuestController : MonoBehaviour
    {
        [SerializeField] Quest[] currentQuests;

        public delegate void OnQuestTrigger(string trigger);
        public static event OnQuestTrigger onQuestTrigger;

        // Use this for initialization
        void Start()
        {
            //currentQuests = new List<Quest>();
            foreach (Quest quest in currentQuests)
            {
                quest.Init();
            }
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

        void StartQuest(int questIndex)
        {
            print(currentQuests[questIndex].dialogueStart);
            currentQuests[questIndex] = null;
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