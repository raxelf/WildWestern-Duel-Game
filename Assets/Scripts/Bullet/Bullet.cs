using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D obj)
    {
        Destroy(gameObject);
        if (obj.gameObject.tag == "EnemyHead")
        {
            EnemyHealth.currentHealth = EnemyHealth.currentHealth - 75f;
        }
        else if (obj.gameObject.tag == "EnemyTorso")
        {
            EnemyHealth.currentHealth = EnemyHealth.currentHealth - 50f;
        }
        else if (obj.gameObject.tag == "EnemyArm")
        {
            EnemyHealth.currentHealth = EnemyHealth.currentHealth - 25f;
        }
        else if (obj.gameObject.tag == "EnemyLeg")
        {
            EnemyHealth.currentHealth = EnemyHealth.currentHealth - 15f;
        }
    }
}
