namespace Decorator.Scripts
{
    public abstract class AbilityUpgrade : IAbility
    {
        protected IAbility mainAbility;

        public virtual int Damage => mainAbility.Damage;
        public virtual DamageType DamageType => mainAbility.DamageType;

        public AbilityUpgrade(IAbility mainAbility) => 
            this.mainAbility = mainAbility;

        public virtual void Apply(IDamageable target)
        {
            mainAbility.Apply(target);
        }
    }
}