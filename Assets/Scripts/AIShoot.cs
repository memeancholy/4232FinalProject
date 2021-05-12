using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    public bool inSights;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public GameObject barrel1;
    public GameObject barrel2;
    public ParticleSystem gunfire1;
    public ParticleSystem gunfire2;

    private float nextTimeToFire = 0f;
    private AudioSource gunSound;

    // Start is called before the first frame update
    void Start()
    {
        gunSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inSights == true && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            EnemyShoot();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inSights = true;
            Debug.Log("Bang!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inSights = false;
        }
    }

    void EnemyShoot()
    {
        gunfire1.Play();
        gunSound.Play();

        RaycastHit hit;

        if (Physics.Raycast(barrel1.transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            Debug.Log(hit.transform.name);

            CarController hurt = hit.transform.GetComponent<CarController>();
            if (hurt != null)
            {
                hurt.TakeDamage(damage);
            }
        }
    }
}
