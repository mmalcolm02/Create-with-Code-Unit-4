using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRB;
    public float enemySpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * enemySpeed);

            if (transform.position.y < -5)
            {
                Destroy(gameObject);
            }
        

    }
}
