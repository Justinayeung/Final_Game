﻿Shader "Custom/RevealBackfaces"
{
	Properties{ //Used for debugging
		_MainTex("Base (RGB)", 2D) = "white" { }
	}
		SubShader{
		// Render the front-facing parts of the object.
		// We use a simple white material, and apply the main texture.
		Pass {
			Material {
				Diffuse(1,1,1,1)
			}
			Lighting On
			SetTexture[_MainTex] {
				Combine Primary * Texture
			}
		}

		// Now we render the back-facing triangles in BRIGHT PINK!
		Pass {
			Color(1,0,1,1)
			Cull Front
		}
	}

}
