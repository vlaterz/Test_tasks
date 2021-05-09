using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class View : MonoBehaviour
    {
        private Text _text;
        void Awake()
        {
            _text = GetComponentInChildren<Text>();
        }

        public void UpdateView(string text)
        {
            _text.text = text;
        }
    }
}
