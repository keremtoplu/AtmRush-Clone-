using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=Vector3.forward*Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other) 
    {
        var collectable=other.gameObject.GetComponent<ICollectable>();
        if(collectable!=null)
        {
            collectable.Collect();
            Debug.Log("asd");
        }
    }
    
}
