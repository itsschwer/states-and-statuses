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
            MoveTowards(maxDashDistance);
        }
        else if (Input.GetMouseButton(0)) {
            MoveTowards(moveSpeed * Time.deltaTime);
        }
    }

    private void MoveTowards(float maxDelta) {
        var difference = mousePosition - (Vector2)transform.position;
        if (difference.magnitude > maxDelta) {
            difference.Normalize();
            transform.Translate(difference * maxDelta);
        }
        else {
            transform.Translate(difference);
        }
    }
}
