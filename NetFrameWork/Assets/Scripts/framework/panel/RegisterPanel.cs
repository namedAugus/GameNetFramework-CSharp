﻿using gprotocol;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    //账号输入框
    private InputField idInput;
    //密码输入框
    private InputField pwInput;
    //重复输入框
    private InputField repInput;
    //注册按钮
    private Button regBtn;
    //关闭按钮
    private Button closeBtn;

    //初始化
    public override void OnInit()
    {
        skinPath = "RegisterPanel";
        layer = PanelManager.Layer.Panel;
    }

    //显示
    public override void OnShow(params object[] para)
    {
        //寻找组件
        idInput = skin.transform.Find("IdInput").GetComponent<InputField>();
        pwInput = skin.transform.Find("PwInput").GetComponent<InputField>();
        repInput = skin.transform.Find("RepInput").GetComponent<InputField>();
        regBtn = skin.transform.Find("RegisterBtn").GetComponent<Button>();
        closeBtn = skin.transform.Find("CloseBtn").GetComponent<Button>();
        //监听
        regBtn.onClick.AddListener(this.OnRegClick);
        closeBtn.onClick.AddListener(this.OnCloseClick);
        //网络协议监听
        NetManager.AddMsgListener("MsgRegister", this.OnMsgRegister);
    }

    private void OnMsgRegister(ProtoBuf.IExtensible msgBase)
    {
        MsgRegister msg = (MsgRegister)msgBase;
        if (msg.result == 1)
        {
            Debug.Log("注册成功");
            //提示
            PanelManager.Open<TipPanel>("注册成功！");
            //关闭界面
            Close();
        }
        else
        {
            PanelManager.Open<TipPanel>("注册失败");
        }
    }

    private void OnCloseClick()
    {
        throw new NotImplementedException();
    }

    private void OnRegClick()
    {
        if (idInput.text == "" || pwInput.text == "")
        {
            PanelManager.Open<TipPanel>("用户名和密码不能为空");
            return;
        }
        //两次密码不同
        if (repInput.text != pwInput.text)
        {
            PanelManager.Open<TipPanel>("两次输入的密码不同");
            return;
        }
        //发送
        MsgRegister msgReg = new MsgRegister();
        msgReg.username = idInput.text;
        msgReg.password = pwInput.text;
        NetManager.Send(msgReg);
    }

    //关闭
    public override void OnClose()
    {
        NetManager.RemoveMsgListener("MsgRegister", OnMsgRegister);
    }
}
