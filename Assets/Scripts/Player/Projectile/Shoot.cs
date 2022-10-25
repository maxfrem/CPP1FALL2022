using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    SpriteRenderer sr;
    public float projectileSpeed;
    public Transform spawnPointRight;
    public Transform spawnPointLeft;
    public Projectile projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
       sr = GetComponent<SpriteRenderer>();

       if (projectileSpeed <= 0)
            projectileSpeed = 7.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Please Setup default calues on:" + gameObject.name); 
    }

    // Update is called once per frame
    public void Fire()
    {
        if (!sr.flipX)
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointRight.position,)
        }
    }
}
