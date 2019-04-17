using UnityEngine;
using UnityEngine.UI;

public class PlayerPreferences : MonoBehaviour
{
    public string playerName;

    public Button savePreferences;
    public Button loadPreferences;

    void Start()
    {
        savePreferences.onClick.AddListener(SavePreferences);
        loadPreferences.onClick.AddListener(LoadPreferences);
    }

    void SavePreferences()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
    }

    void LoadPreferences()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName");
        }
    }
}
