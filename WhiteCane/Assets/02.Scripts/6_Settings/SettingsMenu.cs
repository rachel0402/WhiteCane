using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Button backButton;

    public GameObject gameMenuPanel; // GameMenu_Panel
    public GameObject settingsPanel; // SettingsPanel


    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });

        backButton.onClick.AddListener(delegate { OnBackClick(); });

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnVolumeChange()
    {
        AudioListener.volume = volumeSlider.value;
    }

    void OnBackClick()
    {
        //settings_Panel 비활성화
        settingsPanel.SetActive(false);
        // GameMenu_Panel 활성화
        gameMenuPanel.SetActive(true);

    }
}
