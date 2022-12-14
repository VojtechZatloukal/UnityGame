using System;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            Shoot();
        }
    }
    private void Shoot()
    {
        Console.WriteLine("Shooting");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D rb =  bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * Constants.bulletSpeed, ForceMode2D.Impulse);
    }

}
