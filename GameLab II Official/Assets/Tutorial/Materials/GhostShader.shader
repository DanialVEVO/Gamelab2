Shader "Experiments/GhostShader" 
{
    Properties 
    {
        _Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
        _OuterRimPower ("Outer Rim Power", Range(0.1, 10)) = 3.0
        _InnerRimPower ("Inner Rim Power", Range(0.1, 10)) = 3.0
    }

//    SubShader {
//        Pass {
//            Tags{ "LightMode" = "ForwardBase" "RenderType" = "Transparent" "Queue" = "Transparent"
//            }
//            Blend SrcAlpha OneMinusSrcAlpha

    SubShader 
    {
    	Tags{"RenderType" = "Transparent" "Queue" = "Transparent"}
    	Pass
    	{
    		ColorMask 0
    	}
        Pass 
        {
            Tags{ "LightMode" = "ForwardBase"}
            ZWrite off
            Blend SrcAlpha OneMinusSrcAlpha
            ColorMask RGB
            CGPROGRAM

            // pragmas
            #pragma vertex vert
            #pragma fragment frag

            // user-defined variables
            uniform fixed4 _Color;
            uniform half _OuterRimPower;
            uniform half _InnerRimPower;

            // Unity-defined variables
            uniform half4 _LightColor0;

            // base input structs
            struct vertexInput 
            {
                half4 vertex : POSITION;
                half3 normal : NORMAL;
            };
            struct vertexOutput 
            {
                half4 pos : SV_POSITION;
                half4 posWorld : TEXCOORD0;
                half3 normalDir : TEXCOORD1;
            };

            // vertex function
            vertexOutput vert(vertexInput v) 
            {
                vertexOutput o;
                o.posWorld = mul(_Object2World, v.vertex);
                o.normalDir = normalize(mul(half4(v.normal, 0.0), _World2Object).xyz);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }

            // fragment function
            fixed4 frag(vertexOutput i) : COLOR 
            {
                fixed rim = 1 - saturate(dot(normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz), i.normalDir));

                return half4(_Color.rgb, _Color.a * pow(rim, _InnerRimPower)) + (half4(1.0, 1.0, 1.0, 1.0) * pow(rim, _OuterRimPower));
            }
            ENDCG
        }
    }
}