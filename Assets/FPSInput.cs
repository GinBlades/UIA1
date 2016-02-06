using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    public float speed = 6.0f;
    public float gravity = -9.8f;

    private CharacterController _charController;

    // Use this for initialization
    void Start () {
        _charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // Limit diagonal movement to the same speed
        movement = Vector3.ClampMagnitude(movement, speed);
        // Constant downward force.
        movement.y = gravity;

        movement *= Time.deltaTime;

        // Transform movement vector from local to global coordinates
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
	}
}
