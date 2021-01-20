using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviourPunCallbacks
{
    public Transform gunTransform;

    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // shoot
                photonView.RPC("RPC_SHoot", RpcTarget.All);
                
            }
        }
    }

    [PunRPC]
    void RPC_SHoot()
    {
        particleSystem.Play();
        
        // create ray
        Ray ray = new Ray(gunTransform.position, gunTransform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            // we hit something
            // check hit has health script we an take some value off health
        }
    }
}