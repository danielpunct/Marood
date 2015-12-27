struct ClassRegistrationContext;
void InvokeRegisterStaticallyLinkedModuleClasses(ClassRegistrationContext& context)
{
	// Do nothing (we're in stripping mode)
}

void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_Physics();
	RegisterModule_Physics();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_Terrain();
	RegisterModule_Terrain();

	void RegisterModule_TerrainPhysics();
	RegisterModule_TerrainPhysics();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

}

void RegisterAllClasses()
{
	//Total: 76 classes
	//0. AssetBundle
	void RegisterClass_AssetBundle();
	RegisterClass_AssetBundle();

	//1. NamedObject
	void RegisterClass_NamedObject();
	RegisterClass_NamedObject();

	//2. EditorExtension
	void RegisterClass_EditorExtension();
	RegisterClass_EditorExtension();

	//3. Mesh
	void RegisterClass_Mesh();
	RegisterClass_Mesh();

	//4. Renderer
	void RegisterClass_Renderer();
	RegisterClass_Renderer();

	//5. Component
	void RegisterClass_Component();
	RegisterClass_Component();

	//6. GUILayer
	void RegisterClass_GUILayer();
	RegisterClass_GUILayer();

	//7. Behaviour
	void RegisterClass_Behaviour();
	RegisterClass_Behaviour();

	//8. Texture
	void RegisterClass_Texture();
	RegisterClass_Texture();

	//9. Texture2D
	void RegisterClass_Texture2D();
	RegisterClass_Texture2D();

	//10. RenderTexture
	void RegisterClass_RenderTexture();
	RegisterClass_RenderTexture();

	//11. RectTransform
	void RegisterClass_RectTransform();
	RegisterClass_RectTransform();

	//12. Transform
	void RegisterClass_Transform();
	RegisterClass_Transform();

	//13. TextAsset
	void RegisterClass_TextAsset();
	RegisterClass_TextAsset();

	//14. Shader
	void RegisterClass_Shader();
	RegisterClass_Shader();

	//15. Material
	void RegisterClass_Material();
	RegisterClass_Material();

	//16. Sprite
	void RegisterClass_Sprite();
	RegisterClass_Sprite();

	//17. SpriteRenderer
	void RegisterClass_SpriteRenderer();
	RegisterClass_SpriteRenderer();

	//18. Camera
	void RegisterClass_Camera();
	RegisterClass_Camera();

	//19. MonoBehaviour
	void RegisterClass_MonoBehaviour();
	RegisterClass_MonoBehaviour();

	//20. GameObject
	void RegisterClass_GameObject();
	RegisterClass_GameObject();

	//21. Collider
	void RegisterClass_Collider();
	RegisterClass_Collider();

	//22. CharacterController
	void RegisterClass_CharacterController();
	RegisterClass_CharacterController();

	//23. Collider2D
	void RegisterClass_Collider2D();
	RegisterClass_Collider2D();

	//24. AudioClip
	void RegisterClass_AudioClip();
	RegisterClass_AudioClip();

	//25. SampleClip
	void RegisterClass_SampleClip();
	RegisterClass_SampleClip();

	//26. Animation
	void RegisterClass_Animation();
	RegisterClass_Animation();

	//27. Animator
	void RegisterClass_Animator();
	RegisterClass_Animator();

	//28. DirectorPlayer
	void RegisterClass_DirectorPlayer();
	RegisterClass_DirectorPlayer();

	//29. Font
	void RegisterClass_Font();
	RegisterClass_Font();

	//30. Canvas
	void RegisterClass_Canvas();
	RegisterClass_Canvas();

	//31. CanvasGroup
	void RegisterClass_CanvasGroup();
	RegisterClass_CanvasGroup();

	//32. CanvasRenderer
	void RegisterClass_CanvasRenderer();
	RegisterClass_CanvasRenderer();

	//33. RuntimeAnimatorController
	void RegisterClass_RuntimeAnimatorController();
	RegisterClass_RuntimeAnimatorController();

	//34. PreloadData
	void RegisterClass_PreloadData();
	RegisterClass_PreloadData();

	//35. Cubemap
	void RegisterClass_Cubemap();
	RegisterClass_Cubemap();

	//36. Texture3D
	void RegisterClass_Texture3D();
	RegisterClass_Texture3D();

	//37. LevelGameManager
	void RegisterClass_LevelGameManager();
	RegisterClass_LevelGameManager();

	//38. GameManager
	void RegisterClass_GameManager();
	RegisterClass_GameManager();

	//39. TimeManager
	void RegisterClass_TimeManager();
	RegisterClass_TimeManager();

	//40. GlobalGameManager
	void RegisterClass_GlobalGameManager();
	RegisterClass_GlobalGameManager();

	//41. AudioManager
	void RegisterClass_AudioManager();
	RegisterClass_AudioManager();

	//42. InputManager
	void RegisterClass_InputManager();
	RegisterClass_InputManager();

	//43. Physics2DSettings
	void RegisterClass_Physics2DSettings();
	RegisterClass_Physics2DSettings();

	//44. MeshRenderer
	void RegisterClass_MeshRenderer();
	RegisterClass_MeshRenderer();

	//45. GraphicsSettings
	void RegisterClass_GraphicsSettings();
	RegisterClass_GraphicsSettings();

	//46. MeshFilter
	void RegisterClass_MeshFilter();
	RegisterClass_MeshFilter();

	//47. QualitySettings
	void RegisterClass_QualitySettings();
	RegisterClass_QualitySettings();

	//48. PhysicsManager
	void RegisterClass_PhysicsManager();
	RegisterClass_PhysicsManager();

	//49. MeshCollider
	void RegisterClass_MeshCollider();
	RegisterClass_MeshCollider();

	//50. BoxCollider
	void RegisterClass_BoxCollider();
	RegisterClass_BoxCollider();

	//51. AnimationClip
	void RegisterClass_AnimationClip();
	RegisterClass_AnimationClip();

	//52. Motion
	void RegisterClass_Motion();
	RegisterClass_Motion();

	//53. TagManager
	void RegisterClass_TagManager();
	RegisterClass_TagManager();

	//54. AudioListener
	void RegisterClass_AudioListener();
	RegisterClass_AudioListener();

	//55. AudioBehaviour
	void RegisterClass_AudioBehaviour();
	RegisterClass_AudioBehaviour();

	//56. Avatar
	void RegisterClass_Avatar();
	RegisterClass_Avatar();

	//57. AnimatorController
	void RegisterClass_AnimatorController();
	RegisterClass_AnimatorController();

	//58. ScriptMapper
	void RegisterClass_ScriptMapper();
	RegisterClass_ScriptMapper();

	//59. DelayedCallManager
	void RegisterClass_DelayedCallManager();
	RegisterClass_DelayedCallManager();

	//60. RenderSettings
	void RegisterClass_RenderSettings();
	RegisterClass_RenderSettings();

	//61. Light
	void RegisterClass_Light();
	RegisterClass_Light();

	//62. MonoScript
	void RegisterClass_MonoScript();
	RegisterClass_MonoScript();

	//63. MonoManager
	void RegisterClass_MonoManager();
	RegisterClass_MonoManager();

	//64. FlareLayer
	void RegisterClass_FlareLayer();
	RegisterClass_FlareLayer();

	//65. PlayerSettings
	void RegisterClass_PlayerSettings();
	RegisterClass_PlayerSettings();

	//66. CapsuleCollider
	void RegisterClass_CapsuleCollider();
	RegisterClass_CapsuleCollider();

	//67. SkinnedMeshRenderer
	void RegisterClass_SkinnedMeshRenderer();
	RegisterClass_SkinnedMeshRenderer();

	//68. BuildSettings
	void RegisterClass_BuildSettings();
	RegisterClass_BuildSettings();

	//69. ResourceManager
	void RegisterClass_ResourceManager();
	RegisterClass_ResourceManager();

	//70. TerrainCollider
	void RegisterClass_TerrainCollider();
	RegisterClass_TerrainCollider();

	//71. TerrainData
	void RegisterClass_TerrainData();
	RegisterClass_TerrainData();

	//72. LightmapSettings
	void RegisterClass_LightmapSettings();
	RegisterClass_LightmapSettings();

	//73. Terrain
	void RegisterClass_Terrain();
	RegisterClass_Terrain();

	//74. LightProbes
	void RegisterClass_LightProbes();
	RegisterClass_LightProbes();

	//75. RuntimeInitializeOnLoadManager
	void RegisterClass_RuntimeInitializeOnLoadManager();
	RegisterClass_RuntimeInitializeOnLoadManager();

}
