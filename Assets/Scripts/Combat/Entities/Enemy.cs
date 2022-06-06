namespace Combat.Entities
{
    public class Enemy : Entity
    {
        #region Entity specifications/overrides
        protected override void Die()
        {
            base.Die();
            Fight.Instance.WinBattle(); // should let fightmanager decide this
        }
        #endregion
    }
}