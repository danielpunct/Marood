// --------------------------------------------------------------------------------------------------------------------
// Data Bind for Unity
// Copyright (c) Slash Games. All rights reserved.
// --------------------------------------------------------------------------------------------------------------------

Setup
-----

- Import DataBind.unitypackage into your project (you probably already did if you read this file).

- If you are using NGUI, double click on the NGUIExtensions.unitypackage in DataBind/Addons to extract the NGUI specific scripts.

- If it's the first time you are using Data Bind for Unity:
-- Check the examples in DataBind/Examples
-- Read through the documentation at http://slashgames.org:8090/display/DBFU
-- The API of the classes is documented at http://slashgames.org/tools/data-bind/api

- If you encounter any issues (bugs, missing features,...) please create a new issue at the official issue tracker at https://bitbucket.org/coeing/data-bind/issues

- Any feedback, positive as well as negative, is always appreciated at contact@slashgames.org or at the official Unity forum thread at http://forum.unity3d.com/threads/released-data-bind-for-unity.298471/ Thanks for your help!

Changelog
---------

Version 1.0.5 (03/12/2015)
**************************

* ADDED: Editor - Showing context data in inspector during runtime.

* ADDED: Editor - Added object field in inspector for data binding if type is Reference.

* ADDED: Operations - Added tween operation to change a number value over time.

* ADDED: Objects - Added simple number object, mainly for testing.

* ADDED: Operations - Added module operation to ArithmeticOperation.

* ADDED: Setters - Added setter for the interactable flag of a CanvasGroup.

* ADDED: Commands - Added base commands for UnityEvents with parameters and multiple target callbacks.

* CHANGED: Setters - Moved ImageMaterialSetter from foundation to UI/Unity.

* ADDED: Setters - Added possibility to hide empty slots and to shift items on remove to SlotItemsSetter.

* ADDED: Setters - Added setter to set the context of a specified context holder.

* ADDED: Setters - Added setter to enable/disable a behaviour.

* ADDED: Operations - Added mapping from string to game object.

* ADDED: Getters - Added provider for transform.position.

* CHANGED: Getters - ComponentSingleGetter overrides OnEnable/OnDisable and calls base method of DataProvider.

* ADDED: Formatters - Added StringToUpperFormatter.

* ADDED: Commands - Catching exception when invoking command to log more helpful message.

* ADDED: Setters - Added setter for the sprite of a sprite renderer.

* ADDED: Setters - Added setter for the material of an image.

* ADDED: Setters - Added setter for a trigger parameter in an animator.

* ADDED: Providers - Added lookup for data dictionary.

* ADDED: Core - Added DataDictionary to have a simple data mapping in contexts.

* ADDED: Context - Added context node which points to an item in an enumerable.

* ADDED: Core - Added constructor for Collection to initialize from IEnumerable.

* CHANGED: Core - Data provider doesn't listen to value changes when not active.

* CHANGED: Setters - SingleSetter catches cast exception to provide more helpful log message.

* ADDED: Core - Added DataBindingType "Reference" to reference a Unity object. Catching cast exception when getting value of data binding. IsInitialized value is set before setting value to be set already on callbacks.

* CHANGED: Formatters - Added bindings for symbols of the DurationFormatter, so it is more generic and can be localized.

* ADDED: Setters - Added items setter for fixed number of provided slots.

* ADDED: Commands - Adding default values for missing parameters when invoking command.

* ADDED: Switches - Added NumberRangeSwitch and base class for range switches.

* ADDED: Providers - Added ColorObject to provide a single color value.

* ADDED: Converters - Added Texture2DToSpriteConverter and base DataConverter.

* ADDED: Context Holder Initializer - Added Reset method to automatically search for context holder on same game object on creation/reset.

* ADDED: Providers - Added BooleanSwitch to provide a different data value depending on a boolean value.

* FIXED: Reflection - Using platform-independent implementations of IsEnum and BaseType.

* ADDED: Core - Added ContextChanged event to ContextHolder.


Version 1.0.4 (25/07/2015)
**************************

* ADDED: Examples - New example with a StringToUpperFormatter which converts a text to upper case.

* FIXED: Core - Private fields of base classes for derived types are not reflected, so base classes have to be searched for data property holders as well.

* CHANGED: StringFormatter - Forwards the format string if string.Format fails.

* ADDED: Setters - Added non-abstract GameObjectItemsSetter to use to instantiate game objects for the items of a collection.
 
* ADDED: Core - Added indexer, IndexOf and RemoveAt method to Collection class.
 
* ADDED: Context Path - Added property to ContextPathAttribute to set a custom display name for the path to be used by the PathPropertyDrawer.
 
* ADDED: Unity UI - Added setter and getter for Toggle.isOn field.

* ADDED: Examples - Added example for doing equality checks and selection for an enum.

* ADDED: Getters - Added getter for the values of a specific enum type.

* ADDED: Type Selection - Added drawer for a selection of a specific type for a base type.

* CHANGED: ItemsSetter - Creating items even if value is just an enumeration and no Collection.

* ADDED: EqualityCheck - Converting string to enum value to check for equality.

* FIXED: PathPropertyDrawer - Custom path wasn't shown initially.

* CHANGED: TextAssetLoader - Adjusted context menu naming to match class name.

* CHANGED: ArithmeticOperation - Renamed parameters from ArgumentA/ArgumentB to First/Second for consistent naming.

* CHANGED: InvertBoolOperation - Renamed Argument to Data for consistent naming.

* CHANGED: TimeFormatter - Renamed to DurationFormatter.

* FIXED: EqualityCheck - Converting data value before doing equality check to consider comparison e.g. to string constant.

* FIXED: PathPropertyDrawer - All arguments of StringFormatter switched to custom path if switching one to it. Storing custom path flag for each property path separately. (Issue: https://bitbucket.org/coeing/data-bind/issue/3/custom-path-is-shown-for-all-path).

* CHANGED: Context Node - Correctly creating context path which starts from context that was determined by the path depth.

* CHANGED: Context Node - Caching master path and contexts at the same time. Depth value defines the path depth, not the context holder depth.

* ADDED: Tests - Added test when using multiple context holders with a master path in between.

* ADDED: Tests - Added unit tests for relative data path.

* ADDED: Diagnostics - Added script to initialize a ContextHolder with a specific context type.

* CHANGED: Data Bind - Clearing cached contexts when hierarchy changed. Otherwise a wrong cached context is used when a game object is placed under a new parent game object, e.g. on lists.


Version 1.0.3 (17/03/2015)
**************************

* CHANGED: Foundation - Moved data providers into Foundation/Providers folder and there into sub folders like Loaders and Operations.

* ADDED: Getters - Using path drop down.

* ADDED: Core - Windows 8 and Windows Phone 8 support. Using Unity platform defines and providing Windows RT implementations for GetField, GetMethod and GetProperty utility methods.

* CHANGED: Examples - Changed command from OnSendMessage to SubmitMessage in InputFieldGetter example.


Version 1.0.2 (28/02/2015)
**************************

* ADDED: Core - Added exceptions if trying to set a read-only property or method.

* CHANGED: Core - DataNode sets value of field or property instead of data property, so even raw members of a context are updated correctly.

* CHANGED: Bindings - Renamed GameObjectSetter to GameObjectSingleSetter.

* CHANGED: Core - Made some methods of context holder virtual to allow deriving from the class if necessary.

* FIXED: Data Bind - Returning path to context if no path is set after #X notation.

* CHANGED: Data Bind - Logging error instead of exception if invalid path was specified (on iOS exceptions caused a crash).

* CHANGED: Editor - Adjusted component menu titles for bindings to be more consistent.

* ADDED: Setters - Added binding to create a child game object from a prefab with a specific context.

* ADDED: GraphicColorSetter - Setter for color of a Graphic component (e.g. Text and Image).

* CHANGED: ArithmeticOperation - Checking second argument for zero before doing division to avoid exception.

* ADDED: Unity UI - Added SelectableInteractableSetter to change if a selectable is interactable depending on a boolean data value.

* ADDED: Operations - Added sprite loader which loads a sprite depending on a string value.

* ADDED: Core - Added log error when context is not derived from Context class, but path is set. This may indicate that the user forgot to derive from Context class.

* ADDED: Context Path - Added property drawer for a context path property.

* CHANGED: Context Holder - Only creating context automatically if explicitly stated and no context is already set in Awake.

Version 1.0.1 (15/02/2015)
**************************

* ADDED: Context - Getting value for context node possible from field as well. 

* FIXED: Property - Null reference check before converting value of data property.

* CHANGED: Collection - Collection base class implements IEnumerable, not IEnumerable<object> so the type of the concrete collection is identified correctly in Linq queries.

* CHANGED: Bindings - Only triggering setters in OnEnable if data binding was already initialized with initial data values.

* FIXED: Command - Safe cast to delegate in Command.

* CHANGED: Foundation - Changed BehaviourSingleGetter/Setter to ComponentSingleGetter/Setter.

* CHANGED: Foundation - Created base class for ItemsSetter to use it for other collection setters as well.

* CHANGED: UnityUI - Made GridItemsSetter for UnityUI more generic to work for all LayoutGroups.

* CHANGED: Active Setter - Changed naming in menu from "Active" to "Active Setter".

* ADDED: Command - Reset method is used to set initial target behaviour.

* ADDED: Bindings - Added several checks, formatters and setters: ComparisonCheck, EqualityCheck, ArithmeticOperation, InvertBoolFormatter, LogicalBoolFormatter, PrependSign, RoundToNearestOperation, TextFileContentFormatter, TimeFormatter, AnimatorBooleanSetter.

* ADDED: NGUI - Added several setters/getters for PopupList, Button and Slider.

* ADDED: Unity UI - Added serveral setters/getters for Slider and Image control.

* ADDED: Foundation - ComponentSingleSetter checks if target is null before updating the component.

* ADDED: Core - Throwing exception if invalid path is passed to context in RegisterListener, RemoveListener or SetValue.

* CHANGED: Game Object Items Setter - Only created items are removed on clear, not all children.