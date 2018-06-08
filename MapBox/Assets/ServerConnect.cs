using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum LogState
{
    LoginOk,
    LoginError,
    RegisterOk
}

public class ServerConnect : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI logErrorField;
    private LogState _logState
    {
        get { return _logState; }
        set
        {
            logErrorField.text = value.ToString();
        }
    }

    public GameObject panel;
    public TMP_InputField _Login;
    public TMP_InputField _Pass;
    public string url = "http://projectnure.kl.com.ua/main.php";
    public delegate void DelegateLoginOK(string name);
    public event DelegateLoginOK LoginOK;
    public delegate void DelegateLoginERR(string message);
    public event DelegateLoginERR LoginERR;
    void Start()
    {
        LoginOK += LoginSucces;
        LoginERR += LoginERRor;
    }

    void LoginSucces(string name)
    {
        _logState = LogState.LoginOk;
        Debug.Log("Метод успешного логина/ Наше имя " + name);
    }
    void LoginERRor(string message)
    {
        _logState = LogState.LoginError;
        Debug.Log("ошибка логина : " + message);
    }

    public void Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("command", "login");
        form.AddField("login", _Login.text);
        form.AddField("pass", _Pass.text);
        WWW www = new WWW(url, form);
        StartCoroutine(WaltForResquet(www, () =>
        {
            switch (www.text.Contains("shit"))
            {
                case false:
                    if (LoginOK != null)
                    {
                        panel.SetActive(false);
                        LoginOK("");
                    };
                    break;
                case true:
                    if (LoginERR != null) LoginERR("");
                    break;
            }
        }));
    }

    public void Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("command", "register");
        form.AddField("login", _Login.text);
        form.AddField("pass", _Pass.text);
        WWW www = new WWW(url, form);
        StartCoroutine(WaltForResquet(www, () =>
        {
            _logState = LogState.RegisterOk;
        }));
    }

    private IEnumerator WaltForResquet(WWW www, Action action = null)
    {
        yield return www;
        if (www.text.Length > 0)
        {
            //string[] tmp = www.text.Split('*');
            Debug.Log("Сервер ответил:" + www.text);
            if (action != null)
                action.Invoke();
        }
    }
}
