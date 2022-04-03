using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMeshVR.Core;

namespace EasyMeshVR.Multiplayer
{
    public class NetworkPlayerHeadCollider : MonoBehaviour
    {
        [SerializeField] private SphereCollider sphereCollider;
        [SerializeField] public NetworkPlayer networkPlayer;

        void OnTriggerEnter(Collider other)
        {
            if (networkPlayer.photonView.IsMine && PlayerPrefs.GetInt(Constants.HIDE_CLOSE_PLAYERS_PREF_KEY) != 0)
            {
                NetworkPlayerHeadCollider headCollider = other.GetComponent<NetworkPlayerHeadCollider>();
                headCollider.networkPlayer.HidePlayerAvatar(true);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (networkPlayer.photonView.IsMine && PlayerPrefs.GetInt(Constants.HIDE_CLOSE_PLAYERS_PREF_KEY) != 0)
            {
                NetworkPlayerHeadCollider headCollider = other.GetComponent<NetworkPlayerHeadCollider>();
                headCollider.networkPlayer.HidePlayerAvatar(false);
            }
        }
    }
}
