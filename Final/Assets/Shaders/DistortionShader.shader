Shader "Custom/DistortionShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_DistortionFrequency("Distortion Frequency", Range(1, 256)) = 50
        _DistortionScale("Distortion Scale", Range(0, 1)) = 0.1
		_DistortionSpeed("Distortion Speed", Range(0, 10)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		float _DistortionFrequency;
		float _DistortionScale;
		float _DistortionSpeed;

        struct Input
        {
            float2 uv_MainTex;
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        //UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        //UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
			//half4 = a 16 bit floating point
			//Half precision is useful for short vectors, directions, object space positions, high dynamic range colors
			half4 c = tex2D(_MainTex, IN.uv_MainTex + float2(_DistortionScale, 0)*sin((_Time*_DistortionSpeed + IN.uv_MainTex.y)*_DistortionFrequency));
			o.Albedo = c.rgb;
			o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
