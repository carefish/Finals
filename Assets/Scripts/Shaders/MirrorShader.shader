Shader "Custom/Mirror" {
Properties {
	_Color("See through color", Color) = (0.2, 0.2, 0.2, 0.16)
	_MainTex ("Base (RGB)", 2D) = "white" {}
}
   SubShader {
      Tags { "Queue" = "Transparent" } 
         // draw after all opaque geometry has been drawn
		 
      Pass { 
         Cull Off // draw front and back faces
         ZWrite Off // don't write to depth buffer 
            // in order not to occlude other objects
         Blend Zero OneMinusSrcAlpha // multiplicative blending 
            // for attenuation by the fragment's alpha
 
         CGPROGRAM 
 
         #pragma vertex vert 
         #pragma fragment frag
		 
		 fixed4 _Color;
		 sampler2D _MainTex;
		 
         float4 vert(float4 vertexPos : POSITION) : SV_POSITION 
         {
            return mul(UNITY_MATRIX_MVP, vertexPos);
         }
 
         fixed4 frag(void) : COLOR 
         {
            return _Color; 
         }
 
         ENDCG  
      }
 
      Pass { 
         Cull Off // draw front and back faces
         ZWrite Off // don't write to depth buffer 
            // in order not to occlude other objects
         Blend SrcAlpha One // additive blending to add colors
 
         CGPROGRAM 
 
         #pragma vertex vert 
         #pragma fragment frag
		 
		 fixed4 _Color;
		 sampler2D _MainTex;
		 
         float4 vert(float4 vertexPos : POSITION) : SV_POSITION 
         {
            return mul(UNITY_MATRIX_MVP, vertexPos);
         }
 
         fixed4 frag(void) : COLOR 
         {
            return _Color;
         }
 
         ENDCG  
      }
   }
}