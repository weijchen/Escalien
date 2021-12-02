using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject airCraft;
    [SerializeField] GameObject hiddenBrick;
    [SerializeField] GameObject hiddenRoad;
    [SerializeField] GameObject openDoor;
    [SerializeField] AudioClip _audioClip;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] bool hit = false;
    [SerializeField] Text scoreBoard;
    [SerializeField] static int score = 0;


    private void Update()
    {
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (score == 5 && curSceneIndex == 0)
        {
            airCraft.SetActive(true);
        }

        if (score == 12 && curSceneIndex == 1)
        {
            hiddenBrick.GetComponent<BoxCollider>().enabled = false;
        }

        if (score == 15 && curSceneIndex == 1)
        {
            hiddenRoad.SetActive(true);
        }

        if (score > 25 && curSceneIndex == 2)
        {
            openDoor.SetActive(true);
        }

        if (scoreBoard)
        {
            scoreBoard.text = "Score: " + score;
        }
    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("obstacles") && !hit)
        {
            score += 1;
            hit = true;
            _audioSource.PlayOneShot(_audioClip);
            gameObject.GetComponent<MeshRenderer>().transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            Destroy(gameObject, 3.0f);
        }
    }
}