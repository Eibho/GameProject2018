
using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 1000f;

    public GameObject gun;

    private EnemyController enemy;

    public Bullet bullet;
    public Transform firePoint;

    private void Start()
    {
        enemy = FindObjectOfType<EnemyController>();
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(enemy.enemyHealth);
            Shoot(); 

        }
    }

    void Shoot()
    {
        Bullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Bullet;

        RaycastHit hit;


        if(Physics.Raycast(gun.transform.position, gun.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            
        }
    }
}
