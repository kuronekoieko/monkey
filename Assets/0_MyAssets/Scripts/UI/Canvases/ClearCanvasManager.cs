using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class ClearCanvasManager : BaseCanvasManager
{
    [SerializeField] Button nextButton;
    [SerializeField] Text coinCountText;
    [SerializeField] Button homeButton;
    [SerializeField] Image dummyRectangleImage;
    [SerializeField] CoinCountView coinCountView;
    [SerializeField] UICameraController uICameraController;
    public readonly ScreenState thisScreen = ScreenState.Clear;

    public override void OnStart()
    {
        base.SetScreenAction(thisScreen: thisScreen);

        nextButton.onClick.AddListener(OnClickNextButton);
        homeButton.onClick.AddListener(OnClickHomeButton);
        gameObject.SetActive(false);
        dummyRectangleImage.gameObject.SetActive(Debug.isDebugBuild);
        coinCountView.OnStart();
    }

    public override void OnUpdate()
    {
        if (Variables.screenState != thisScreen) { return; }

    }

    protected override void OnOpen()
    {
        uICameraController.PlayConfetti();
        DOVirtual.DelayedCall(1.2f, () =>
        {
            gameObject.SetActive(true);
        });
    }

    protected override void OnClose()
    {
        gameObject.SetActive(false);
    }

    void OnClickNextButton()
    {
        Variables.currentStageIndex++;
        Variables.screenState = ScreenState.Initialize;
    }

    void OnClickHomeButton()
    {
        Variables.screenState = ScreenState.Home;
    }
}
