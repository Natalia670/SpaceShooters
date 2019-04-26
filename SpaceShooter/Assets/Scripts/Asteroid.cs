using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float AsteroidSpeed;
    private Rigidbody rig;
    private int counter = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Start()
    {

        rig.velocity = Vector3.left * AsteroidSpeed;
    }


    // Update is called once per frame
    private void Update()
    {
        rig.velocity = Vector3.left * AsteroidSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        counter = counter + 1;
        //Destroy(other.gameObject);
        if (counter == 5)
        {
    
            Destroy(gameObject);
        }
       
    }
}
