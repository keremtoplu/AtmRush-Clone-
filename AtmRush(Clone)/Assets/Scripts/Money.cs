using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour,ICollectable
{
    [SerializeField]
    private StackManager stackManager;

    [SerializeField]
    private int maxElementOfMoney=3;

    private int currentLevel;
    void Start()
    {
      currentLevel=1;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect()
    {
        stackManager.AddStack(gameObject);
    }


    private void OnTriggerEnter(Collider other) 
    {
        var atm=other.GetComponent<Atm>();
        if(atm!=null)
        {
            transform.SetParent(null);
            transform.LeanMove(atm.transform.position,.1f).setOnComplete(()=>{gameObject.SetActive(false);});
            transform.LeanScale(transform.localScale/2,.1f);
        }

        var gate=other.GetComponent<Gate>();
        var scale=transform.localScale;
        if(gate!=null)
        {
            if(currentLevel<=maxElementOfMoney)
            {
                transform.GetChild(currentLevel-1).gameObject.SetActive(true);
                currentLevel++;
            }
            transform.LeanScale(new Vector3(1,1,1),.1f).setOnComplete(()=>{transform.LeanScale(scale,.1f);});
        }
    }
}
