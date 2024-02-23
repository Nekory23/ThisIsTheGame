using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggManager : MonoBehaviour
{
    public List<EasterEggNameAndObject> easterEggs;
    [System.Serializable]
    public class EasterEggNameAndObject
    {
        public EasterEgg easterEgg;
        public GameObject easterEggObjectUnlock;
        public GameObject easterEggObject;
    }

    private void Start()
    {
        OnRefresh();
    }

    public void OnRefresh()
    {
        GameSystem gameSystem = FindObjectOfType<GameSystem>();

        foreach (EasterEggNameAndObject easterEggNameAndObject in easterEggs)
        {
            if (gameSystem.GetEasterEgg(easterEggNameAndObject.easterEgg))
            {
                easterEggNameAndObject.easterEggObject.SetActive(true);
                easterEggNameAndObject.easterEggObjectUnlock.SetActive(false);
            }
            else
            {
                easterEggNameAndObject.easterEggObject.SetActive(false);
                easterEggNameAndObject.easterEggObjectUnlock.SetActive(true);
            }
        }
    }
}
