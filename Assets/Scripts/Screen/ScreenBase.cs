using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens {

    public enum ScreenType {
        Panel,
        Info_Panel,
        Shop
    }

    public class ScreenBase : MonoBehaviour {

        public ScreenType screenType;

        public List<Transform> listOfObjects;

        public bool startHided = false;

        [Header("Animation Settings")]
        public float duration = 0.3f;
        public float timeBetween = 0.05f;
        public Ease ease;

        private void Start() {
            if (startHided) {
                ShowObjects();
            }

        }

        [Button("Show")]
        protected virtual void Show() {
            ShowObjects();
        }

        [Button("Hide")]
        protected virtual void Hide() {
            HideObjects();
        }

        private void ShowObjects() {
            foreach (var i in listOfObjects) {
                i.gameObject.SetActive(true);
                i.DOScale(0, duration).From().SetDelay(timeBetween).SetEase(ease);
            }
        }

        private void ForceShowObjects() {
            foreach (Transform obj in listOfObjects) {
                obj.gameObject.SetActive(true);
            }
        }

        private void HideObjects() {
            foreach (Transform obj in listOfObjects) {
                obj.gameObject.SetActive(false);
            }
        }
    }
}

