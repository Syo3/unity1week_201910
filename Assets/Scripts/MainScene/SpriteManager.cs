using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    #region SerializeField
    [SerializeField, Tooltip("オブジェクトスプライト")]
    private List<Sprite> _objectSpriteList;
    [SerializeField, Tooltip("通常ブロック白")]
    private List<Sprite> _normalBlockWhiteSpriteList;
    [SerializeField, Tooltip("ゴール白")]
    private List<Sprite> _goalWhiteSpriteList;
    [SerializeField, Tooltip("リフトブロック白")]
    private List<Sprite> _liftBlockWhiteSpriteList;
    [SerializeField, Tooltip("落下ブロックタイプA")]
    private List<Sprite> _fallBlockWhiteASpriteList;
    #endregion

    #region access
    public List<Sprite> ObjectSpriteList{
        get{return _objectSpriteList;}
    }
    public List<Sprite> NormalBlockWhiteSpriteList{
        get{return _normalBlockWhiteSpriteList;}
    }
    public List<Sprite> GoalWhiteSpriteList{
        get{return _goalWhiteSpriteList;}
    }
    public List<Sprite> LiftBlockWhiteSpriteList{
        get{return _liftBlockWhiteSpriteList;}
    }
    public List<Sprite> FallBlockWhiteASpriteList{
        get{return _fallBlockWhiteASpriteList;}
    }
    #endregion
}
