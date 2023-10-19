using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    [SerializeField] private TextMeshProUGUI scoreUI;
    public int totalscore = 0;
    public bool gameActive = true;

    private void Awake()
    {
        if(scoreManager == null)
        {
            scoreManager = this;
        }
        scoreUI.text = "Score: 0";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetOver()
    {
        gameActive = false;
        scoreUI.text = "Game Over! \nYou had "+totalscore.ToString()+" points!";
    }

    public void UpdateScore(int score)
    {
        if(gameActive == true)
        {
            totalscore += score;
            scoreUI.text = "Score: " + totalscore.ToString();
        }
    }
}
