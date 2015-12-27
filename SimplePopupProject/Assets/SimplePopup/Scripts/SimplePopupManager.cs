using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using System.Collections;

namespace SimplePopup
{
    public class SimplePopupManager : MonoBehaviour
    {
        private GameObject _canvas;
        private GameObject _buttonPrefab;
        private GameObject _eventSystem;
        private string _message;
        private Color _messageColor;
        private Color _backgroundColor;
        private List<SimplePopupButton> buttons = new List<SimplePopupButton>();
        private static SimplePopupManager _instance;
        public static SimplePopupManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = GameObject.FindObjectOfType<SimplePopupManager>();
                return _instance;
            }
        }

        void Awake()
        {
            _canvas = (GameObject)Instantiate(Resources.Load("SimplePopupResources/Canvas", typeof(GameObject)));
            _canvas.GetComponent<CanvasGroup>().alpha = 0.0f;
            _canvas.GetComponent<CanvasGroup>().interactable = false;
            _canvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
            _buttonPrefab = (GameObject)Resources.Load("SimplePopupResources/Button", typeof(GameObject));

            EventSystem[] objects = (EventSystem[])GameObject.FindObjectsOfType<EventSystem>();
            if (objects.Length == 0)
            {
                _eventSystem = new GameObject("PopupEventSystem", typeof(EventSystem));
                _eventSystem.AddComponent<StandaloneInputModule>().forceModuleActive = true;
            }
            else
            {
                objects[0].gameObject.GetComponent<StandaloneInputModule>().forceModuleActive = true;
            }

        }
        public void CreatePopup(string message)
        {
            CreatePopup(message, Color.white, Color.black);
        }
        public void CreatePopup(string message, Color messageColor, Color backgroundColor)
        {
            destroyPreviousButtons();
            _message = message;
            _messageColor = messageColor;
            _backgroundColor = backgroundColor;
        }
        public void AddButton(string buttonText, Action onClickEvent)
        {
            AddButton(buttonText, Color.black, Color.white, onClickEvent);
        }
        public void AddButton(string buttonText,Color buttonTextColor,Color buttonBackgroundColor,Action onClickEvent)
        {
            buttons.Add(new SimplePopupButton(buttonText,buttonTextColor,buttonBackgroundColor,_canvas.transform.GetChild(0),_buttonPrefab,delegate { onClickEvent(); HidePopup(); }));
        }

        public void ShowPopup()
        {
            foreach(SimplePopupButton button in buttons)
            {
                button.Create();
            }
            setPanel();
            StartCoroutine(showPopup(_canvas.GetComponent<CanvasGroup>(), .5f));
        }
        public void HidePopup()
        {
            StartCoroutine(hidePopup(_canvas.GetComponent<CanvasGroup>(), .5f));
        }

        IEnumerator showPopup(CanvasGroup canvasGroup, float second)
        {
            _canvas.GetComponent<Image>().raycastTarget = true;
            canvasGroup.alpha = 0.0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = true;
            while (canvasGroup.alpha < 1.0f)
            {
                canvasGroup.alpha += Time.deltaTime * (1.0f / second); ;
                yield return null;
            }
            canvasGroup.alpha = 1.0f;
            canvasGroup.interactable = true;
        }
        IEnumerator hidePopup(CanvasGroup canvasGroup, float second)
        {
            canvasGroup.interactable = false;
            canvasGroup.alpha = 1.0f;
            while (canvasGroup.alpha > .0f)
            {
                canvasGroup.alpha -= Time.deltaTime * (1.0f / second);
                yield return null;
            }
            canvasGroup.alpha = 0.0f;
            _canvas.GetComponent<Image>().raycastTarget = false;
            canvasGroup.blocksRaycasts = false;
        }

        private void setPanel()
        {
            _canvas.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = _message;
            _canvas.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().color = _messageColor;
            _canvas.transform.GetChild(0).GetComponent<Image>().color = _backgroundColor;
        }
        private void destroyPreviousButtons()
        {
            foreach(SimplePopupButton button in buttons)
            {
                button.Destroy();
            }
            buttons.Clear();
        }
    }
}