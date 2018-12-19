 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    public float MaxSpeed = 5;

    private Animator _animator;
    private Rigidbody _rb;
    public int playerHealth = 50;

    public Gun gun;

    // Use this for initialization
    void Start () {

        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
       

    }
	
	// Update is called once per frame
	void Update () {

        if (_animator == null) return;

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        
        Move(x, y);
        Jump();
        Shoot();
        if(playerHealth == 0)
        {
            _animator.SetTrigger("Die");
            Invoke("LoadScene", 5f);
        }


    }


    private void Move(float x, float y)
    {

        _animator.SetFloat("VelX", x);
        _animator.SetFloat("VelY", y);

        transform.position += Vector3.right * MaxSpeed * x * Time.deltaTime; // x = VelX
        transform.position += Vector3.forward * MaxSpeed * y * Time.deltaTime; // y = VelY
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
        }
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger("Shoot");
          
        }
    }

    private void Die()
    {
        if(playerHealth == 0)
        {
            _animator.SetTrigger("Die");
            Invoke("LoadScene", 5f);
        }
    }

   private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

    


