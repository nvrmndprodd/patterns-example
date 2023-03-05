using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Decorator.Scripts
{
    public class DecoratorUIController : MonoBehaviour
    {
        [SerializeField] private ExampleUnit unit;
        [SerializeField] private Button button;
        [SerializeField] private WidgetDamageValue widgetPrefab;
        [SerializeField] private Transform damageValueContainer;

        private Dictionary<DamageType, Color> damageColors = new Dictionary<DamageType, Color>
        {
            { DamageType.Physical, Color.white },
            { DamageType.Electrical, Color.yellow },
            { DamageType.Water, Color.blue }
        };

        private void OnEnable() => 
            button.onClick.AddListener(OnButtonClick);

        private void OnDisable() => 
            button.onClick.RemoveListener(OnButtonClick);

        public void CreateWidgetDamageValue(DamageType damageType, int damage)
        {
            var color = damageColors[damageType];
            var widget = Instantiate(widgetPrefab, damageValueContainer);
            var maxDistance = 10f;
            var randomOffset = Random.insideUnitCircle * maxDistance;
            var position = damageValueContainer.position + new Vector3(randomOffset.x, randomOffset.y, 0f);
            
            widget.transform.position = position;
            widget.SetValue(damage.ToString());
            widget.SetColor(color);
        }

        private void OnButtonClick()
        {
            Debug.Log("Damage");

            IAbility ability = new Ability(10, DamageType.Physical);
            ability = new AbilityPeriodicDamage(ability, 5f, 10, this);
            ability = new AbilityAdditionalDamage(ability, 20, DamageType.Electrical);
            
            ability.Apply(unit);
        }
    }
}