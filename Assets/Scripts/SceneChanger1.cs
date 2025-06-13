using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SceneManager.LoadScene("SampleScene");
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 150, 40), "go sampleScene"))
            SceneManager.LoadScene("SampleScene");

        if (GUI.Button(new Rect(0, 45, 150, 40), "Add SampleScene"))
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);

        if (GUI.Button(new Rect(Screen.width - 150, 0, 150, 40), "SampleScene Active!"))
        {
            Scene scene = SceneManager.GetSceneByName("SampleScene");
            SceneManager.SetActiveScene(scene);
        }
    }
}
