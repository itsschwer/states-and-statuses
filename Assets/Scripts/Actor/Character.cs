using UnityEngine;

public class Character : Actor, IGigantism {
    [Header("Properties")]
    [SerializeField] protected float moveSpeed = 10;
    [SerializeField] protected float maxDashDistance = 5;

    [Header("Inflictable Statuses")]
    [SerializeField] private Gigantism _gigantism = default;
    public Gigantism gigantism => _gigantism;

    public float speedModifier { get; set; } = 1;
    public bool canDash { get; set; } = true;

    private void OnValidate() {
        if (_gigantism == null) {
            _gigantism = GetComponentInChildren<Gigantism>();
        }
    }

    protected override void Awake() {
        base.Awake();
        gigantism?.Initialise(this);
    }

    protected void MoveTowards(Vector2 destination, float maxDelta) {
        var difference = destination - (Vector2)transform.position;
        if (difference.magnitude > maxDelta) {
            difference.Normalize();
            transform.Translate(difference * maxDelta);
        }
        else {
            transform.Translate(difference);
        }
    }
}
