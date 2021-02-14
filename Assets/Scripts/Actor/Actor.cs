using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Actor : MonoBehaviour {
    public new Transform transform { get; private set; }
    protected new Rigidbody2D rigidbody;

    protected virtual void Awake() {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
}
