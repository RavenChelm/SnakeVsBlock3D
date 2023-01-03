using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBehindScene : MonoBehaviour
{
    [SerializeField] private string _tag;

    void Awake()
    {
        var obj = GameObject.FindWithTag(_tag);
        if (obj != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = _tag;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
