using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Kill();
        }
    }
    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
