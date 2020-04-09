Shader "Custom/ReflectionShader"
{
	//Property data: Colors, textures, values set by user in the inspector
	//Will affect vertex function and fragment function
    Properties //Public variables in unity
    {
		//Texture, type of texture is 2D, and default is white -- NO semi-colon
        _MainTex ("Albedo Texture", 2D) = "white" {}
		[HideInInspector] _ReflectionTex("", 2D) = "white" {}
    }

    SubShader //Actual code that contains instructions for unity to render
    {
        Tags { "RenderType"="Opaque" } //Tags tells how unity will render
        LOD 100 //Level of Detail

        Pass //Set pass call, draw call, single instruction to the CPU to draw something
        {
            CGPROGRAM //Actual CG code that will run on the GPU
            #pragma vertex vert //Have a vertex function called vert
            #pragma fragment frag //Have a vertex function called frag
            // make fog work
            //#pragma multi_compile_fog
			
            #include "UnityCG.cginc" //Unlike C# shaders don't use inheritance(mono), so you have to include it here

			//struct = data objects that are passed to two functions vert and frag
			
			//struct appdata
            //{
			//	 float4 pos : POSITION; //float 4 = a variable that includes 4 floating point numbers (x, y, z, w)
            //   float2 uv : TEXCOORD0;
            //};

            struct v2f //Vert to frag
            {
                //UNITY_FOG_COORDS(1)
				float2 uv : TEXCOORD0;
				float4 refl : TEXCOORD1;
                float4 pos : SV_POSITION; //Saying that float4 pos is a screen space position
            };

            float4 _MainTex_ST;
			//Prepares all vertices of the model to be rendered
            v2f vert (float4 pos : POSITION, float2 uv : TEXCOORD0) //vert fuction is executed first, takes the shape of the model, potentially modifies it
            {
                v2f o; //Calling struct v2f;
                o.pos = UnityObjectToClipPos(pos); //Setting o.pos (from struct v2f) equal to a unityobjectclippos (local space -> world space -> view space -> clip space -> screen space)
                o.uv = TRANSFORM_TEX(uv, _MainTex); //Transform the texture, takes uv data from the model, takes data from the main teture
				o.refl = ComputeScreenPos(o.pos); //Computes texture coordinate for doing a screenspace-mapped texture sample
				
				//UNITY_TRANSFER_FOG(o,o.vertex);
                return o; //Return the struct
            }

			sampler2D _MainTex;
			sampler2D _ReflectionTex;
			//Takes in a v2f struct called i and is bound to SV_Target (a render target)
            fixed4 frag (v2f i) : SV_Target //frag function applies color to the shape output by the vert function
            {
                // sample the texture
				//float4 _name = tex2D( sampler,  float2( texX / texW, texY/texW );
                fixed4 tex = tex2D(_MainTex, i.uv); //new color variable is equal to tex2d(main texture from properties, and data from v2f strct) 
				
				//float4 _name = tex2Dporj(sampler, float4(texX, texY, texZ, texW));
				// tex2dproj() is similar to tex2(), it just divide input's xy by w in hardware before sampling
				fixed4 refl = tex2Dproj(_ReflectionTex, UNITY_PROJ_COORD(i.refl));

				// apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                return tex * refl;
            }
            ENDCG
        }
    }
}
