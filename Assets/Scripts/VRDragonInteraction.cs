using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

/// <summary>
/// Attach this to the Charizard prefab alongside an XRGrabInteractable.
/// It triggers the fly animation when the dragon is grabbed and resets on release.
/// </summary>
[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(Animator))]
public class VRDragonInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Animator animator;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        animator.SetBool("flyParam", true);
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        animator.SetBool("flyParam", false);
    }
}
