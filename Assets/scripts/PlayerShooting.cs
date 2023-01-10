using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using Assets.scripts;
using UnityEngine;

public class PlayerShooting : Shooting
{

   



    
    // Update is called once per frame
    void Update()
    {


        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenBullets)
            {
                 
                    canFire = true;
                    timer = 0;

            }
        }

        if (Input.GetMouseButton(0) && canFire == true)
        {
            canFire = false;

            CreateBulletAndShootIt(firePoint, bulletPrefab);
        }
    }


  
}
