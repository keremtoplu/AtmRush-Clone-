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



   public void AddStack(GameObject gameObject)
   {
      if(collecteds.Count==0)
      {
         gameObject.transform.position=player.transform.position+offSet;
      }
      else
      {
         gameObject.transform.position=collecteds[collecteds.Count-1].transform.position+offSet;
      }
      gameObject.transform.SetParent(player.transform);
      collecteds.Add(gameObject);
      StartCoroutine(MakeObjectsBigger());
      
   }


   private IEnumerator MakeObjectsBigger()
   {
      
      var scale=collecteds[0].transform.localScale;
      for (int i = collecteds.Count-1; i >=0 ; i--)
      {
         int index=i;
         collecteds[index].LeanScale(new Vector3(1,1,1),.1f).setOnComplete(()=>{collecteds[index].LeanScale(scale,.1f);});

         yield return new WaitForSeconds(0.05f);
      }


   }
   
}
