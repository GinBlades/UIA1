using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
    private Camera _camera;

	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Every MonoBehaviour object can use this method to draw on the cemra.
    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            // Create the ray at the camera center
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;

            // Set hit to the coordinates of the ray hit.
            if (Physics.Raycast(ray, out hit))
            {
                // Use coroutine to create and destroy new spheres
                StartCoroutine(SphereIndicator(hit.point));
            }
        }
	}
    
    // The IEnumerator type is required for coroutines. It's not really asynchronous.
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        // Cause the coroutine to temporarily pause, allowing  program to continue
        // yield works with some different return types, but most commonly a time.
        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
