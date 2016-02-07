using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    private bool _alive;

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

	// Use this for initialization
	void Start () {
        _alive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (_alive)
        {
            // Continuous forward motion
            transform.Translate(0, 0, speed * Time.deltaTime);

            // Set ray to the same position and direction of character
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // Raycast with circumference around the ray
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < obstacleRange)
                {
                    // Turn in a new direction
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
	}
}
