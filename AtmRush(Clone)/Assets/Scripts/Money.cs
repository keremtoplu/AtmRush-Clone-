using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour,ICollectable
{
    [SerializeField]
    private StackManager stackManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect()
    {
        stackManager.AddStack(gameObject);
    }
}
