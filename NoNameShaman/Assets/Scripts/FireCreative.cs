using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCreative : MonoBehaviour
{
    public GameObject Fire;
    public float fireCreativeTimmer = 1f;
    public float Timmer = 0f;

    public AudioSource AudioS;

    void Update()
    {
        Timmer -= Time.deltaTime;
        if(Timmer < 0)
        {
           AudioS.Play();
           Instantiate(Fire,new Vector3(Random.Range(-4.30f,4.30f),11,0),Quaternion.Euler(0,0,0));
           Timmer = fireCreativeTimmer;    
        }   
    }   
}
