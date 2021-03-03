using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace RPG.Saving
{
    public class SavingSystem : MonoBehaviour
    {
        public void Save(string saveFile)
        {
            string path = GetPathFromSaveFile(saveFile);
            print("Saving to " + path); //追加
            FileStream stream = File.Open(path, FileMode.Create);　//追加
            stream.WriteByte(0xc2); //追加
            stream.WriteByte(0xa1); //追加
            stream.WriteByte(0x48); //追加
            stream.WriteByte(0x6f); //追加
            stream.WriteByte(0x6c); //追加
            stream.WriteByte(0x61); //追加
            stream.WriteByte(0x21); //追加
            byte[] bytes = Encoding.UTF8.GetBytes("!Hola Mundo!"); //追加
            stream.Write(bytes, 0, bytes.Length); //追加
            stream.Close(); //追加
        }

        public void Load(string saveFile)
        {
            print("Load to " + GetPathFromSaveFile(saveFile));
        }

        private string GetPathFromSaveFile(string saveFile)
        {
            return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
        }
    }
}
