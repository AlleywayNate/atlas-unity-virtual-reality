   using UnityEngine;
   using UnityEngine.Rendering;
   using UnityEngine.Rendering.Universal;

   public class VignetteController : MonoBehaviour
   {
       public Volume volume;
       private Vignette vignette;

       void Start()
       {
           volume.profile.TryGet(out vignette);
       }

       public void SetVignetteIntensity(float intensity)
       {
           vignette.intensity.value = intensity;
       }
   }
