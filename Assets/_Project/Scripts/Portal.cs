using UnityEngine;

public class Portal : MonoBehaviour {
    public string playerTag = "Spaceship";

    public GameObject enabledGameObject;
    public GameObject disabledGameObject;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(playerTag)) {
            GameManager.Instance.OnPortalTrigger();
        }
    }

    public void SetPortalStatus(bool status) {
        enabledGameObject.SetActive(status);
        disabledGameObject.SetActive(!status);
        GetComponent<BoxCollider>().enabled = status;
    }
}
