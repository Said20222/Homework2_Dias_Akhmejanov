using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.GetComponent<IPlayer>() is not null) {
            _animator.Play("Pop", 0, 0);
            Destroy(gameObject, 1f);
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }  
    }
}
