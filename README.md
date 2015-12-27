# SimplePopup
SimplePopup is a tool to show popups(dialogs) in Unity. It can be useful while creating prototypes.

# Requirements
* Unity 5

# Installation
Dowload and import [SimplePopup_v1.1.unitypackage](https://github.com/tuncertirnavali/SimplePopup/raw/master/SimplePopup_v1.1.unitypackage) to your project.

# Usage
1. Drag and Drop `SimplePopupManager.prefab` from `Assets/SimplePopup/SimplePopupManager` to your scene.
2. At top of your file,

  ```unity
        using SimplePopup;
  ```

3. You can show your popup easily like that:
  ```unity
        SimplePopupManager.Instance.CreatePopup("Are you sure you want to quit?");
        SimplePopupManager.Instance.AddButton("Yes", delegate { Debug.Log("clicked on yes"); });
        SimplePopupManager.Instance.AddButton("No", delegate { Debug.Log("clicked on no"); });
        SimplePopupManager.Instance.ShowPopup();
  ```
  [![](https://raw.githubusercontent.com/tuncertirnavali/SimplePopup/master/defaultExample.png)](https://raw.githubusercontent.com/tuncertirnavali/SimplePopup/master/defaultExample.png)

4. You can customize your popup also:
```unity
        SimplePopupManager.Instance.CreatePopup("Are you sure you want to quit?", Color.white, new Color(26 / 255.0f,30/255.0f,48/255.0f));
        SimplePopupManager.Instance.AddButton("Yes", Color.white,new Color(64/255.0f,208/255.0f,116/255.0f), delegate {
            Debug.Log("on click to yes");
        });
        SimplePopupManager.Instance.AddButton("No", Color.white, new Color(208/255.0f,64/255.0f, 64 / 255.0f), delegate {
            Debug.Log("on click to no"); 
        });
        SimplePopupManager.Instance.AddButton("Maybe", Color.white, new Color(208/255.0f,189/255.0f, 64 / 255.0f), delegate {
            Debug.Log("on click to maybe");
        });
        SimplePopupManager.Instance.ShowPopup();
  ```
[![](https://raw.githubusercontent.com/tuncertirnavali/SimplePopup/master/customExample.png)](https://raw.githubusercontent.com/tuncertirnavali/SimplePopup/master/customExample.png)


# License
MIT

# Contact
[Gri Games Facebook Page](https://www.facebook.com/grigames/)
