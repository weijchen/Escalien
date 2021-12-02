using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float cubeSize = 0.1f;
    public int cubesInRow = 10;
    float cubesPivotDistance;
    Vector3 cubesPivot;
    float explosionRadius = 4.0f;
    float explosionForce = 100.0f;
    float explosionUpward = 0.4f;
    float fadeTime = 3.0f;

    private void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            explode();
    }

    public void explode()
    {
        // make object explode
        // Destroy(this.gameObject);
        gameObject.SetActive(false);

        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        // get explosion position
        Vector3 explosionPos = transform.position;
        // get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        // add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            // get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void createPiece(int x, int y, int z)
    {
        // create piece
        GameObject piece;

        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.tag = "Untagged";
        piece.GetComponent<MeshRenderer>().material.color = Color.yellow;

        // set piece position and scale
        piece.transform.position =
            transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        // add ridigbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        Destroy(piece, fadeTime);
    }
}