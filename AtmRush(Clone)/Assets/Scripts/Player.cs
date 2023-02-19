using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float turnSpeed=1f;
    private Touch touch;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=Vector3.forward*Time.deltaTime;
        if(Input.touchCount>0)
        {
            Debug.Log("asd");
            touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Moved)
            {
                Debug.Log("asd");
                transform.position=new Vector3(transform.position.x+touch.deltaPosition.x*turnSpeed,transform.position.y,transform.position.z);
            }
        }
        Debug.Log(Input.touchCount);
    }


    private void OnTriggerEnter(Collider other) 
    {
        var collectable=other.gameObject.GetComponent<ICollectable>();
        if(collectable!=null)
        {
            collectable.Collect();
        }
    }
    
}
