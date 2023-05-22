using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PlayerScoreL;
    public int PlayerScoreR;

    //Buat UI Text
    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;

    public GameObject PanelWin;
    public TMP_Text playerWin;

    public SceneManagement sm;
    public static GameManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PanelWin.SetActive(false);
    }


    //Method penyeleksi untuk menambah score
    public void Score(string wallID)
    {
        if (wallID == "Line_Left")
        {
            PlayerScoreR += 10; //Menambah score
            txtPlayerScoreR.text = PlayerScoreR.ToString(); //Mengisikan nilai integer PlayerScore ke UI
            ScoreCheck();
        }
        else
        {
            PlayerScoreL += 10;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
            ScoreCheck();
        }
    }
    public void ScoreCheck()
    {
        if (PlayerScoreL == 20)
        {
            PanelWin.SetActive(true);
            playerWin.SetText("Player L Won!!!");
            Invoke("ChangeTheScene",2.0f);
        }
        else if (PlayerScoreR == 20)
        {
            PanelWin.SetActive(true);
            playerWin.SetText("Player R Won!!!");
            Invoke("ChangeTheScene", 2.0f);
        }
    }


    public void ChangeTheScene()
    {
        sm.ChangeScene("GameOver");
    }
}