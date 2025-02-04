using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackableImagesManager : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_ImageManager;

    [SerializeField]
    GameObject m_cubePrefab;

    [SerializeField]
    GameObject m_spherePrefab;

    void OnEnable() => m_ImageManager.trackablesChanged.AddListener(OnTrackedImagesChanged);

    void OnDisable() => m_ImageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged);

    public void OnTrackedImagesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        //foreach (var newImage in eventArgs.added)
        foreach (ARTrackedImage newImage in eventArgs.added)
        {
            // Handle added event
            //Créer dequoi
            if (newImage != null) {
                print(newImage.referenceImage.name);
                if (newImage.referenceImage.name == "Cube") {
                    var positionImage = newImage.pose.position;
                    print("cube");
                    Instantiate(m_cubePrefab, positionImage, Quaternion.identity);
                }
                else if (newImage.referenceImage.name == "SPHERE")
                {
                    var positionImage = newImage.pose.position;
                    print("sphere");
                    Instantiate(m_spherePrefab, positionImage, Quaternion.identity);
                }
                else if (newImage.referenceImage.name == "unitylogowhiteonblack")
                {
                    var positionImage = newImage.pose.position;
                    print("unitylogowhiteonblack");
                    Instantiate(m_spherePrefab, positionImage, Quaternion.identity);
                }
            }

        }

        foreach (ARTrackedImage updatedImage in eventArgs.updated)
        {
            // Handle updated event
        }
        /*
        foreach (ARTrackedImage removed in eventArgs.removed)
        {
            // Handle removed event
            TrackableId removedImageTrackableId = removed.Key;
            ARTrackedImage removedImage = removed.Value;
        }*/
    }

}
