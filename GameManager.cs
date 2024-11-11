using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> target;
    public List<GameObject> powerUps;
    public Button freezeButton;

    private float spawnTime = 1.5f;
    private float powerUptime;
    [SerializeField] private TextMeshProUGUI score;
    private float scorePoint;

    private bool isDoublePointsActive = false;

    void Start()
    {
        
        StartCoroutine(SpawnTargets());
        StartCoroutine(SpawnPowerUp());
        scorePoint = 0;
        UpdateScore(0);
        freezeButton.interactable = false;
        ButtonColourVisibility(false);
    }

    private void Awake()
    {
        powerUptime = Random.Range(7.0f, 10.0f);
    }


    public void ButtonColourVisibility(bool isActive)
    {
        if (!isActive)
        {
            Color buttonColour = freezeButton.image.color;
            buttonColour.a = 0f;
            freezeButton.image.color = buttonColour;
            Debug.Log("Button Not Visible");
        }
        else if(isActive)
        {
            Color buttonColour = freezeButton.image.color;
            buttonColour.a = 100f;
            freezeButton.image.color = buttonColour;
            Debug.Log("Button is Visible");
        }
    }
    IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index]);
        }
    }

    public void UpdateScore(float scoreToAdd)
    {
        float finalScore = isDoublePointsActive ? scoreToAdd * 2 : scoreToAdd;
        scorePoint += finalScore;
        score.text = "Score: " + scorePoint;
    }

    IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUptime);
            int index = Random.Range(0, powerUps.Count);
            Instantiate(powerUps[index]);
        }
    }

    // Power-Up Collection Methods

    public void CollectTimeFreeze()
    {
        StartCoroutine(TimeFreezeCoroutine());
    }

    private IEnumerator TimeFreezeCoroutine()
    {
        freezeButton.interactable = false;
        ButtonColourVisibility(false);
        float originalTimeScale = Time.timeScale;
        Time.timeScale = 0.0f; // Slow down time
        yield return new WaitForSecondsRealtime(5); // 5 seconds real time
        Time.timeScale = originalTimeScale;/// Resume normal time
        
    }

    public void CollectMoneyBag()
    {
        int scoreToAdd = Random.Range(10, 31); // Random coins between 10 and 30
        UpdateScore(scoreToAdd);
        Debug.Log("Money Bag Collected: " + scoreToAdd + " coins!");
    }

    public void CollectDoublePoints()
    {
        if (!isDoublePointsActive) // Only activate if not already active
        {
            StartCoroutine(DoublePointsCoroutine());
        }
    }

    private IEnumerator DoublePointsCoroutine()
    {
        isDoublePointsActive = true;
        yield return new WaitForSeconds(6); // 6 seconds duration for double points
        isDoublePointsActive = false;
    }
}


 