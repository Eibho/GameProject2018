using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;
   

    Transform player;
    NavMeshAgent navAgent;
    private Animator _anim;

    public GameObject playerObject;


	// Use this for initialization
	void Start () {
        playerObject = GameObject.FindGameObjectWithTag("Player");
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
	}

    void Attack()
    {
        _anim.SetTrigger("Attack");
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

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            _anim.SetTrigger("Attack");
        }
    }
}
