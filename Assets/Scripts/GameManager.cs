using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ShroomController _shroomController;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _winScreen;

    private void OnEnable() 
    {
        _shroomController.OnDeath += ShroomControllerOnKilled;
    }
    
    private void OnDisable() 
    {
        _shroomController.OnDeath -= ShroomControllerOnKilled;
    }

    private void ShroomControllerOnKilled() 
    {
        _endScreen.SetActive(true);
    }

    public void OnLevelCompleted() 
    {
        _winScreen.SetActive(true);
        _shroomController.enabled = false;
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit() 
    {
        SceneManager.LoadScene(0);
    }
}
