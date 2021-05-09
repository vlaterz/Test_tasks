using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Controller Controller;
        public View View;
        void Awake() => Controller = new Controller(new Model(), View);
        public void OnClick()=> Controller.Click();
    }
}
