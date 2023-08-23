using UnityEngine.SceneManagement;

namespace Canvas
{
    public class EndGameCanvasCntrl : CanvasBase
    {
        public void ReloadGame()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
