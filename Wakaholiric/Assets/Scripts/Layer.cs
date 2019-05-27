using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Layer : MonoBehaviour
{
    RawImage m_rawImage;

    public void UpdateTexture (Texture texture) {
        if( texture == null ){
            m_rawImage.enabled = false;
            m_rawImage.texture = null;
        } else {
            m_rawImage.texture = texture;
            m_rawImage.enabled = true;
            TextureresourceManager.Mark(texture.name);
        }
    }

#region UNITY_DELEGATE

    void Awake () {
        m_rawImage = GetComponent<RawImage>();
        gameObject.tag = "Layer";

        Debug.Log("rawImage\n"+m_rawImage);
        // null
        m_rawImage.enabled = false;
    }
#endregion
}
