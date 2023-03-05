using UnityEngine;

namespace Decorator.Scripts
{
    public class ExampleUnit : MonoBehaviour, IDamageable
    {
        public DecoratorUIController ui;
        public void TakeDamage(DamageType damageType, int damage)
        {
            ui.CreateWidgetDamageValue(damageType, damage);
            
            Debug.Log($"Damage received {damageType} {damage}");
        }
    }
}