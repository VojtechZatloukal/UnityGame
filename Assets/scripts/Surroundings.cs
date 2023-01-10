using Assets.InterFaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surroundings : MonoBehaviour, IHittable
{
    public void GotShot()
    {
        Debug.Log("au");
        Object.Destroy(this);
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
