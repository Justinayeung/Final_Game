// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/ColorInvert"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		//_MainTex ("Albedo (RGB)", 2D) = "white" {}
		//_Glossiness ("Smoothness", Range(0,1)) = 0.5
		//_Metallic ("Metallic", Range(0,1)) = 0.0
	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" }

		Pass
	{
		ZWrite On
		ColorMask 0
	}
		Blend OneMinusDstColor OneMinusSrcAlpha
		BlendOp Add

		Pass
	{

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
		uniform float4 _Color;

	struct vertexInput
	{
		float4 vertex: POSITION;
		float4 color : COLOR;
	};

	struct fragmentInput
	{
		float4 pos : SV_POSITION;
		float4 color : COLOR0;
	};

	fragmentInput vert(vertexInput i)
	{
		fragmentInput o;
		o.pos = UnityObjectToClipPos(i.vertex);
		o.color = _Color;
		return o;
	}

	half4 frag(fragmentInput i) : COLOR
	{
		return i.color;
	}

		ENDCG
	}
	}
}