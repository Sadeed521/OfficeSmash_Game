using UnityEngine;

public class Targets : MonoBehaviour
{
    
    private Rigidbody targetRb;
    private float minSpeed = 7f;
    private float maxSpeed = 10f;
    private float maxTorque = 10;
    private float posX = 1.38f;
    private float posXneg = 1.52f;
    private float posY = 3.37f;
    private float posZ = 3.02f;

    // Start is called before the first frame update
    void Start()
    { 
        
        targetRb = GetComponent<Rigidbody>();
        Debug.Log(targetRb);

        targetRb.AddForce( RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());

        transform.position = RandomSpawn();
    }

    private void TargetOutBound()
    {
        if (targetRb.position.y <= -4) 
        {
            Destroy(gameObject);
           Debug.Log("Target destroyed");
        }
       
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        
    }
    // Update is called once per frame
    void Update()
    {
        TargetOutBound();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-posXneg, posX), -posY, -posZ);
    }
}
