using UnityEngine;

public class DashlessOnTrigger : StatusOnTrigger<IDashless> {
    protected override void Trigger(IDashless target) {
        target.dashless.Trigger();
    }
}
