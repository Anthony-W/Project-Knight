using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.CameraUI.Quests
{
    public class QuestController : MonoBehaviour
    {
        [SerializeField] List<Quest> currentQuests;

        public delegate void OnQuestTrigger(string trigger);
        public static event OnQuestTrigger onQuestTrigger;

        // Use this for initialization
        void Start()
        {
            //currentQuests = new List<Quest>();
            foreach (Quest quest in currentQuests)
            {
                print(quest);
                quest.Init();
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (Quest quest in currentQuests)
            {
                print(quest.IsCompleted());
                print(quest.currentTriggers);
                if (quest.IsCompleted())
                {
                    FinishQuest(quest, currentQuests.IndexOf(quest));
                    return; // TODO: FIND BETTER SOLUTION
                }
            }
        }

        void StartQuest(Quest quest)
        {
            print(quest.dialogueStart);
            currentQuests.Add(quest);
        }

        void FinishQuest(Quest quest, int index)
        {
            quest.RemoveFromDelegate();
            print(quest.dialogueEnd);
            currentQuests.RemoveAt(index);
        }

        public static void Trigger(string trigger)
        {
            onQuestTrigger(trigger);
            print("Trigger: " + trigger);
        }
    }
}