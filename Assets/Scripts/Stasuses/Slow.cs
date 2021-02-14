using UnityEngine;

public class Slow : Status {
    [SerializeField] private float speedMultiplier = 0.5f;
    [SerializeField] private float duration = 3;
    [SerializeField] private int maxStacks = 8;

    /// <summary>
    /// This value should be cached where possible (uses a for loop).
    /// </summary>
    public int stacks {
        get {
            int s = 0;
            for (int i = 0; i < timers.Length; i++) {
                if (timers[i] > 0) {
                    s++;
                }
            }
            return s;
        }
    }

    private float[] timers;

    private ISlow target;

    public void Initialise(ISlow target) {
        this.target = target;
        timers = new float[maxStacks];
    }

    public override void Trigger() {
        if (target == null) return;

        if (stacks < maxStacks) {
            for (int i = 0; i < timers.Length; i++) {
                if (timers[i] <= 0) {
                    timers[i] = duration;
                    break;
                }
            }

            target.speedModifier *= speedMultiplier;
        }

        if (stacks > 0) {
            this.enabled = true;
        }
    }

    public override void Clear() {
        if (target == null) return;

        for (int i = 0; i < stacks; i++) {
            target.speedModifier /= speedMultiplier;
        }

        for (int i = 0; i < timers.Length; i++) {
            timers[i] = 0;
        }

        this.enabled = false;
    }

    protected override void Update() {
        if (target == null) return;

        for (int i = 0; i < timers.Length; i++) {
            if (timers[i] > 0) {
                timers[i] -= Time.deltaTime;

                if (timers[i] < 0) {
                    target.speedModifier /= speedMultiplier;
                }

                if (stacks <= 0) {
                    this.enabled = false;
                }
            }
        }
    }
}

public interface ISlow {
    Slow slow { get; }
    float speedModifier { get; set; }
    SpriteRenderer renderer { get; }
}
