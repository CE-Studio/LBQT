using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalController:MonoBehaviour {

    public Transform player;
    public Transform tracker;
    public Transform point;
    public Transform camera;
    public Camera portalCam;
    private Camera playerCam;
    private float nearClipOffset = 0.0f;
    private float nearClipLimit = 0.0f;

    // Start is called before the first frame update
    void Start() {
        playerCam = player.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        (tracker.position, tracker.rotation) = (player.position, player.rotation);
        (camera.localPosition, camera.localRotation) = (tracker.localPosition, tracker.localRotation);
        //SetNearClipPlane();
    }


    //https://github.com/SebLague/Portals/blob/master/Assets/Scripts/Core/Portal.cs
    void SetNearClipPlane() {
        // Learning resource:
        // http://www.terathon.com/lengyel/Lengyel-Oblique.pdf
        Transform clipPlane = point;
        int dot = System.Math.Sign(Vector3.Dot(clipPlane.forward, transform.position - portalCam.transform.position));

        Vector3 camSpacePos = portalCam.worldToCameraMatrix.MultiplyPoint(clipPlane.position);
        Vector3 camSpaceNormal = portalCam.worldToCameraMatrix.MultiplyVector(clipPlane.forward) * dot;
        float camSpaceDst = -Vector3.Dot(camSpacePos, camSpaceNormal) + nearClipOffset;

        // Don't use oblique clip plane if very close to portal as it seems this can cause some visual artifacts
        if (Mathf.Abs(camSpaceDst) > nearClipLimit) {
            Vector4 clipPlaneCameraSpace = new Vector4(camSpaceNormal.x, camSpaceNormal.y, camSpaceNormal.z, camSpaceDst);

            // Update projection based on new clip plane
            // Calculate matrix with player cam so that player camera settings (fov, etc) are used
            portalCam.projectionMatrix = playerCam.CalculateObliqueMatrix(clipPlaneCameraSpace);
        } else {
            portalCam.projectionMatrix = playerCam.projectionMatrix;
        }
    }
}
