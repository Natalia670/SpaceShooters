using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemySpeed;
    private Rigidbody rig;
    private int counter = 0;
    public float xMin, xMax, yMin, yMax;
    // Start is called before the first frame update

    [Header("Shooting")]
    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;
    private float nextFire;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Start()
    {

        rig.velocity =  new Vector3(-1,0,0)* EnemySpeed;
        InvokeRepeating("LaunchBullet", 1.5f, fireRate);

    }


    private void FixedUpdate()
    {
        rig.velocity = new Vector3(-1, Random.Range(yMin, yMax), 0) * EnemySpeed;
    }


    // Update is called once per frame
    private void Update()
    {
        //Vector3 updown = new Vector3(, moveVertical, 0f);
       
    }

    void LaunchBullet()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        //rig.velocity = Random.insideUnitSphere * 5;
        //rig.position = new Vector3(Mathf.Clamp(rig.position.x, xMin, xMax), Mathf.Clamp(rig.position.y, yMin, yMax), 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        counter = counter + 1;
        //Destroy(other.gameObject);
        if (counter == 3)
        {

            Destroy(gameObject);
        }

    }

    
}
