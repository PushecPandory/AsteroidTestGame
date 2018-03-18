For designers:

To set design variables You should:

1) Create DesignDataGameSettings scriptable object by choosing from top bar Assets/Create/TestGame/DesignDataGameSettings.
2) (Optionaly) Name your created scriptabe object and move it to Assets/DesignDataSettings folder.
3) In GameScene: Attach your DesignDataGameSettings scriptable object to GameSceneManger script which is in GameSceneManger game object.
4) Set values in you scriptabe object

Note that variables once are set on game start and they are not updated during gameplay (writen in that way to improve performance).
However, You can still update them while You're in editor's play mode. To do that, use buttons in the inspector panel in your DesignDataGameSettings scriptable object instance.
For bullets and asteroids, variables will be reloaded and new values will be used when objects will be created (or taken from object pool), so you wont see your changes immidietly.