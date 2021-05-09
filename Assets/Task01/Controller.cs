namespace Assets.Scripts
{
    public class Controller
    {
        public Model Model;
        public View View;

        public Controller(Model model, View view) => (Model, View) = (model, view);

        public void Click()
        {
            Model.AddNumber();
            View.UpdateView(Model.NumberOfClicks.ToString());
        } 
    }
}
