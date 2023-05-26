using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int portalIndex { get; private set; }

    [SerializeField] private GameObject portalsContainer;
    private Portal[] portals;

    private void OnEnable() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        portalIndex = 0;

        portals = portalsContainer.GetComponentsInChildren<Portal>();
        ResetPortals();
        EnableCurrentPortal();
    }

    private void ResetPortals() {
        foreach (Portal portal in portals) {
            portal.SetPortalStatus(false);
        }
    }

    private bool EnableCurrentPortal() {
        if (portalIndex < portals.Length) {
            portals[portalIndex].SetPortalStatus(true);

            return true;
        }

        return false;
    }

    public void OnPortalTrigger() {
        portalIndex++;

        ResetPortals();
        EnableCurrentPortal();
    }
}
