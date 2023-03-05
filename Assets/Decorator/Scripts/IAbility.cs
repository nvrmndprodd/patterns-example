namespace Decorator.Scripts
{
    public interface IAbility
    {
        int Damage { get; }
        DamageType DamageType { get; }
        
        void Apply(IDamageable target);
    }
}
