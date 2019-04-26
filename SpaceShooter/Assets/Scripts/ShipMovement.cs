using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{

    public Text gameOver;
    

    [Header("Movement")]
    public float shipSpeed = 6;
    private Rigidbody rig;
    public float xMin, xMax, yMin, yMax;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate;
    private float nextFire;

    [Header("HP")]
    private int life = 5;
    SpriteRenderer m_SpriteRenderer;
    public Text hp;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        gameOver.gameObject.SetActive(false);

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }

    }


    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        rig.velocity = movement * shipSpeed;
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, xMin, xMax), Mathf.Clamp(rig.position.y, yMin, yMax), 0f);

    }

    private void OnTriggerEnter(Collider other)
    {
        life = life -1;
        hp.text = "HP: " + life.ToString();
        StartCoroutine(ChangeColor());
        if (life <= 0)
        {
            Destroy(gameObject);
            gameOver.gameObject.SetActive(true);
        }

    }

    IEnumerator ChangeColor()
    {

        m_SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1);
        m_SpriteRenderer.color = Color.white;
    }


}
