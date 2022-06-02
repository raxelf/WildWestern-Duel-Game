using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D obj)
    {
        Destroy(gameObject);
        if (obj.gameObject.tag == "PlayerHead")
        {
            PlayerHealth.currentHealth = PlayerHealth.currentHealth - 75f;
        }
        else if (obj.gameObject.tag == "PlayerTorso")
        {
            PlayerHealth.currentHealth = PlayerHealth.currentHealth - 50f;
        }
        else if (obj.gameObject.tag == "PlayerArm")
        {
            PlayerHealth.currentHealth = PlayerHealth.currentHealth - 25f;
        }
        else if (obj.gameObject.tag == "PlayerLeg")
        {
            PlayerHealth.currentHealth = PlayerHealth.currentHealth - 15f;
        }
    }
}
