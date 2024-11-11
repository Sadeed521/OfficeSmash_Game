using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    private Rigidbody powerUP;

    public enum PowerUpType { TimeFreeze, MoneyBag, DoublePoints }
    public PowerUpType powerUpType; // Set this in the Inspector for each PowerUp object
   
    private GameManager gameManager; // Reference to GameManager for effects

    void Start()
    {
        powerUP = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>(); // Find GameManager script
        powerUP.AddForce(Vector3.up * Random.Range(7, 10), ForceMode.Impulse);
        powerUP.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        powerUP.transform.position = new Vector3(Random.Range(-1.52f, 1.38f), -3.37f, -3.02f);
    }

    void Update()
    {
        if (powerUP.position.y < -3.45f)
        {
            Destroy(gameObject);
            Debug.Log("PowerUpDestroyed");
        }
    }

    private void OnMouseDown()
    {
        CollectPowerUp();
        Destroy(gameObject);
    }

    private void CollectPowerUp()
    {
        switch (powerUpType)
        {
            case PowerUpType.TimeFreeze:
                gameManager.freezeButton.interactable=true;
                gameManager.ButtonColourVisibility(true);
                Debug.Log("Freeze Ability selected.");
                break;
            case PowerUpType.MoneyBag:
                gameManager.CollectMoneyBag();
                Debug.Log("Collected MoneyBag");
                break;
            case PowerUpType.DoublePoints:
                gameManager.CollectDoublePoints();
                Debug.Log("double points.");
                break;
        }
    }
}


