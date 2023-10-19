using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Candy : MonoBehaviour
{

    [SerializeField] public int pointValue;
    public ScoreManager sManager;
    public CandyManager cManager;
    public TextMeshProUGUI scoreUI;
    private void OnCollisionEnter2D(Collision2D collision) //This will run upon collision
    {
        if (collision.gameObject.tag == "Player")
        {
            sManager.UpdateScore(pointValue);
        }
        Destroy(gameObject);
    }

}
