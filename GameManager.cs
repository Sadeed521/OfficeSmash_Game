using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Made a list of gameobjecta that will act as targets to be clickec or not.
    public List<GameObject> target;
    public List<GameObject> powerUps;
    // timer for spawing the targets on by one.
    private float spawnTime = 1.5f;
    // timer for spawning power ups.
    private float powerUptime;
    //making a TmproUGui for score addition.
    [SerializeField]private TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {

        // StartCouroutine will activate the SpawnTarget fucntions continously till the game is over.
        StartCoroutine(SpawnTargets());
        StartCoroutine(SpawnPowerUp());
        score.text = "Score:";

    }
    private void Awake()
    {
        powerUptime = Random.Range(7.0f, 10.0f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    //this is where i decide how and when my targets will spawn.
    IEnumerator SpawnTargets()
    {
        while (true)
        {
            //i demanded to wait for seconds in this code.
            yield return new WaitForSeconds(spawnTime);
            //this is the sequence of my targets that will spawn which is probably random spawning.
            int index = Random.Range(0, target.Count);
            // Instantiate will activate the spawn process of my targets.
            Instantiate(target[index]);

        }

    }

    IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUptime);
            int Index = Random.Range(0, powerUps.Count);
            Instantiate(powerUps[Index]);
        }
        
    }
}
 
