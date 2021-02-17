using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Core;     //追加

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        Health health;  //追加
        GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();    //追加
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (health.IsDead()) return;    //追加
            
            if (InAttackRangeOfPlayer() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }

        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }
    }
}
