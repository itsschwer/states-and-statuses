using UnityEngine;

public abstract class Character : Actor, IGigantism, IDashless, ISlow {
    [Header("Components")]
    [SerializeField] protected SpriteRenderer _renderer = default;
    public new SpriteRenderer renderer => _renderer;

    [Header("Properties")]
    [SerializeField] protected float moveSpeed = 6;
    [SerializeField] protected float maxDashDistance = 4;

    [Header("Inflictable Statuses")]
    [SerializeField] private Gigantism _gigantism = default;
    public Gigantism gigantism => _gigantism;
    [SerializeField] private Dashless _dashless = default;
    public Dashless dashless => _dashless;
    [SerializeField] private Slow _slow = default;
    public Slow slow => _slow;

    public float speedModifier { get; set; } = 1;
    public bool canDash { get; set; } = true;

    private void Reset() => OnValidate(true);

    private void OnValidate() => OnValidate(false);
    private void OnValidate(bool overrideExisting) {
        if (overrideExisting || _renderer == null) _renderer = GetComponentInChildren<SpriteRenderer>();
        if (overrideExisting || _gigantism == null) _gigantism = GetComponentInChildren<Gigantism>();
        if (overrideExisting || _dashless == null) _dashless = GetComponentInChildren<Dashless>();
        if (overrideExisting || _slow == null) _slow = GetComponentInChildren<Slow>();
    }

    protected override void Awake() {
        base.Awake();
        gigantism?.Initialise(this);
        dashless?.Initialise(this);
        slow?.Initialise(this);
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
