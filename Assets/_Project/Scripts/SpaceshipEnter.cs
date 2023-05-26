using UnityEngine;

public class SpaceshipEnter : MonoBehaviour {
    [SerializeField] private bool enter;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (enter) {
                other.transform.SetParent(transform.parent);
            } else {
                other.transform.SetParent(null);
            }
        }
    }
}
