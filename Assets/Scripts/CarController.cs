using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody carRB;

    public float accel = 8f, reverse = 4f, topSpeed = 50f, turnStrength = 180; 

    private float speedInput, turnInput;

    public float playerArmor = 100f;

    void Start()
    {
        carRB.transform.parent = null;
    }

    void Update()
    {
        speedInput = 0f;
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            speedInput = Input.GetAxisRaw("Vertical") * accel * 75f;
        } else if (Input.GetAxisRaw("Vertical") < 0)
        {
            speedInput = Input.GetAxisRaw("Vertical") * reverse * 50f;
        }

        turnInput = Input.GetAxisRaw("Horizontal");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime  * 0.5f, 0f));

            transform.position = carRB.transform.position;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(speedInput) > 0)
        {
            carRB.AddForce(transform.forward * speedInput);
        }
    }

    public void TakeDamage(float amount)
    {
        playerArmor -= amount;

        if (playerArmor <= 0f)
        {
            Time.timeScale = 0f;
        }
    }
}
