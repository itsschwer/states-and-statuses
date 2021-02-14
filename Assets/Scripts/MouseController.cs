using UnityEngine;

public class MouseController : Character {
    private new Camera camera;

    private Vector2 mousePosition => camera.ScreenToWorldPoint(Input.mousePosition);

    private void Start() => camera = Camera.main;

    private void Update() {
        if (Input.GetMouseButtonDown(1) && canDash) {
            MoveTowards(mousePosition, maxDashDistance * speedModifier);
        }
        else if (Input.GetMouseButton(0)) {
            MoveTowards(mousePosition, moveSpeed * speedModifier * Time.deltaTime);
        }
    }
}
