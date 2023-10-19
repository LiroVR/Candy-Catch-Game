using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandyManager : MonoBehaviour
{
    [SerializeField] private GameObject projectile1, projectile2, projectile3, projectile4, projectile5, projectile6;
    private GameObject[] candyArray;
    public TextMeshProUGUI scoreUI;
    public CandyManager candyManager;
    public ScoreManager sManager;
    private int waitValue;
    public static int candiesAmount;
    private float timeSpent, timeSpentOld;
    private bool candySpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        candyArray = new GameObject[21]{projectile1, projectile1, projectile1, projectile1, projectile1, projectile1, projectile2, projectile2, projectile2, projectile2, projectile2, projectile3, projectile3, projectile3, projectile3, projectile4, projectile4, projectile4, projectile5, projectile5, projectile6};
        timeSpent = Time.time;
        waitValue = Random.Range (1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent = Time.time - timeSpentOld;
        if ((timeSpent > waitValue) && (candySpawn == true))
        {
            //Debug.Log("Spawning");
            Spawn();
        }
        
    }

    public void Spawn()
    {
        Vector3 position = new Vector3(Random.Range(-6.0F, 6.0F), 6f, 0f);
        int candyNum = Random.Range(0, 22);
        Rigidbody2D candy = Instantiate(candyArray[candyNum], position, Quaternion.identity).GetComponent<Rigidbody2D>();
        candy.simulated = true;
        waitValue = Random.Range (1, 4);
        timeSpentOld = Time.time;
        timeSpent = 0;
        candiesAmount += 1;
        if (candiesAmount > 14)
        {
            candySpawn = false;
            sManager.SetOver();
        }
    }
}
