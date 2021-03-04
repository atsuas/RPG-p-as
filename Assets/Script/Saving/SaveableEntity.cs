using System.Collections;
using System.Collections.Generic;
using RPG.Core; //追加
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Saving
{
    [ExecuteAlways]
    public class SaveableEntity : MonoBehaviour
    {
        [SerializeField] string uniqueIdentifier = "";

        public string GetUniqueIdentifier()
        {
            return uniqueIdentifier;
        }

        public object CaptureState()
        {
            return new SerializableVector3(transform.position); //追加
        }

        public void RestoreState(object state)
        {
            SerializableVector3 position = (SerializableVector3)state; //追加
            GetComponent<NavMeshAgent>().enabled = false; //追加
            transform.position = position.ToVector(); //追加
            GetComponent<NavMeshAgent>().enabled = true; //追加
            GetComponent<ActionScheduler>().CancelCurrentAction(); //追加
        }

        private void Update()
        {
            if (Application.IsPlaying(gameObject)) return;
            if (string.IsNullOrEmpty(gameObject.scene.path)) return;

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty property = serializedObject.FindProperty("uniqueIdentifier");

            if (string.IsNullOrEmpty(property.stringValue))
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
