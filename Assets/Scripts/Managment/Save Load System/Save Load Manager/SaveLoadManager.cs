using UnityEngine;
using System.IO;

namespace PowTask.SaveLoadSystem
{
    public class SaveLoadManager : MonoBehaviour
    {
        public static SaveData CurrentSaveData = new SaveData();
        private const string SaveDirectory = "/SaveData/";
        private const string FileName = "SaveGame.sav";

        public static void SaveGame()
        {
            var dir = Application.persistentDataPath + SaveDirectory;

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var json = JsonUtility.ToJson(CurrentSaveData, true);
            File.WriteAllText(dir + FileName, json);
        }

        public static void LoadGame()
        {
            string fullPath = Application.persistentDataPath + SaveDirectory + FileName;

            if (File.Exists(fullPath))
            {
                var json = File.ReadAllText(fullPath);
                CurrentSaveData = JsonUtility.FromJson<SaveData>(json);
            }
        }
    }
}
