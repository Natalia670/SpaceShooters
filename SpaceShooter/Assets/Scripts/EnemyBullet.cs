using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody rig;
    public bool enter = true;
    // Start is called before the first frame update

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Start()
    {

        rig.velocity = Vector3.left * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);

    }
}
