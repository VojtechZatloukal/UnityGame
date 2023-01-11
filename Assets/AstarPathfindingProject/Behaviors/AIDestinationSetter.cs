using UnityEngine;
using System.Collections;
using UnityEngine.Accessibility;
using System;
using Codice.Client.BaseCommands.BranchExplorer;
using System.Linq;

namespace Pathfinding
{
    /// <summary>
    /// Sets the destination of an AI to the position of a specified object.
    /// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
    /// This component will then make the AI move towards the <see cref="target"/> set on this component.
    ///
    /// See: <see cref="Pathfinding.IAstarAI.destination"/>
    ///
    /// [Open online documentation to see images]
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class AIDestinationSetter : VersionedMonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>
        public Transform target;
        private float visionDistance = 15;
        public Transform firePoint;
        private bool folowP = false;
        IAstarAI ai;
        public  AudioClip fire;
        public AudioSource audioSrc;

        public GameObject bulletPrefab;
        public bool canFire = true;
        private float timer;
        public float timeBetweenBullets;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        public void CreateBulletAndShootIt(Transform FirePoint, GameObject bulletObject, Quaternion rotation = new Quaternion(), Vector3 way = new Vector3())
        {
            var bullet = Instantiate(bulletObject, FirePoint.position, rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            audioSrc.PlayOneShot(fire);
            rb.AddForce(way * 15f, ForceMode2D.Impulse);
        }

        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            if (ai != null) ai.onSearchPath += Update;
        }

        void OnDisable()
        {
            if (ai != null) ai.onSearchPath -= Update;
        }

        /// <summary>Updates the AI's destination every frame</summary>
        void Update()
        {
            //Debug.DrawLine(firePoint.position, target.position, Color.blue);
            //CreateBulletAndShootIt(firePoint, bulletPrefab, firePoint.rotation, target.position - firePoint.position);
            //  transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            var emitFrontVector = firePoint.position- this.transform.position  ;
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position,target.position - firePoint.position , visionDistance);
            //Debug.DrawLine(firePoint.position, Quaternion.AngleAxis(30, Vector3.forward) * emitFrontVector, Color.green);
            //Debug.DrawLine(firePoint.position, Quaternion.AngleAxis(-30, Vector3.forward) * emitFrontVector, Color.green);
            //Debug.DrawLine(firePoint.position, emitFrontVector, Color.green);

            if (hitInfo.collider != null)
            {
               
                if (hitInfo.collider.tag == "Player")
                {
                   
                    var smtin = target.position - firePoint.position;

                    var a = Vector3.Angle(smtin, emitFrontVector);

                    if (a < 60 && a > -60)
                    {
                        //Debug.DrawLine(firePoint.position, target.position, Color.red);
                        folowP = true;
                    }
                }
            }
            if (folowP)
            {
                var toRotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
                toRotation *= Quaternion.Euler(0, 0, 90); ;
                transform.rotation = toRotation;
                if (target != null && ai != null) ai.destination = target.position;
               
                if (!canFire)
                {
                  
                    timer += Time.deltaTime;
                    if (timer > timeBetweenBullets)
                    {

                        canFire = true;
                        timer = 0;

                    }
                }
                else
                {
                   
                    canFire = false;
                    CreateBulletAndShootIt(firePoint, bulletPrefab, toRotation, target.position - firePoint.position);
                }


            }


        }
      
    }
}
