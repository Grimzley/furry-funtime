using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    public Animator transition;

    public float transitionTime = 1f;

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel());
    }
    public IEnumerator LoadLevel() {
        transition.SetTrigger("Begin");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
