using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;
using UnityEngine.UI;

public class JSONPreferences : MonoBehaviour
{
    public PlayerPrefsJSON JsonPrefs;

    public Button saveJSON;
    public Button loadJSON;

    void Start()
    {
        saveJSON.onClick.AddListener(SaveToFile);
        loadJSON.onClick.AddListener(LoadFromFile);
    }

    void SaveToFile()
    {
       string json = JsonUtility.ToJson(JsonPrefs, true);

       Debug.Log("SAVED" + json);

       File.WriteAllText(Path.Combine(Application.persistentDataPath, "playerProfile.json"), json);
    }

    void LoadFromFile()
    {
        string dataAsJson = "";
        
        dataAsJson = File.ReadAllText(Path.Combine(Application.persistentDataPath, "playerProfile.json"));
        
        JsonPrefs = JsonUtility.FromJson<PlayerPrefsJSON>(dataAsJson);
        
        Debug.Log("LOADED" + dataAsJson);
    }
}
