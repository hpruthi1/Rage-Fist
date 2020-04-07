using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public int CoinsCollected = 0;
    public int IntelCollected = 0;
    public int ChemicalsCollected = 0;
    public TextMeshProUGUI Count;
    public TextMeshProUGUI IntelCount;
    public TextMeshProUGUI ChemicalCount;
    public GameObject InitialPanel;
    public TextMeshProUGUI PlayerDialogue;
    public TextMeshProUGUI EnemyDialogue;
    private void Start()
    {
        Time.timeScale = 0f;
        InitialPanel.SetActive(true);
        PlayerDialogue.text = "Who Are You?";
    }
   
    void Update()
    {
        Count.text = CoinsCollected.ToString();
        IntelCount.text = IntelCollected.ToString();
        ChemicalCount.text = ChemicalsCollected.ToString();

        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            PlayerDialogue.text = "";
            EnemyDialogue.text = "Go Away..It's Not Safe. Can't you see the board over there?";
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            StartCoroutine(GameStart());
        }
        if (Input.GetKey(KeyCode.Q))
        {
            InitialPanel.SetActive(false);
            //FindObjectOfType<Audiomanager>().Play("BG");
            Time.timeScale = 1;
        }
    }

    IEnumerator GameStart()
    {
        PlayerDialogue.text = "I'll get what i want and will go away";
        EnemyDialogue.text = "Let me see What can you do..I'll kick you a**";
        yield return new WaitForSeconds(2f);
        Time.timeScale = 1;
    }

}
