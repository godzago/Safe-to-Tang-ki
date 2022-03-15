using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject dirt;
    public GameObject Fire;
    void Start()
    {
        
    }
    void Update()
    {
      
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(Fire.gameObject);
    }
    

}

