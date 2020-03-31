using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{

    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(true);
    }

    public void OnPlayAgainButton()
    {
        SceneManager.LoadScene(0);
    }

    public void onExitButtonClick()
    {
        Application.Quit();
    }
}
