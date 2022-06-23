using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class GlobalController : MonoBehaviour
    {
        private static GlobalController instance;

        public static GlobalController Instance()
        {
            if (instance == null)
            {
                var obj = new GameObject("GlobalController");
                instance = obj.AddComponent<GlobalController>();
            }

            return instance;
        }
        
        public void _StartCoroutine(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }

        public void _StopCoroutine(IEnumerator enumerator)
        {
            StopCoroutine(enumerator);
        }

        public void _StopAllCoroutine()
        {
            StopAllCoroutines();
        }
    }
}