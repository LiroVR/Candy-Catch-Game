using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI Messages;
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
            if(totalscore > 10 && totalscore < 25)
            {
                Messages.text = "Cantastic!";
            }
            else if(totalscore > 24 && totalscore < 35)
            {
                Messages.text = "Sugar Crazy!";
            }
            if(totalscore > 34)
            {
                Messages.text = "Mucho Cando!";
            }
        }
    }
}
