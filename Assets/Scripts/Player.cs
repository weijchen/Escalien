using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] string loseSceneName;

    [SerializeField] Text healthText;
    [SerializeField] int maxHealth = 100;
    [SerializeField] float startX;
    [SerializeField] float startY;
    [SerializeField] float startZ;

    [SerializeField] static int damage;
    [SerializeField] bool hit = false;

    private void Start()
    {
        startX = gameObject.transform.position.x;
        startY = gameObject.transform.position.y;
        startZ = gameObject.transform.position.z;
    }

    private void Update()
    {
        healthText.text = "Health: " + (maxHealth - damage);
        hit = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Hell")
        {
            if (!hit)
            {
                damage += 20;
                hit = true;
            }

            if (damage == maxHealth)
            {
                SceneManager.LoadScene(loseSceneName);
            }
            else
            {
                this.gameObject.transform.position = new Vector3(startX, startY, startZ);
            }
        }
    }

    public void ResetDamage()
    {
        damage = 0;
    }
}