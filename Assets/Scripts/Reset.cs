using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class Reset : NetworkBehaviour
{
    // Start is called before the first frame update
    public Button m_ResetButton;
    void Start()
    {
        m_ResetButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ClientRpc]
    public void RpcChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    [Command]
    public void CmdChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void OnClick()
    {
        if(this.isClient)
        {
            CmdChangeScene();
        }
        if(this.isServer)
        {
            RpcChangeScene();
        }
    }
}
