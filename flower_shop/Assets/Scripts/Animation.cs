using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class Animation : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI end_text;

    private PointEnum.kind kind;

    // Start is called before the first frame update
    public void Initialize(PointEnum.kind kind)
    {
        this.kind = kind;
        switch(kind)
        {
            case PointEnum.kind.RESPECT:
                end_text.text = "先輩に尊敬を伝えました";
                break;
            case PointEnum.kind.LOVE:
                end_text.text = "先輩に好意を伝えました";
                break;
            case PointEnum.kind.THANK:
                end_text.text = "先輩に感謝を伝えました";
                break;
        }
    }

    public void OnClickTwitter (){
        AudioManager.Instance.PlaySE("SE2");
        string text = "";
        switch(kind)
        {
            case PointEnum.kind.RESPECT:
                text = "先輩に尊敬を伝えました";
                break;
            case PointEnum.kind.LOVE:
                text = "先輩に好意を伝えました";
                break;
            case PointEnum.kind.THANK:
                text = "先輩に感謝を伝えました";
                break;
        }
        naichilab.UnityRoomTweet.Tweet ("the_language_of_flowers", text, "秘密の花", "unity1week");
    }

    public void OnClickReplay(){
        AudioManager.Instance.PlaySE("SE2");
        // 現在のSceneを取得
        Scene loadScene = SceneManager.GetActiveScene();
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(loadScene.name);
    }
}
