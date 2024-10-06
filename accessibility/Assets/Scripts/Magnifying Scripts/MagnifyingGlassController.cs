    using UnityEngine;
    using UnityEngine.XR.Interaction.Toolkit;

    public class MagnifyingGlassController : MonoBehaviour
    {
        public GameObject magnifyingGlass; // Reference to the magnifying glass GameObject
        public XRController controller; // Reference to the XR Controller (e.g., LeftHand or RightHand)
        public InputHelpers.Button activationButton = InputHelpers.Button.PrimaryTrigger; // Button to toggle magnifier
        public float activationThreshold = 0.1f; // Threshold for button press
        public AudioClip activationSound;
        public AudioClip deactivationSound;
        private AudioSource audioSource;

        private bool isMagnifierActive = false;
        private bool wasPressedLastFrame = false;

        void Start()
        {
            if (magnifyingGlass != null)
            {
                magnifyingGlass.SetActive(false); // Initially inactive
            }

            audioSource = gameObject.AddComponent<AudioSource>();
        }

        void Update()
        {
            if (controller)
            {
                InputHelpers.IsPressed(controller.inputDevice, activationButton, out bool isPressed, activationThreshold);

                if (isPressed && !wasPressedLastFrame)
                {
                    ToggleMagnifier();
                }

                wasPressedLastFrame = isPressed;
            }
        }

        public void ToggleMagnifier()
        {
            isMagnifierActive = !isMagnifierActive;
            magnifyingGlass.SetActive(isMagnifierActive);

            if (isMagnifierActive && activationSound != null)
            {
                audioSource.PlayOneShot(activationSound);
            }
            else if (!isMagnifierActive && deactivationSound != null)
            {
                audioSource.PlayOneShot(deactivationSound);
            }
        }
    }