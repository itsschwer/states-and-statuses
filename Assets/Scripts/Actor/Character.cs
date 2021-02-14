using UnityEngine;

public class Character : Actor, IGigantism {
    [SerializeField] private Gigantism _gigantism = default;
    public Gigantism gigantism => _gigantism;

    private void OnValidate() {
        if (_gigantism == null) {
            _gigantism = GetComponentInChildren<Gigantism>();
        }
    }

    protected override void Awake() {
        base.Awake();
        gigantism?.Initialise(this);
    }
}
