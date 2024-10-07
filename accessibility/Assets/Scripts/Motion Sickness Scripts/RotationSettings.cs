using UnityEngine;

   public class RotationSettings : MonoBehaviour
   {
       public ActionBasedContinuousTurnProvider smoothTurnProvider;
       public ActionBasedSnapTurnProvider snapTurnProvider;

       public void SetRotationType(bool useSmooth)
       {
           smoothTurnProvider.enabled = useSmooth;
           snapTurnProvider.enabled = !useSmooth;
       }
   }