using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using System;

public class ConnectionManager: MonoBehaviour
{
    //Happened on server
    public void Host()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost();
    }

    //Happens on server
    //NOT DONE 
    private void ApprovalCheck(byte[] arg1, ulong arg2, NetworkManager.ConnectionApprovedDelegate arg3)
    {
        throw new NotImplementedException();
    }

    public void Join()
    {
        NetworkManager.Singleton.StartClient();
    }
}
