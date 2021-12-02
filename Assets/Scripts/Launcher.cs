using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject BirdPrefab;
    public float speed = 15.0f;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject obj = Instantiate(BirdPrefab);
            obj.GetComponent<Rigidbody>().position = transform.position;
            obj.GetComponent<Rigidbody>().velocity = transform.forward * speed; // forward: camera 所面向的前方
            Destroy(obj, 3.0f);
        }
    }
}