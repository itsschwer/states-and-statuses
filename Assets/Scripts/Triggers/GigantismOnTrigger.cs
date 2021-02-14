using UnityEngine;

public class GigantismOnTrigger : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        var target = other.GetComponent<IGigantism>();
        if (target != null) {
            target.gigantism.Trigger();
        }
    }
}
