using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelLose;
    public  int PlayerScoreL = 0;
    public  int PlayerScoreR = 0;
    public string gameMode;

    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;
    
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
        panelWin.SetActive(false);
        panelLose.SetActive(false);

        gameMode = SceneManager.GetActiveScene().name;
        StartingScore();

        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
    }

    public void StartingScore()
    {
        switch(gameMode){
            case "1p_StoryMode":
                PlayerScoreL = 3;
                PlayerScoreR = 9;
                break;

            case "1p_EnemyMode":
                PlayerScoreL = 0;
                PlayerScoreR = 0;
                break;

            case "2p_CouchMode":
                PlayerScoreL = 0;
                PlayerScoreR = 0;
                break;        
        }
    }

    public void Score(string wallID)
    {
        ChangeScore(wallID);
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
        CheckScore();
    }

    public void CheckScore()
    {
        switch(gameMode){
            case "1p_StoryMode":
                if (PlayerScoreL <= 0){
                    panelLose.SetActive(true);
                }
                else if (PlayerScoreL > 0 && PlayerScoreR <= 0){
                    panelWin.SetActive(true);
                }
                break;

            case "1p_EnemyMode":
                if (PlayerScoreL >= 3){
                    panelWin.SetActive(true);
                }
                else if (PlayerScoreR >= 3){
                    panelLose.SetActive(true);
                }
                break;

            case "2p_CouchMode":
                if (PlayerScoreL >= 3){
                    panelWin.SetActive(true);
                }
                else if (PlayerScoreR >= 3){
                    panelLose.SetActive(true);
                }
                break;    
        }
    }

    public void ChangeScore(string wallID)
    {
        switch(gameMode){
            case "1p_StoryMode":
                if(wallID == "LeftGoal"){
                    PlayerScoreL = PlayerScoreL - 1;
                    PlayerScoreR = PlayerScoreR - 1;
                } else {
                    PlayerScoreR = PlayerScoreR - 1;
                }
                
                break;

            case "1p_EnemyMode":
                if(wallID == "LeftGoal"){
                    PlayerScoreR = PlayerScoreR + 1;
                } else {
                    PlayerScoreL = PlayerScoreL + 1;
                }
                break;

            case "2p_CouchMode":
                if(wallID == "LeftGoal"){
                    PlayerScoreR = PlayerScoreR + 1;
                } else {
                    PlayerScoreL = PlayerScoreL + 1;
                }
                break;    
        }
    }
}
