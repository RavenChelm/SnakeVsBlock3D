using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _menuConroller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _menuConroller.SendMessage("GameVictoryMenu");
        }
    }
}