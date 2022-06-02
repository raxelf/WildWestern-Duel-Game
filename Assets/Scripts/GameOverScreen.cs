using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text resultText;
    public GameObject GameOver;

    public void Start()
    {
        PlayerHealth.isDie = false;
        EnemyHealth.isDie = false;
    }

    public void Update()
    {
        if (PlayerHealth.isDie == true || EnemyHealth.isDie == true)
        {
            GameOver.SetActive(true);
            if (PlayerHealth.isDie == true)
            {
                resultText.text = "DEFEAT!";
            }
            else if (EnemyHealth.isDie == true)
            {
                resultText.text = "VICTORY!";
            }
        }
        else
        {
            GameOver.SetActive(false);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
