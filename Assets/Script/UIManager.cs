using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public float score;
    [HideInInspector] public int bombCount = 3;
    [HideInInspector] public int EnemyCount = 3;
    float enemyScore = 23;
    float muroScore = 5;

    [SerializeField] GameObject Start_;
    [SerializeField] public GameObject Pausa;
    [SerializeField] GameObject End;

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI ScoreEndText;
    [SerializeField] TextMeshProUGUI BombText;
    [SerializeField] TextMeshProUGUI EnemyCountText;

    GameManager GM;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        
    }

    void Update()
    {
        BombText.text = bombCount.ToString();
        ScoreText.text = score.ToString();
        ScoreEndText.text = score.ToString();
        EnemyCountText.text = EnemyCount.ToString();

        Debug.Log(EnemyCount);
        if(EnemyCount <= 0)
        {
            GM.EndGame();
            End.SetActive(true);
        }
    }

    public void EnemyScore()
    {
        score += enemyScore;
    }

    public void MuroScore()
    {
        score += muroScore;
    }

    public void Play()
    {
        Start_.SetActive(false);
        GM.gameStatus = GameManager.GameStatus.gameRunning;
    }


    public void Continue()
    {
        GM.gameStatus = GameManager.GameStatus.gameRunning;
        Pausa.SetActive(false);
    }

    public void Restart()
    {
        GM.gameStatus = GameManager.GameStatus.gamePaused;
        SceneManager.LoadScene("Napoli", LoadSceneMode.Single);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
