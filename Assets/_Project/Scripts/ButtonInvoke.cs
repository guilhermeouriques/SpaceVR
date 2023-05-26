using UnityEngine;
using UnityEngine.UI;

public class ButtonInvoke : MonoBehaviour {
    public float time = 1f;

    public void OnClick() {
        Invoke(nameof(After), time);
    }

    private void After() {
        GetComponent<Button>().enabled = !GetComponent<Button>().enabled;
    }
}
