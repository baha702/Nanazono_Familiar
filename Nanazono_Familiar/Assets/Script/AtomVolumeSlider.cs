using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomVolumeSlider : MonoBehaviour
{
    /* フィールドを追加 */
    public Slider volSlider;
    public Slider pitchSlider;

    private CriAtomSource atomSrc;

    void Start()
    {
        atomSrc = (CriAtomSource)GetComponent("CriAtomSource");
    }

    public void PlaySound()
    {
        if (atomSrc != null)
        {
            atomSrc.Play();
        }
    }

    public void PlayAndStopSound()
    {
        if (atomSrc != null)
        {
            CriAtomSource.Status status = atomSrc.status;
            if ((status == CriAtomSource.Status.Stop) || (status == CriAtomSource.Status.PlayEnd))
            {
                atomSrc.Play();
            }
            else
            {
                atomSrc.Stop();
            }
        }
    }

    /* イベントコールバック用関数を追加 */
    public void OnVolSliderChanged()
    {
        atomSrc.volume = volSlider.value;
    }

    public void OnPitchSliderChanged()
    {
        atomSrc.pitch = pitchSlider.value;
    }
}
