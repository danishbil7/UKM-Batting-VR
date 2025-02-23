using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerGrab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Book"))
        {
            grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.onSelectEntered.AddListener(OnGrab);
                grabInteractable.onSelectExited.AddListener(OnRelease);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Book"))
        {
            if (grabInteractable != null)
            {
                grabInteractable.onSelectEntered.RemoveListener(OnGrab);
                grabInteractable.onSelectExited.RemoveListener(OnRelease);
                grabInteractable = null;
            }
        }
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        grabInteractable.GetComponent<LibraryTask>().GrabBook();
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        grabInteractable.GetComponent<LibraryTask>().ReleaseBook();
    }
}