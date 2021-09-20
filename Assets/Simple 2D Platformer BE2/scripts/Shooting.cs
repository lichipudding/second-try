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



    public float bulletForce = 11f;

    public float FireRate;
    private float FireNotRate;

    private void Start()
    {
        FireNotRate = FireRate;
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

    void ShootWolley()
    {

    }

}
