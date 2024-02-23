using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ABILITY_ActivateInteract : EtraAbilityBaseClass
{

    //Ability by: asour

    //Public variables
    [Header("Basics")]
    public float interactDistance = 2.0f; // The distance you can interact with an object

    //Private variables
    private ObjectInteraction previousObject; // Previous object gotten in the raycast
    bool holdingInteract = false;
    bool buttonPressed = false;

    [SerializeField] private Image cursorImage1;
    [SerializeField] private Image cursorImage2;

    [SerializeField] private bool isInteracting = false;

    //References
    StarterAssetsInputs starterAssetsInputs;
    ABILITY_CameraMovement camMoveScript;

    public override void abilityStart()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        camMoveScript = GameObject.Find("EtraAbilityManager").GetComponent<ABILITY_CameraMovement>();
    }

    private void switchCursorImage()
    {
        if (isInteracting)
        {
            cursorImage1.enabled = true;
        }
        else
        {
            cursorImage1.enabled = false;
        }
    }

    public override void abilityUpdate()
    {
        if (!enabled)
        {
            return;
        }
        //If the object is in range
        if (interactDistance > Vector3.Distance(camMoveScript.playerCameraRoot.transform.position, camMoveScript.pointCharacterIsLookingAt))
        {
            if (camMoveScript.raycastHit.transform.GetComponent<ObjectInteraction>()) //Check if the object has the ObjectInteraction script
            {
                //interactDistance
                ObjectInteraction interaction = camMoveScript.raycastHit.transform.GetComponent<ObjectInteraction>(); // Get the object's interaction script

                if (interaction.isInteractable)
                {
                    isInteracting = true;

                    if (previousObject != null)
                    {
                        if (previousObject != interaction)
                        {
                            interaction.onHover.Invoke(); // Call the previous object's onHover event
                            previousObject.onEndHover.Invoke(); // Call the previous object's onEndHover event
                        }
                    }
                    else
                    {
                        interaction.onHover.Invoke(); // Call the object's onHover event
                    }

                    previousObject = interaction; // Set the previous object to the current object

                    GameObject objectThatIsLookedAt = camMoveScript.raycastHit.transform.gameObject;

                    if (starterAssetsInputs.interact)
                    {
                        holdingInteract = true;
                        buttonPressed = true;
                        // Interact with the object
                        objectThatIsLookedAt.transform.gameObject.GetComponent<ObjectInteraction>().Interact();
                    }
                    else
                    {
                        holdingInteract = false;
                    }

                    if (buttonPressed == true && holdingInteract == false)
                    {
                        buttonPressed = false;
                        // End the interaction with the object
                        objectThatIsLookedAt.transform.gameObject.GetComponent<ObjectInteraction>().onEndInteract.Invoke();
                        objectThatIsLookedAt.transform.gameObject.GetComponent<ObjectInteraction>().Press();
                    }

                }
                else
                {

                    if (previousObject != null)
                    {
                        previousObject.onEndHover.Invoke(); // Call the previous object's onEndHover event
                        previousObject.onEndInteract.Invoke(); // Call the previous object's onEndInteract event
                    }

                    previousObject = null; // Set the previous object to null
                    isInteracting = false;
                }
            }
        }
        else
        {
            isInteracting = false;
            if (previousObject != null)
            {
                previousObject.onEndHover.Invoke(); // Call the previous object's onEndHover event
                previousObject.onEndInteract.Invoke(); // Call the previous object's onEndInteract event
            }

            previousObject = null; // Set the previous object to null
        }
        switchCursorImage();
    }
}


