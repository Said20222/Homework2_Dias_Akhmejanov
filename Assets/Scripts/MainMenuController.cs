using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _newGame;
    [SerializeField] private Button _continue;
    [SerializeField] private Image _loader;
    [SerializeField] private CanvasGroup _canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        _loader.fillAmount = 0;
        _canvasGroup.alpha = 0;
    }

    public void StartGame() 
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene() 
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone) {
            _canvasGroup.alpha = Time.deltaTime;
            _loader.fillAmount = asyncOperation.progress * 100;
            asyncOperation.allowSceneActivation = _loader.fillAmount >= 1;
            yield return null;
        }
    }
}
