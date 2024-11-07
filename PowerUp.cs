using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Rigidbody powerUP;

    // Start is called before the first frame update
    void Start()
    {
        powerUP = GetComponent<Rigidbody>();

        powerUP.AddForce(Vector3.up * Random.Range(7, 10), ForceMode.Impulse);
        powerUP.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        powerUP.transform.position = new Vector3(Random.Range(-1.52f, 1.38f), -3.37f, -3.02f);
    }

    
    // Update is called once per frame
    void Update()
    {
        if(powerUP.position.y < -3.45f)
        {
            Destroy(gameObject);
            Debug.Log("PowerUpDestroyed");
        }
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
