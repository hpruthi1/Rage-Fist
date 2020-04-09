using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenuUI : MonoBehaviour
{
    public GameObject BackPanel;
    public GameObject OptionsMenu;
    public GameObject BackButton;
    public Audiomanager audiomanager;

    void Start()
    {
        BackPanel.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void onPlayButtonClick()
    {
        FindObjectOfType<Audiomanager>().Play("ButtonClicked");
        SceneManager.LoadScene(1);
    }

    public void onBackButtonClick()
    {
        FindObjectOfType<Audiomanager>().Play("ButtonClicked");
        BackPanel.SetActive(true);
    }

    public void onYesButtonClick()
    {
        FindObjectOfType<Audiomanager>().Play("ButtonClicked");
        Application.Quit();
    }

    public void onOptionsButtonClick()
    {
        FindObjectOfType<Audiomanager>().Play("ButtonClicked");
        OptionsMenu.SetActive(true);
        BackButton.SetActive(false);
    }
    public void onNoButtonClick()
    {
        FindObjectOfType<Audiomanager>().Play("ButtonClicked");
        BackPanel.SetActive(false);
    }

    public void onHomeButtonClick()
    {
        FindObjectOfType<Audiomanager>().Play("ButtonClicked");
        OptionsMenu.SetActive(false);
        BackPanel.SetActive(false);
        BackButton.SetActive(true);
    }
}
