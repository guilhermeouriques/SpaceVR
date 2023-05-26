using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class RecenterOrigin : MonoBehaviour {
    public InputActionProperty recenterButton;
    public Transform target;

    private void Update() {
        if (recenterButton.action.WasPressedThisFrame()) {
            Recenter();
        }
    }

    public void Recenter() {
        XROrigin xrOrigin = GetComponent<XROrigin>();

        //Vector3 targetPosition = new(target.position.x, target.position.y + xrOrigin.CameraInOriginSpaceHeight, target.position.z);
        //xrOrigin.MoveCameraToWorldLocation(targetPosition);

        xrOrigin.MoveCameraToWorldLocation(target.position);

        xrOrigin.MatchOriginUpCameraForward(target.up, target.forward);
    }
}
