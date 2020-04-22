﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class FailedCanvasManager : BaseCanvasManager
{
    [SerializeField] Button restartButton;
    [SerializeField] Button homeButton;
    [SerializeField] Text coinCountText;
    [SerializeField] CoinCountView coinCountView;
    public readonly ScreenState thisScreen = ScreenState.Failed;

    public override void OnStart()
    {
        base.SetScreenAction(thisScreen: thisScreen);
        restartButton.onClick.AddListener(OnClickRestartButton);
        homeButton.onClick.AddListener(OnClickHomeButton);
        gameObject.SetActive(false);
        coinCountView.OnStart();
    }

    public override void OnUpdate()
    {
        if (Variables.screenState != thisScreen) { return; }

    }

    protected override void OnOpen()
    {
        DOVirtual.DelayedCall(1.2f, () =>
    {
        gameObject.SetActive(true);
    });
    }

    protected override void OnClose()
    {
        gameObject.SetActive(false);
    }

    void OnClickRestartButton()
    {
        Variables.screenState = ScreenState.Initialize;
    }

    void OnClickHomeButton()
    {
        Variables.screenState = ScreenState.Home;
    }
}
