using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
    int Range;
    public float projectileFireRate;
    float timeSinceLastFire;
    Shoot shootScript;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        shootScript = GetComponent<Shoot>();
        shootScript.OnProjectileSpawned.AddListener(UpdateTimeSinceLastFire);
    }
    private void OnDisable()
    {
        shootScript.OnProjectileSpawned.RemoveListener(UpdateTimeSinceLastFire);
    }
    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] currentClips = anim.GetCurrentAnimatorClipInfo(0);
        if (currentClips[0].clip.name != "Fire"){
            if (Time.time >= timeSinceLastFire + projectileFireRate){
                anim.SetTrigger("Fire"); 
            }
        }
    }

    void OnTriggerEnter2D(){
        if (Collider.gameObject.tag == "Range"){
            anim.SetTrigger("Fire");
        }
    }

    public override void Death()
    {
        Destroy(gameObject);
    }

    void UpdateTimeSinceLastFire()
    {
        timeSinceLastFire = Time.time;
    }
    
}
