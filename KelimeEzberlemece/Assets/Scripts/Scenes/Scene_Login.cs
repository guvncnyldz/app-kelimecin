using UnityEngine;

public class Scene_Login : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneItems;

    public void Button_Login()
    {
        StartCoroutine(SceneOperation.GetInstance().AnimLogin(sceneItems));
    }
}
