using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOperation : MonoBehaviour
{
    private static SceneOperation Instance;

    public IEnumerator AnimLogin(GameObject sceneItems)
    {
        sceneItems.GetComponent<Animator>().SetBool("isLogin", true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    public IEnumerator AnimExit(GameObject sceneItems,int choosenScene)
    {
        sceneItems.GetComponent<Animator>().SetBool("isExit", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(choosenScene);
    }

    public static SceneOperation GetInstance()
    {
        if (Instance == null)
            Instance = new SceneOperation();

        return Instance;
    }
}
