using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject ballPrefab;
    public Text playerScore;
    public Text enemyScore;

    private int playerPoints = 0;
    private int enemyPoints = 0;

    private GameObject ball;
    // Start is called before the first frame update
    private void Start()
    {
        UpdateText(playerScore, "Player score: " + playerPoints.ToString());
        UpdateText(enemyScore, enemyScore.text = "Enemy score: " + enemyPoints.ToString());
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        ball = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {}

    public void Score(bool hasPlayerScored)
    {
        if (hasPlayerScored)
        {
            playerPoints++;
            UpdateText(playerScore, "Player score: " + playerPoints.ToString());
        }
        else
        {
            enemyPoints++;
            UpdateText(enemyScore, enemyScore.text = "Enemy score: " + enemyPoints.ToString());
        }
    }

    private void UpdateText(Text text, string msg)
    {
        text.text = msg;
    }
}
