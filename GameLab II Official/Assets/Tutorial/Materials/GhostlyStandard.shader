Shader "Custom/GhostlyStandard" 
{
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("BaseColor (RGB)", 2D) = "white" {}
		//_Glossiness ("Smoothness (B)", 2D) = "black" {}
		//_Metallic ("Metallic (R)", 2D) = "black" {}
		_Normal ("Normal (RGB)", 2D) = "bumb" {}
		_Emission ("Emission (RGB)", 2D) = "white" {}
		_EmissionColor ("Emission Color", Color) = (0,0,0,0)

		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		_RimColorPow("GhostFade", Range (0,5)) = 2.5
		_RimHiLitePow("GhostHighlight", Range (0,5)) = 2.5
	}
	SubShader 
	{
		Tags{"RenderType" = "Transparent" "Queue" = "Transparent" "ForceNoShadowCasting" = "True"}
		LOD 200
		Pass
    	{
    		ColorMask 0
    	}
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		//#pragma surface surf Standard fullforwardshadows alpha:fade
		#pragma surface surf Standard alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		//sampler2D _Glossiness;
		//sampler2D _Metallic;
		sampler2D _Normal;
		sampler2D _Emission;

		struct Input 
		{
			float2 uv_MainTex;
			float3 viewDir;
		};

		half _Glossiness;
		half _Metallic;
		half _RimColorPow;
		half _RimHiLitePow;
		fixed4 _Color;
		half4 _EmissionColor;

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			//fixed4 g = tex2D (_Glossiness, IN.uv_MainTex);
			//fixed4 m = tex2D (_Metallic, IN.uv_MainTex);
			half4 e = tex2D (_Emission, IN.uv_MainTex) * _EmissionColor;
			o.Albedo = c.rgb*c.a;
			// Metallic and smoothness come from slider variables
			//o.Metallic = m.r;
			//o.Smoothness = g.b;
			o.Smoothness = _Glossiness;
			o.Metallic = _Metallic;
			o.Normal = UnpackNormal (tex2D (_Normal, IN.uv_MainTex));

			half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
			half rcp = pow (rim, _RimColorPow);
			half rhp = pow (rim, _RimHiLitePow);
			o.Emission = (e.rgb  * rcp + half4(1.0, 1.0, 1.0, 1.0) * rhp) * e.a;
			//o.Emission = (e.rgb  * rcp) * e.a;

			//_Color.a * pow(rim, _InnerRimPower)) + (half4(1.0, 1.0, 1.0, 1.0) * pow(rim, _OuterRimPower)
		  
			o.Alpha = c.a + ((e.a * rcp) + (e.a * rhp));
			//o.Alpha = c.a + e.a;
			//o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
