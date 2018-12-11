using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;
    public int enemyHealth = 10;
    
    Transform player;
    NavMeshAgent navAgent;
    private Animator _anim;

    public GameObject playerObject;
    private Movement movementScript;


	// Use this for initialization
	void Start () {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        movementScript = FindObjectOfType<Movement>();
        player = playerObject.transform;

        _anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(player.position, transform.position);


        if(distance <= lookRadius)
        {
            navAgent.SetDestination(player.position);
            _anim.SetTrigger("Walk");

            if (distance <= navAgent. stoppingDistance)
            {
                
                //Face player
                FacePlayer();
            }
        }
        else
        {
            _anim.SetTrigger("Idle");
        }

        Die();
	}

    void Attack()
    {
        _anim.SetTrigger("Attack");
    }

    void Die()
    {
        if(enemyHealth == 0)
        {
            _anim.SetTrigger("Die");
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject, 3);
    }

    void FacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x , 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        //slerp - smooths movement
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            movementScript.playerHealth = movementScript.playerHealth - 1;
            _anim.SetTrigger("Attack");
            Debug.Log(movementScript.playerHealth);
        }
    }
}
