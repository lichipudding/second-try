using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;

    public GameObject grenadePrefab;
    public Transform grenadeShootPoint;
    public float grenadeForce = 11f;
    public float grenadeRate;

    private float angle;
    public float volleyStart = 0.5f;
    public float volleyWait = 0.5f;
  



    public float bulletForce = 11f;

    public float FireRate;
    private float FireNotRate;

    private void Start()
    {
        //FireNotRate = FireRate;
        
        //InvokeRepeating("ShootVolley", volleyStart, volleyWait);
        
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && FireNotRate <= 0)
        {
            Shoot();
            FireNotRate = FireRate; 
        }

        else if (Input.GetButton("Fire2") && FireNotRate <= 0)

        {
            ShootGrenade();
            FireNotRate = grenadeRate;
        }

        else if (FireNotRate >0)
        {
            FireNotRate -= Time.deltaTime;
        }

        else if (Input.GetKey("q") && FireNotRate <= 0)

        {
            ShootVolley();
            FireNotRate = volleyStart;
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       
    }

    void ShootGrenade()
    {
        GameObject bullet = Instantiate(grenadePrefab, grenadeShootPoint.position, grenadeShootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(grenadeShootPoint.right * grenadeForce, ForceMode2D.Impulse);
    }

    void ShootVolley()
    {
        angle = 60f;
        for (int z = 0; z < 4; z++)
        {
            var volleyRotation = gameObject.transform.rotation;
            volleyRotation *= Quaternion.Euler(0, 9, angle);

            GameObject bullet = Instantiate(bulletPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), volleyRotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);
            angle = angle - 30f;
        }
    }

}
