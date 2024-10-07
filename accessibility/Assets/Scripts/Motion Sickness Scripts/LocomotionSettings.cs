using UnityEngine;

   public class LocomotionSettings : MonoBehaviour
   {
       public ActionBasedContinuousMoveProvider continuousMoveProvider;
       public TeleportationProvider teleportationProvider;

       public void SetLocomotionType(bool useSmoothLocomotion)
       {
           continuousMoveProvider.enabled = useSmoothLocomotion;
           teleportationProvider.enabled = !useSmoothLocomotion;
       }
   }