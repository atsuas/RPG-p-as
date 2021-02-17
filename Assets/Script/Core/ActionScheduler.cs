using UnityEngine;
using System.Collections;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;  

        public void StartAction(IAction action) 
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel();   
            }
            currentAction = action;
        }

        //追加
        public void CancelCurrentAction()
        {
            StartAction(null);
        }
    }
}

