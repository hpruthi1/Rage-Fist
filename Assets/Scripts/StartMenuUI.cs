using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenuUI : MonoBehaviour
{

    public GameObject BackPanel;
    public GameObject OptionsMenu;
    public GameObject BackButton;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        BackPanel.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void onPlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void onBackButtonClick()
    {
        BackPanel.SetActive(true);
    }

    public void onYesButtonClick()
    {
        Application.Quit();
    }

    public void onOptionsButtonClick()
    {
        OptionsMenu.SetActive(true);
        BackButton.SetActive(false);

    }
    public void onNoButtonClick()
    {
        BackPanel.SetActive(false);
    }

    public void onHomeButtonClick()
    {
        OptionsMenu.SetActive(false);
        BackPanel.SetActive(false);
        BackButton.SetActive(true);
    }
}
