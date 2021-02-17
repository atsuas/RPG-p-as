using UnityEngine;
using System.Collections;
using RPG.Movement;
using System;
using RPG.Combat;
using RPG.Core; //追加

namespace RPG.control
{
    public class PlayerController : MonoBehaviour
    {
        Health health;  //追加

        //追加
        private void Start()
        {
            health = GetComponent<Health>();
        }

        private void Update()
        {
            if (health.IsDead()) return;    //追加
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            Debug.Log("Nothing to do");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                GameObject targetGameObject = target.gameObject;
                if (!GetComponent<Fighter>().CanAttack(target.gameObject))
                {
                    continue;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target.gameObject);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
