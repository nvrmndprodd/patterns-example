namespace Decorator.Scripts
{
    public class AbilityAdditionalDamage : AbilityUpgrade
    {
        private int _additionalDamage;
        private DamageType _damageType;
        
        public AbilityAdditionalDamage(IAbility mainAbility, int additionalDamage, DamageType damageType) : base(mainAbility)
        {
            _additionalDamage = additionalDamage;
            _damageType = damageType;
        }

        public override void Apply(IDamageable target)
        {
            base.Apply(target);
            
            target.TakeDamage(_damageType, _additionalDamage);
        }
    }
}