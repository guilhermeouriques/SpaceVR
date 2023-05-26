using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class SpaceshipController : MonoBehaviour {
    [Header("Ship Movement Settings")]
    [SerializeField] private float yawTorque = 500f;
    [SerializeField] private float pitchTorque = 1000f;
    [SerializeField] private float rollTorque = 1000f;
    [SerializeField] private float thrust = 100f;
    [SerializeField] private float upThrust = 50f;
    [SerializeField] private float strafeThrust = 50f;

    [SerializeField, Range(.001f, .999f)] private float thrustGlideReduction = .999f;
    [SerializeField, Range(.001f, .999f)] private float upDownGlideReduction = .111f;
    [SerializeField, Range(.001f, .999f)] private float leftRightGlideReduction = .111f;

    private Rigidbody rb;

    private float glide, verticalGlide, horizontalGlide = 0f;
    private float thrust1D;
    private float upDown1D;
    private float strafe1D;
    private Vector2 roll1D;
    private Vector2 pitchYaw;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    private void HandleMovement() {
        // Roll
        rb.AddRelativeTorque(Vector3.back * Mathf.Clamp(roll1D.x, -1f, 1f) * rollTorque * Time.deltaTime);

        // Pitch (inverted, if you want not inverted, should be -pitchYaw.y)
        rb.AddRelativeTorque(Vector3.right * Mathf.Clamp(pitchYaw.y, -1f, 1f) * pitchTorque * Time.deltaTime);

        // Yaw
        rb.AddRelativeTorque(Vector3.up * Mathf.Clamp(pitchYaw.x, -1f, 1f) * yawTorque * Time.deltaTime);

        // Thrust
        if (thrust1D != 0) {
            float currentThrust = thrust;
            rb.AddRelativeForce(Vector3.forward * thrust1D * currentThrust * Time.deltaTime);
            glide = thrust;
        } else {
            rb.AddRelativeForce(Vector3.forward * glide * Time.deltaTime);
            glide *= thrustGlideReduction;
        }

        // Up and Down
        if (upDown1D != 0) {
            rb.AddRelativeForce(Vector3.up * upDown1D * upThrust * Time.fixedDeltaTime);
            verticalGlide = upDown1D * upThrust;
        } else {
            rb.AddRelativeForce(Vector3.up * verticalGlide * Time.fixedDeltaTime);
            verticalGlide *= upDownGlideReduction;
        }

        // Strafe
        if (strafe1D != 0) {
            rb.AddRelativeForce(Vector3.right * strafe1D * upThrust * Time.fixedDeltaTime);
            horizontalGlide = strafe1D * strafeThrust;
        } else {
            rb.AddRelativeForce(Vector3.right * horizontalGlide * Time.fixedDeltaTime);
            horizontalGlide *= leftRightGlideReduction;
        }
    }

    public void StartLaunchProcedure() {
        DetachFromGround();
        TakeShipControl();
    }

    private void DetachFromGround() {
        rb.isKinematic = false;
    }

    private void TakeShipControl() {
        GetComponent<PlayerInput>().enabled = true;
    }

    #region Input Methods
    public void OnThrust(InputAction.CallbackContext context) {
        thrust1D = context.ReadValue<float>();

        //Debug.Log("OnThrust: " + thrust1D);
    }

    public void OnStrafe(InputAction.CallbackContext context) {
        strafe1D = context.ReadValue<float>();

        //Debug.Log("OnStrafe: " + strafe1D);
    }

    public void OnUpDown(InputAction.CallbackContext context) {
        upDown1D = context.ReadValue<float>();

        //Debug.Log("OnUpDown: " + upDown1D);
    }

    public void OnRoll(InputAction.CallbackContext context) {
        roll1D = context.ReadValue<Vector2>();

        //Debug.Log("OnRoll: " + roll1D);
    }

    public void OnPitchYaw(InputAction.CallbackContext context) {
        pitchYaw = context.ReadValue<Vector2>();

        //Debug.Log("OnPitchYaw: " + pitchYaw);
    }
    #endregion
}
