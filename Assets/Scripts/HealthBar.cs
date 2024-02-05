using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthBar: MonoBehaviour
    {
        [SerializeField] private List<Image> _healthPoints;
        [SerializeField] private Health _health;

        private void OnEnable()
        {
            _health.OnHealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.OnHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        { 
            _healthPoints[_health.Healthy].gameObject.SetActive(false);
        }
    }
}
