using UnityEngine;

public class MouseController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float maxDashDistance = 3;
    private new Transform transform;
    private new Camera camera;

    private Vector2 mousePosition => camera.ScreenToWorldPoint(Input.mousePosition);

    private void Awake() {
        transform = GetComponent<Transform>();
        camera = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Dash();
        }
        else if (Input.GetMouseButton(0)) {
            Walk();
        }
    }

    private void Walk() {
        var difference = mousePosition - (Vector2)transform.position;
        difference.Normalize();
        transform.Translate(difference * moveSpeed * Time.deltaTime);
    }

    private void Dash() {
        var difference = mousePosition - (Vector2)transform.position;
        if (difference.magnitude > maxDashDistance) {
            difference.Normalize();
            transform.Translate(difference * maxDashDistance);
        }
        else {
            transform.Translate(difference);
        }
    }
}
