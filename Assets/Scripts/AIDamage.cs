using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIDamage : MonoBehaviour
{
    public float armor = 200f;
    public ParticleSystem smoke;

    public void TakeDamage (float amount)
    {
        armor -= amount;

        if (armor <= 0)
        {
            GetComponent<NavMeshAgent>().speed = 0;
            Debug.Log("Stopped!");
            smoke.Play();
            EndgameUI.scoreValue += 1;
        }
    }
}
