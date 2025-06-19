#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.HMIProject;
using FTOptix.NativeUI;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using FTOptix.WebUI;
#endregion

public class SendDataPLC : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        Session.UserVariable.VariableChange += UserVariable_VariableChange;
        SendData();
    }

    private void UserVariable_VariableChange(object sender, VariableChangeEventArgs e)
    {
        SendData();
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        Session.UserVariable.VariableChange -= UserVariable_VariableChange;
    }

    public void SendData()
    {
        if (Session.GetVariable("IsNative").Value == true)
        {
            LogicObject.GetVariable("Username").Value = Session.User.BrowseName;
            LogicObject.GetVariable("Group1").Value = Session.GetVariable("Groups/Group1").Value;
            LogicObject.GetVariable("Group2").Value = Session.GetVariable("Groups/Group2").Value;
        }        
    }
}
