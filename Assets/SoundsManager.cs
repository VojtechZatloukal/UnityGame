using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{


    public static AudioClip hit, fireSound, silencerfireSound, deadSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        hit = Resources.Load<AudioClip>("hit");
        fireSound = Resources.Load<AudioClip>("gunShot");
        deadSound = Resources.Load<AudioClip>("deadSound");
        silencerfireSound = Resources.Load<AudioClip>("silencerShot");
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "fireE":
                audioSrc.PlayOneShot(fireSound);
                break;
            case "deadSound":
                audioSrc.PlayOneShot(deadSound);
                break;
            case "fireP":
                audioSrc.PlayOneShot(silencerfireSound);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
