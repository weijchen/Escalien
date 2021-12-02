using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    Player player;
    Ball ball;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.ResetDamage();
            ball.SetScore(0);
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            player.ResetDamage();
            ball.SetScore(0);
            SceneManager.LoadScene(0);
        }
    }
}