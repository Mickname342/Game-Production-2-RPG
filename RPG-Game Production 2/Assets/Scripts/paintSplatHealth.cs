using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paintSplatHealth : MonoBehaviour
{
    public Sprite fullSplat, halfSplat, emptySplat;
    Image splatimage;

    private void Awake()
    {
        splatimage = GetComponent<Image>();
    }

    public void SetSplatImage(splatStatus status)
    {
        switch (status)
        {
            case splatStatus.Empty:
                splatimage.sprite = emptySplat;
                break;

            case splatStatus.Half:
                splatimage.sprite = halfSplat;
                break;

            case splatStatus.Full:
                splatimage.sprite = fullSplat;
                break;

        }
    }
}

public enum splatStatus
{
    Empty = 0,
    Half = 1,
    Full = 2
}
