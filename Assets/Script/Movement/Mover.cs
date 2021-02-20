using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;
namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction 
    {
        [SerializeField] Transform target;
        [SerializeField] float maxSpeed = 6f; //追加

        NavMeshAgent navMeshAgent;
        Health health;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();

            health = GetComponent<Health>();
        }

        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();

            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination, float speedFraction)   //speedFractionを追加
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination, speedFraction); //speedFractionを追加
        }

        public void MoveTo(Vector3 destination, float speedFraction)  //speedFractionを追加
        {
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);   //追加
            navMeshAgent.isStopped = false;
        }

        public void Cancel()   
        {
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("fowardSpeed", speed);
        }
    }
}
