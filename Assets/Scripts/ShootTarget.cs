using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{
    public int maxIter = 3;
    public static int curIter = 0;
    public GameObject obj;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && curIter < maxIter)
        {
            curIter += 1;
            if (curIter < maxIter)
            {
                Vector3 pos = new Vector3(transform.position.x - 3.0f, transform.position.y,
                    transform.position.z - 3.0f);
                GameObject obj = Instantiate(this.gameObject, pos, transform.rotation);
            }

            if (curIter == 3)
            {
                obj.SetActive(true);
            }

            Destroy(this.gameObject);
        }
    }
}