using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class soundHaptics : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip selectFeedback;
    public AudioClip releaseFeedback;
    // Start is called before the first frame update

    [SerializeField]
    XRBaseController controllerL;
    [SerializeField]
    XRBaseController controllerR;

    public void HoveredL(){
        SendHaptics(controllerL);
    }

    public void HoveredR(){
        SendHaptics(controllerR);
    }

    public void SelectedL(){
        audioSource.PlayOneShot(selectFeedback);
        SendHaptics(controllerL);
    }

    public void SelectedR(){
        audioSource.PlayOneShot(selectFeedback);
        SendHaptics(controllerR);
    }

    public void ReleasedL(){
        audioSource.PlayOneShot(releaseFeedback);
        SendHaptics(controllerL);
    }

    public void ReleasedR(){
        audioSource.PlayOneShot(releaseFeedback);
        SendHaptics(controllerR);
    }

    void SendHaptics(XRBaseController controller){
        if (controller != null){
            controller.SendHapticImpulse(0.7f, 0.1f);
        }
    }
}
