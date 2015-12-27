using UnityEngine;
using SimplePopup;
public class SimplePopupExample : MonoBehaviour {

    void Start() {
    }

    public void onDefaultPopup()
    {
        SimplePopupManager.Instance.CreatePopup("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
        SimplePopupManager.Instance.AddButton("Lorem", delegate { Debug.Log("on clicked1"); });
        SimplePopupManager.Instance.AddButton("ipsum", delegate { Debug.Log("on clicked2"); });
        SimplePopupManager.Instance.AddButton("dolor", delegate { Debug.Log("on clicked1"); });
        SimplePopupManager.Instance.ShowPopup();
    }
    public void onCustomPopup()
    {
        SimplePopupManager.Instance.CreatePopup("Are you sure you want to quit?", Color.white, Color.black);
        SimplePopupManager.Instance.AddButton("Yes", Color.white, new Color(64/255.0f,208/255.0f,116/255.0f), delegate {
            Debug.Log("on click to yes");
        });
        SimplePopupManager.Instance.AddButton("No", Color.white, new Color(208/255.0f,64/255.0f, 64 / 255.0f), delegate {
            Debug.Log("on click to no"); 
        });
        SimplePopupManager.Instance.AddButton("Maybe", Color.white, new Color(208/255.0f,189/255.0f, 64 / 255.0f), delegate {
            Debug.Log("on click to maybe");
        });
        SimplePopupManager.Instance.ShowPopup();
    }
} 