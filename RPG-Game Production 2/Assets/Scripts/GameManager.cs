using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Equals) && Input.GetKey(KeyCode.L))
        {
            SceneSwitcher(0);
        }

        if (Input.GetKey(KeyCode.Equals) && Input.GetKey(KeyCode.P))
        {
            SceneSwitcher(1);
        }
    }

    void SceneSwitcher(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
