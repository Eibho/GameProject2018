using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    private EnemyController enemy;

    // Use this for initialization
    void Start()
    {
        enemy = FindObjectOfType<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 5);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject,0.2f);
            Debug.Log("Hit");
            enemy.enemyHealth = enemy.enemyHealth - 1;
        }
        
    }
}

    
