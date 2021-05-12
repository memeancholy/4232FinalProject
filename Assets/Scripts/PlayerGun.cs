using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public GameObject barrel;
    public ParticleSystem gunfire;

    private float nextTimeToFire = 0f;
    private AudioSource gunSound;

    private void Start()
    {
        gunSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        gunfire.Play();
        gunSound.Play();

        RaycastHit hit;

        if (Physics.Raycast(barrel.transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            Debug.Log(hit.transform.name);

            AIDamage damaged = hit.transform.GetComponent<AIDamage>();
            if (damaged != null)
            {
                damaged.TakeDamage(damage);
            }
        }
    }
    
}
