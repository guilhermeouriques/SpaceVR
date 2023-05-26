using UnityEngine;

public class ChangeRigs : MonoBehaviour {
    public GameObject XRRigToEnable;
    public GameObject XRRigToDisable;
    public GameObject[] buttonsToEnable;
    public GameObject[] buttonsToDisable;
    public bool resetEnabledRigPosition;

    public void Change(float delay) {
        if (delay <= 0) {
            DoChange();
        } else {
            Invoke(nameof(DoChange), delay);
        }
    }

    private void DoChange() {
        XRRigToEnable.SetActive(true);
        XRRigToDisable.SetActive(false);

        foreach (GameObject button in buttonsToEnable) {
            button.SetActive(true);
        }

        foreach (GameObject button in buttonsToDisable) {
            button.SetActive(false);
        }

        if (resetEnabledRigPosition) {
            XRRigToEnable.transform.position = XRRigToDisable.transform.position;
            XRRigToEnable.transform.rotation = XRRigToDisable.transform.rotation;
        }
    }
}
