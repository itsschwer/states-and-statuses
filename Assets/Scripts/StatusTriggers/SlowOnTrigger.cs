public class SlowOnTrigger : StatusOnTrigger<ISlow> {
    protected override void Trigger(ISlow target)
        => target.slow.Trigger();
}
