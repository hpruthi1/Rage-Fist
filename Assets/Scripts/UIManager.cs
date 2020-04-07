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
    public GameObject JoystickCanvas;
    public TextMeshProUGUI PlayerDialogue;
    public TextMeshProUGUI EnemyDialogue;
    private void Start()
    {
        Time.timeScale = 0f;
        InitialPanel.SetActive(true);
        PlayerDialogue.text = "Who Are You?";
        EnemyDialogue.text = "Go Away..It's Not Safe. Can't you see the board over there?";
        JoystickCanvas.SetActive(false);
    }
   
    void Update()
    {
        Count.text = CoinsCollected.ToString();
        IntelCount.text = IntelCollected.ToString();
        ChemicalCount.text = ChemicalsCollected.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            InitialPanel.SetActive(false);
            JoystickCanvas.SetActive(true);
            Time.timeScale = 1;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                InitialPanel.SetActive(false);
                JoystickCanvas.SetActive(true);
                Time.timeScale = 1;
            }
        }
    }
}
