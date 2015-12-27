using UnityEngine;
using UnityEngine.UI;
using System;
namespace SimplePopup
{
    class SimplePopupButton
    {
        private string text;
        private Color textColor;
        private Color backgroundColor;
        private GameObject gameObject;
        private Transform parentTransform;
        private GameObject prefab;
        private Action onClickEvent;
        public SimplePopupButton(){}
        public SimplePopupButton(string text,Color textColor,Color backgroundColor,Transform parentTransform,GameObject prefab,Action onClickEvent)
        {
            this.text = text;
            this.textColor = textColor;
            this.backgroundColor = backgroundColor;
            this.parentTransform = parentTransform;
            this.prefab = prefab;
            this.onClickEvent = onClickEvent;
        }
        public void Create()
        {
            gameObject = (GameObject)GameObject.Instantiate(prefab);
            gameObject.transform.SetParent(parentTransform, false);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.GetComponent<Button>().onClick.AddListener(() => { onClickEvent();});
            gameObject.GetComponent<Image>().color = backgroundColor;
            if (gameObject.transform.childCount != 0)
            {
                gameObject.transform.GetChild(0).GetComponent<Text>().text = text;
                gameObject.transform.GetChild(0).GetComponent<Text>().color = textColor;
            }
        }

        public void Destroy()
        {
            if (gameObject)
            {
                GameObject.Destroy(gameObject);
            }
        }

    }
}
