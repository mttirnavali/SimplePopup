using UnityEngine;
using SimplePopup;
public class SimplePopupExample : MonoBehaviour {

    void Start() {
    }

    public void onDefaultPopup()
    {
        SimplePopupManager.Instance.CreatePopup("Are you sure you want to quit?");
        SimplePopupManager.Instance.AddButton("Yes", delegate { Debug.Log("clicked on yes"); });
        SimplePopupManager.Instance.AddButton("No", delegate { Debug.Log("clicked on no"); });
        SimplePopupManager.Instance.ShowPopup();
    }
    public void onCustomPopup()
    {
        SimplePopupManager.Instance.CreatePopup("Are you sure you want to quit?", Color.white, new Color(26 / 255.0f,30/255.0f,48/255.0f));
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