using Assets.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts
{
    internal class EnemyDeathBehaviour : MonoBehaviour, IHittable
    {
        public GameObject effect;
        public void GotShot()
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            SoundsManager.PlaySound("deadSound");
            Destroy(this.gameObject);
        }

        
    }
}
