using Assets.scripts;
using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class Shooting : VersionedMonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;
        public bool canFire = true;
        public float timer;
        public float timeBetweenBullets;


        public void CreateBulletAndShootIt(Transform FirePoint, GameObject bulletObject)
        {


            GameObject bullet = Instantiate(bulletObject, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * Constants.bulletSpeed, ForceMode2D.Impulse);
        }
        
    }
}
