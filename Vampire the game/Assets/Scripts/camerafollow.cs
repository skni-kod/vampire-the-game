using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    private float moveSpeed = 0f;

    Vector3 randomPos = Vector3.zero;
    float randomTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        randomTimer -= Time.deltaTime;

        if (randomTimer <= 0f)
        {
            randomTimer = 2;
            randomPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), transform.position.z);
        }

       
    }
}