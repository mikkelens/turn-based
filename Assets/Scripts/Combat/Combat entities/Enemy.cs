namespace Gameplay.Management
{
    public class Enemy : Entity
    {
        #region Entity specifications/overrides
        protected override void Die()
        {
            base.Die();
            FightManager.Instance.WinBattle(); // should let fightmanager decide this
        }
        #endregion
    }
}