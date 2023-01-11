using Assets.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts
{
    internal class BulletBehaviour : MonoBehaviour
    {

        
     

        private void OnCollisionEnter2D(Collision2D collision)
        {
         

            
               
            
            var hittable = collision.gameObject.GetComponent<IHittable>();

            
            if (hittable != null)
            {

                hittable.GotShot();

                

            }
            if (collision.gameObject.tag == "Wall")
            {
                SoundsManager.PlaySound("hit");
            }
            Destroy(this.gameObject);
        }
        //private void OnTriggerEnter2D(Collider collision)
        //{
        //    Debug.Log("naraz");

        //    var hittable = collision.gameObject.GetComponent<IHittable>();

        //    if (hittable != null)
        //    {

        //        hittable.GotShot();



        //    }
        //    Destroy(gameObject);
        //}
    }
}
