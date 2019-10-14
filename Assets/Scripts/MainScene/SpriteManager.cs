using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    #region SerializeField
    [SerializeField, Tooltip("オブジェクトスプライト")]
    private List<Sprite> _objectSpriteList;
    #endregion

    #region access
    public List<Sprite> ObjectSpriteList{
        get{return _objectSpriteList;}
    }
    #endregion
}
