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
    public float volleyRate = 0.5f;
    
  



    public float bulletForce = 11f;

    public float FireRate;
    private float FireNotRate;

    private float GrenadeFireNotRate;
    private float VolleyFireNotRate;

    private void Start()
    {
      
        
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && FireNotRate <= 0)
        {
            Shoot();
            FireNotRate = FireRate; 
        }

        else if (Input.GetButton("Fire2") && GrenadeFireNotRate <= 0)

        {
            ShootGrenade();
            GrenadeFireNotRate = grenadeRate;
        }

        else if (FireNotRate >0)
        {
            FireNotRate -= Time.deltaTime;
        }

        else if (Input.GetKey("q") && VolleyFireNotRate <= 0)

        {
            ShootVolley();
            VolleyFireNotRate = volleyRate;
        }

        else if (GrenadeFireNotRate > 0)
        {
            GrenadeFireNotRate -= Time.deltaTime;
        }

        else if (VolleyFireNotRate > 0)
        {
            VolleyFireNotRate -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);
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
            volleyRotation *= Quaternion.Euler(0, 0, angle);

            GameObject bullet = Instantiate(bulletPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), volleyRotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);
            angle = angle - 30f;
        }
    }

}
