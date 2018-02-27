// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "UNewShader/Custom Standard RongJie"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Color("Color", Color) = (1,1,1,0)
		_MainTex("MainTex", 2D) = "white" {}
		_MetallicGlossMap("MetallicGlossMap", 2D) = "white" {}
		_Metallic("Metallic", Range( 0 , 1)) = 1
		_Glossiness("Glossiness", Range( 0 , 1)) = 1
		_BumpMap("BumpMap", 2D) = "bump" {}
		_BumpScale("BumpScale", Float) = 1
		_OcclusionMap("Occlusion Map", 2D) = "white" {}
		_OcclusionStrength("OcclusionStrength", Range( 0 , 5)) = 1
		_NoiseTex("Noise Tex", 2D) = "white" {}
		_NoiseRemap("NoiseRemap", Vector) = (0,1,-0.7,0.7)
		_RampTex("RampTex", 2D) = "white" {}
		_AlphaRemap("AlphaRemap", Vector) = (0,1,-10,10)
		[HDR]_Color0("Color 0", Color) = (1,0.8068966,0,0)
		_Color1("Color 1", Color) = (1,0,0,0)
		_Color2("Color 2", Color) = (0,0,0,0)
		_RongJie("RongJie", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "AlphaTest+0" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma exclude_renderers xbox360 xboxone ps4 psp2 n3ds wiiu 
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _BumpMap;
		uniform float4 _BumpMap_ST;
		uniform float _BumpScale;
		uniform float4 _Color;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float4 _Color2;
		uniform float4 _Color0;
		uniform float4 _Color1;
		uniform sampler2D _RampTex;
		uniform sampler2D _NoiseTex;
		uniform float4 _NoiseTex_ST;
		uniform float _RongJie;
		uniform float4 _NoiseRemap;
		uniform float4 _AlphaRemap;
		uniform sampler2D _MetallicGlossMap;
		uniform float4 _MetallicGlossMap_ST;
		uniform float _Metallic;
		uniform float _Glossiness;
		uniform sampler2D _OcclusionMap;
		uniform float4 _OcclusionMap_ST;
		uniform float _OcclusionStrength;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_BumpMap = i.uv_texcoord * _BumpMap_ST.xy + _BumpMap_ST.zw;
			float3 lerpResult49 = lerp( float3(0,0,1) , UnpackNormal( tex2D( _BumpMap, uv_BumpMap ) ) , _BumpScale);
			o.Normal = lerpResult49;
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			o.Albedo = ( _Color * tex2D( _MainTex, uv_MainTex ) ).rgb;
			float2 uv_NoiseTex = i.uv_texcoord * _NoiseTex_ST.xy + _NoiseTex_ST.zw;
			float temp_output_75_0 = ( tex2D( _NoiseTex, uv_NoiseTex ).r + (_NoiseRemap.z + (( 1.0 - _RongJie ) - _NoiseRemap.x) * (_NoiseRemap.w - _NoiseRemap.z) / (_NoiseRemap.y - _NoiseRemap.x)) );
			float clampResult78 = clamp( (_AlphaRemap.z + (temp_output_75_0 - _AlphaRemap.x) * (_AlphaRemap.w - _AlphaRemap.z) / (_AlphaRemap.y - _AlphaRemap.x)) , 0.0 , 1.0 );
			float2 appendResult80 = (float2(( 1.0 - clampResult78 ) , 0.0));
			float4 tex2DNode83 = tex2D( _RampTex, appendResult80 );
			float4 lerpResult85 = lerp( _Color0 , _Color1 , tex2DNode83.g);
			float4 lerpResult87 = lerp( _Color2 , lerpResult85 , tex2DNode83.r);
			o.Emission = lerpResult87.rgb;
			float2 uv_MetallicGlossMap = i.uv_texcoord * _MetallicGlossMap_ST.xy + _MetallicGlossMap_ST.zw;
			float4 tex2DNode43 = tex2D( _MetallicGlossMap, uv_MetallicGlossMap );
			o.Metallic = ( tex2DNode43 * _Metallic ).r;
			o.Smoothness = ( tex2DNode43.a * _Glossiness );
			float2 uv_OcclusionMap = i.uv_texcoord * _OcclusionMap_ST.xy + _OcclusionMap_ST.zw;
			float4 temp_cast_3 = (_OcclusionStrength).xxxx;
			float4 clampResult64 = clamp( pow( tex2D( _OcclusionMap, uv_OcclusionMap ) , temp_cast_3 ) , float4( 0,0,0,0 ) , float4( 1,1,1,1 ) );
			o.Occlusion = clampResult64.r;
			o.Alpha = 1;
			clip( temp_output_75_0 - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13901
1927;29;1906;1004;54.29456;-258.8632;1;True;True
Node;AmplifyShaderEditor.CommentaryNode;68;-616.3252,1397.224;Float;False;815.5631;448.0001;Noise Alpha;6;75;74;73;71;70;69;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;69;-566.3252,1481.053;Float;False;Property;_RongJie;RongJie;17;0;0;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.OneMinusNode;70;-444.9201,1567.224;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.Vector4Node;71;-476.9202,1638.224;Float;False;Property;_NoiseRemap;NoiseRemap;11;0;0,1,-0.7,0.7;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;73;-291.9192,1447.224;Float;True;Property;_NoiseTex;Noise Tex;10;0;Assets/AmplifyShaderEditor/Examples/Community/Dissolve Burn/dissolve-guide.png;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.TFHCRemapNode;74;-219.9191,1643.224;Float;False;5;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;1.0;False;3;FLOAT;0.0;False;4;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.CommentaryNode;72;-623.2402,1872.556;Float;False;857.0649;337.2402;Ramp UV;6;83;80;79;78;77;76;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;75;67.63766,1565.84;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.Vector4Node;76;-607.2401,1977.249;Float;False;Property;_AlphaRemap;AlphaRemap;13;0;0,1,-10,10;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.TFHCRemapNode;77;-390.24,1982.249;Float;False;5;0;FLOAT;0.0;False;1;FLOAT;0,0,0,0;False;2;FLOAT;1,0,0,0;False;3;FLOAT;0,0,0,0;False;4;FLOAT;1,0,0,0;False;1;FLOAT
Node;AmplifyShaderEditor.ClampOpNode;78;-212.0972,1980.886;Float;False;3;0;FLOAT;0,0,0,0;False;1;FLOAT;0.0;False;2;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.OneMinusNode;79;-214.8091,2102.52;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.CommentaryNode;65;-476.1666,893.8136;Float;False;607.3477;363.9742;Ao;4;57;60;58;64;;0.625,0.625,0.625,1;0;0
Node;AmplifyShaderEditor.DynamicAppendNode;80;-29.71728,2107.796;Float;False;FLOAT2;4;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;3;FLOAT;0.0;False;1;FLOAT2
Node;AmplifyShaderEditor.ColorNode;82;258.8499,2013.353;Float;False;Property;_Color1;Color 1;15;0;1,0,0,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.CommentaryNode;62;-492.0122,-186.4179;Float;False;545.5683;485;Diffuse;2;1;2;;1,1,1,1;0;0
Node;AmplifyShaderEditor.ColorNode;81;259.8899,2221.952;Float;False;Property;_Color0;Color 0;14;1;[HDR];1,0.8068966,0,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;58;-414.6297,1142.788;Float;False;Property;_OcclusionStrength;OcclusionStrength;9;0;1;0;5;0;1;FLOAT
Node;AmplifyShaderEditor.CommentaryNode;61;-479.1005,381.8319;Float;False;585.5945;474.8305;Metallic;4;43;44;48;47;;1,0.8068966,0,1;0;0
Node;AmplifyShaderEditor.SamplerNode;83;-48.17528,1922.556;Float;True;Property;_RampTex;RampTex;12;0;Assets/贴图/Ramp.tga;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;60;-426.1666,943.8136;Float;True;Property;_OcclusionMap;Occlusion Map;8;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.CommentaryNode;53;-1238.976,126.19;Float;False;631.326;508.1469;Normal;4;49;45;52;50;;0,0,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;45;-1188.976,404.3369;Float;True;Property;_BumpMap;BumpMap;6;0;None;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT3;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;47;-422.4456,638.8894;Float;False;Property;_Metallic;Metallic;4;0;1;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;2;-442.0122,68.58211;Float;True;Property;_MainTex;MainTex;2;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.PowerNode;57;-58.77545,950.7366;Float;False;2;0;COLOR;0,0,0,0;False;1;FLOAT;0.0;False;1;COLOR
Node;AmplifyShaderEditor.RangedFloatNode;52;-1086.988,323.6929;Float;False;Property;_BumpScale;BumpScale;7;0;1;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;43;-429.1005,431.8319;Float;True;Property;_MetallicGlossMap;MetallicGlossMap;3;0;None;True;0;True;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.Vector3Node;50;-1095.551,176.1902;Float;False;Constant;_blue;blue;8;0;0,0,1;0;4;FLOAT3;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.LerpOp;85;760.6707,2127.712;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.ColorNode;84;259.2899,1824.672;Float;False;Property;_Color2;Color 2;16;0;0,0,0,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ColorNode;1;-406.8508,-136.4179;Float;False;Property;_Color;Color;1;0;1,1,1,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;5;-415.4355,756.1721;Float;False;Property;_Glossiness;Glossiness;5;0;1;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.LerpOp;49;-791.6517,232.6902;Float;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0.0,0,0;False;1;FLOAT3
Node;AmplifyShaderEditor.LerpOp;87;1059.429,1887.211;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.ClampOpNode;64;-52.81894,1073.143;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,1,1,1;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;48;-62.50597,564.7018;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-119.0291,-107.4925;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.LerpOp;86;839.13,1883.907;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;44;-64.78519,714.1808;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;718.5122,287.3386;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;UNewShader/Custom Standard RongJie;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;0;False;0;0;Custom;0.5;True;True;0;False;Opaque;AlphaTest;All;True;True;True;True;True;True;True;False;False;False;False;False;False;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;0;4;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;0;0;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;FLOAT;0.0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;70;0;69;0
WireConnection;74;0;70;0
WireConnection;74;1;71;1
WireConnection;74;2;71;2
WireConnection;74;3;71;3
WireConnection;74;4;71;4
WireConnection;75;0;73;1
WireConnection;75;1;74;0
WireConnection;77;0;75;0
WireConnection;77;1;76;1
WireConnection;77;2;76;2
WireConnection;77;3;76;3
WireConnection;77;4;76;4
WireConnection;78;0;77;0
WireConnection;79;0;78;0
WireConnection;80;0;79;0
WireConnection;83;1;80;0
WireConnection;57;0;60;0
WireConnection;57;1;58;0
WireConnection;85;0;81;0
WireConnection;85;1;82;0
WireConnection;85;2;83;2
WireConnection;49;0;50;0
WireConnection;49;1;45;0
WireConnection;49;2;52;0
WireConnection;87;0;84;0
WireConnection;87;1;85;0
WireConnection;87;2;83;1
WireConnection;64;0;57;0
WireConnection;48;0;43;0
WireConnection;48;1;47;0
WireConnection;3;0;1;0
WireConnection;3;1;2;0
WireConnection;86;1;85;0
WireConnection;86;2;83;1
WireConnection;44;0;43;4
WireConnection;44;1;5;0
WireConnection;0;0;3;0
WireConnection;0;1;49;0
WireConnection;0;2;87;0
WireConnection;0;3;48;0
WireConnection;0;4;44;0
WireConnection;0;5;64;0
WireConnection;0;10;75;0
ASEEND*/
//CHKSM=5105A2380BFC3EB24202281A1A347C4C8ED54D20