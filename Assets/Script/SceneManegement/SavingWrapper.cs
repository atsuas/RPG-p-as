using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSaveFile = "save";

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
        }

        public void Save() //publicに変更
        {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }

        public void Load() //publicに変更
        {
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }
    }
}