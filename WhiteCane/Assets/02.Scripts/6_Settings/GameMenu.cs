using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Button lobbySceneButton;
    public Button settingsButton;
    public Button exitButton;

    public GameObject gameMenuPanel; // GameMenu_Panel
    public GameObject settingsPanel; // SettingsPanel



    // Start is called before the first frame update
    void Start()
    {
        lobbySceneButton.onClick.AddListener(delegate { OnSceneClick(); });

        settingsButton.onClick.AddListener(delegate { OnSettingsClick(); });

        exitButton.onClick.AddListener(delegate { OnExitClick(); });

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSceneClick()
    {
        SceneManager.LoadScene("Lobby");
    }

    void OnSettingsClick()
    {
        // GameMenu_Panel 비활성화
        gameMenuPanel.SetActive(false);
        // SettingsPanel 활성화
        settingsPanel.SetActive(true);
    }

    void OnExitClick()
    {
        // Exit the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
