using TMPro;
using UnityEngine;

namespace Decorator.Scripts
{
    public class WidgetDamageValue : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI valueField;

        public void SetValue(string value) => 
            valueField.text = value;

        public void SetColor(Color color) =>
            valueField.color = color;

        private void Handle_AnimationOver() => 
            Destroy(gameObject);
    }
}