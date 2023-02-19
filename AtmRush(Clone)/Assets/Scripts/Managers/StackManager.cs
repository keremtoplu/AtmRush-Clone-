using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
   [SerializeField]
   private Vector3 offSet;
   
   [SerializeField]
   private List<GameObject> collecteds=new List<GameObject>();

   [SerializeField]
   private Player player;


   
   public List<GameObject> Collecteds=>collecteds;

   public void AddStack(GameObject gameObject)
   {
      gameObject.transform.position=collecteds[collecteds.Count-1].transform.position+offSet;
      gameObject.transform.SetParent(player.transform);
      collecteds.Add(gameObject);
      MakeObjectsBigger();
      
   }


   private void MakeObjectsBigger()
   {
      
      var scale=collecteds[0].transform.localScale;
      for (int i = collecteds.Count-1; i <=0 ; i--)
      {
         collecteds[i].LeanScale(new Vector3(2,2,2),2f).setOnComplete(()=>{collecteds[i].LeanScale(scale,2f);});
      }
   }
   
}
