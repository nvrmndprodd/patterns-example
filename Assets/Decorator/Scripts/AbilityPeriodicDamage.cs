using System.Collections;
using UnityEngine;

namespace Decorator.Scripts
{
    public class AbilityPeriodicDamage : AbilityUpgrade
    {
        private float _duration;
        private int _ticks;
        private readonly MonoBehaviour _mb;

        public AbilityPeriodicDamage(IAbility mainAbility, float duration, int ticks, MonoBehaviour mb) : base(mainAbility)
        {
            _duration = duration;
            _ticks = ticks;
            _mb = mb;
        }

        public override void Apply(IDamageable target)
        {
            _mb.StartCoroutine(ApplyDamageRoutine(target));
        }

        private IEnumerator ApplyDamageRoutine(IDamageable target)
        {
            var damagePerTick = Mathf.CeilToInt(mainAbility.Damage / (float)_ticks);
            var tickDuration = _duration / _ticks;
            
            target.TakeDamage(mainAbility.DamageType, damagePerTick);

            for (var i = 1; i < _ticks; i++)
            {
                yield return new WaitForSeconds(tickDuration);
                
                target.TakeDamage(mainAbility.DamageType, damagePerTick);
            }
        }
    }
}