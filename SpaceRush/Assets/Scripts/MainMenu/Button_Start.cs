using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Start : MonoBehaviour {
//Make sure to attach these Buttons in the Inspector
    public Button m_YourFirstButton, m_YourSecondButton, m_YourThirdButton;
	public GameObject loading_image;

    void Start()
    {
		loading_image = GameObject.FindWithTag("Loading_Circle");
		loading_image.SetActive(false);



		m_YourFirstButton = this.GetComponent<Button>();
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        m_YourFirstButton.onClick.AddListener(TaskOnClick);
        // m_YourSecondButton.onClick.AddListener(delegate {TaskWithParameters("Hello"); });
        // m_YourThirdButton.onClick.AddListener(() => ButtonClicked(42));
        // m_YourThirdButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {		
		loading_image.SetActive(true);
		StartCoroutine(LoadYourAsyncScene());
    }

	IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.	

		yield return new WaitForSeconds(5);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FinalScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }
}
