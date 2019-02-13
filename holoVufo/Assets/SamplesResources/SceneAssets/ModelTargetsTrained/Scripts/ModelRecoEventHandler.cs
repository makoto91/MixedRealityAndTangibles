/*==============================================================================
Copyright (c) 2018 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
==============================================================================*/
using UnityEngine;
using Vuforia;

public class ModelRecoEventHandler : BaseModelRecoEventHandler
{

    public CanvasGroup availableTargetsCanvas;

    #region PUBLIC_METHODS

    private void Awake()
    {
        if (availableTargetsCanvas)
        {
            availableTargetsCanvas.alpha = 1;
        }
    }

    public override void OnNewSearchResult(TargetFinder.TargetSearchResult searchResult)
    {
        base.OnNewSearchResult(searchResult);

        if (availableTargetsCanvas)
        {
            availableTargetsCanvas.alpha = 0;
        }
    }

    #endregion // PUBLIC_METHODS
}
