using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthBar: MonoBehaviour
    {
        [SerializeField] private List<Image> _healthPoints;
        [SerializeField] private Health _health;

        private void Start()
        {
            for(int i=0; i < _healthPoints.Count; i++)
            {
                if(i < _health.Healthy)
                _healthPoints[i].gameObject.SetActive(true);
                else _healthPoints[i].gameObject.SetActive(false);
            }
        }
    }
}
