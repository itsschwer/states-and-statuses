using UnityEngine;

public class Actor : MonoBehaviour, IGigantism {
    [SerializeField, HideInInspector] private Transform _transform = default;
    public new Transform transform => _transform;

    [SerializeField] private Gigantism _gigantism = default;
    public Gigantism gigantism => _gigantism;

    private void OnValidate() {
        _transform = GetComponent<Transform>();

        if (_gigantism == null) {
            _gigantism = GetComponentInChildren<Gigantism>();
        }
    }
}
