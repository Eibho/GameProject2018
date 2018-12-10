 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Animator _animator;

    public float MaxSpeed = 5;

    private Rigidbody _rb;

    
    

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

}
