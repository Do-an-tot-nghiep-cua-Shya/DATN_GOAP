public class GoHome : GAction {
    public override bool PrePerform() {

        beliefs.RemoveState("atHospital");
        return true;
    }

    public override bool PostPerform() {

        Destroy(this.gameObject, 1.0f);
        Spawner.Instance.currentPatients--;
        return true;
    }
}
