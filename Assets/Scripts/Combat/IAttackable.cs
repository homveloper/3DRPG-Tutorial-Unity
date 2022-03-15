
namespace SD.Combat
{
    public interface IAttackable
    {
        public void Attack(IDamage target);
        public bool CanAttack(IDamage target);
        public void SetTarget(IDamage target);
    }

}
