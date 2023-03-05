namespace Decorator.Scripts
{
    public class Ability : IAbility
    {
        public int Damage { get; }
        public DamageType DamageType { get; }

        public Ability(int damage, DamageType damageType)
        {
            Damage = damage;
            DamageType = damageType;
        }
        
        public void Apply(IDamageable target) => 
            target.TakeDamage(DamageType, Damage);
    }
}