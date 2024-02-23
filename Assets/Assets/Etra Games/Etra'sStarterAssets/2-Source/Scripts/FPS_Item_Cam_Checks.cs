using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FPS_Item_Cam_Checks : MonoBehaviour
{

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        int layerCheck = LayerMask.NameToLayer("EtraFPSUsableItem");
        if (layerCheck == -1)
        {
            Debug.LogError("New layer EtraFPSUsableItem must be created and assigned in Layer Manager so FPSUsableItems can be seen by the FPSUsableItemsCamera and Player.");
        }
        // Get the render pipeline asset currently in use
        // var renderPipelineAsset = GraphicsSettings.renderPipelineAsset;
        // if (renderPipelineAsset != null)
        // {
        //     // Check the name of the asset
        //     if (renderPipelineAsset.name == "Ultra_PipelineAsset" || renderPipelineAsset.name == "Universal Render Pipeline Asset")
        //     {
                Camera FPS_Item_Camera = this.GetComponent<Camera>();
                var Item_Cam_Data = FPS_Item_Camera.GetUniversalAdditionalCameraData();
                Item_Cam_Data.renderType = CameraRenderType.Overlay;

                Camera mainCam = Camera.main;
                var mainCameraData = mainCam.GetUniversalAdditionalCameraData();

                if (mainCameraData.cameraStack.Count == 0)
                {
                    mainCameraData.cameraStack.Add(FPS_Item_Camera);
                }
            // }

        // }

    }

}
