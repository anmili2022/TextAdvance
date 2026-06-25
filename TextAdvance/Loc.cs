namespace TextAdvance;

internal static class Loc
{
    public const string TabGeneralConfig = "通用设置";
    public const string TabTargetIndicators = "目标指示器";
    public const string TabAutoEnable = "自动启用";
    public const string TabPerAreaConfig = "区域设置";
    public const string TabDebug = "调试";

    public const string SectionPluginOperation = "插件操作";
    public const string SectionKeybinds = "快捷键";
    public const string SectionFunctions = "功能";
    public const string SectionOverlay = "悬浮层";
    public const string SectionNotifications = "通知";
    public const string SectionRewardPickingOrder = "奖励选择顺序";
    public const string SectionNavigation = "导航";

    public const string RemoveAllLocks = "移除所有锁定";
    public const string CancelExternalControl = "取消外部控制";
    public const string EnablePluginNonPersistent = "启用插件（不保存状态）";
    public const string DontAutoDisableOnLogout = "登出时不要自动禁用插件";
    public const string EnableQuestTargetIndicatorsGlobal = "启用任务目标指示器（全局，保存设置）";
    public const string EnableIndicatorsWhenDisabled = "插件禁用时仍显示指示器";
    public const string EnableFinderWhenDisabled = "插件禁用时仍启用查找器";
    public const string SplatoonRequiredForIndicators = "任务目标指示器需要安装并启用 Splatoon 插件";
    public const string AutoInteractMaxRadius = "自动交互最大半径";
    public const string AutoInteractRadiusWarning = "半径调低可能导致部分交互失效";
    public const string HoldToDisable = "插件启用时，按住以下按键临时禁用：";
    public const string HoldToEnable = "插件禁用时，按住以下按键临时启用：";

    public const string AutomaticQuestAccept = "自动接取任务";
    public const string AutomaticQuestComplete = "自动完成任务";
    public const string AutomaticRewardPick = "自动选择奖励";
    public const string AutomaticTalkSkip = "自动跳过对话";
    public const string AutoConfirmRequestHandins = "自动确认交付请求";
    public const string AutomaticRequestFill = "自动填充交付物品";
    public const string AutomaticEscDuringCutscene = "过场中自动按 ESC";
    public const string AutomaticCutsceneSkipConfirmation = "自动确认跳过过场";
    public const string AutomaticQuestObjectInteraction = "自动交互任务相关对象";

    public const string HelpQuestAccept = "与任务发起 NPC 对话时自动接取新任务";
    public const string HelpQuestComplete = "与任务完成 NPC 对话时自动完成任务";
    public const string HelpRewardPick = "根据下方配置的简单规则自动选择任务完成奖励";
    public const string HelpTalkSkip = "自动推进大多数字幕/对话，部分字幕可能仍需手动推进。";
    public const string HelpRequestHandins = "物品请求填充后自动确认。部分请求可能无法自动确认。";
    public const string HelpRequestFill = "自动填充物品请求窗口。部分请求可能无法自动填充。";
    public const string HelpRequestFillQuality = "NQ：优先使用普通品质物品，保留更有价值的 HQ 物品。\nHQ：优先使用高品质物品。\n任意：使用第一个可用物品（游戏默认）。";
    public const string HelpCutsceneEsc = "可跳过的过场中自动按 ESC，不会跳过正常不可跳过的过场。";
    public const string HelpCutsceneSkipConfirmation = "按下 ESC 后自动确认跳过过场。";
    public const string HelpQuestObjectInteraction = "自动与附近任务相关 NPC 和物体交互。";

    public const string Any = "任意";
    public const string EnableOverlayWhenPluginEnabled = "插件启用时显示悬浮层";
    public const string OverlayOffset = "悬浮层偏移";
    public const string DisableManualStateNotification = "禁用手动切换插件状态通知";
    public const string DisableAutoEnableLoginNotification = "角色登录自动启用时不显示通知";
    public const string DisableRewardPickChatNotification = "禁用奖励选择聊天通知";
    public const string RewardPrecisionWarning = "注意：无法保证选择结果完全精确。";
    public const string Enabled = "启用";
    public const string NoMount = "不使用坐骑";
    public const string MountRoulette = "随机坐骑";
    public const string Search = "搜索";
    public const string AutoInteractUponArrival = "到达后自动交互";
    public const string UseSprintAndPeloton = "可用时使用疾跑和速行";
    public const string PrintNavigationStatusToChat = "在聊天栏输出导航状态";
    public const string AllowFlightExperimental = "（非常实验性）允许飞行";

    public const string SplatoonFunctionsRequirePlugin = "这些功能需要安装并启用 Splatoon 插件。";
    public const string SplatoonNotInstalled = "尚未安装 Splatoon。";
    public const string GetSplatoon = "获取 Splatoon";
    public const string DisplayQuestTargetIndicators = "显示任务目标指示器";
    public const string QuestTargetIndicatorColor = "任务目标指示器颜色";
    public const string QuestTargetIndicatorTether = "任务目标指示器连线";
    public const string QuestTargetIndicatorThickness = "任务目标指示器粗细";
    public const string EnableEventObjectFinder = "启用事件物体查找器";
    public const string EnableEventNpcFinder = "启用事件 NPC 查找器";
    public const string DisplayOnlyWhileHoldingKey = "仅按住按键时显示";

    public const string AutoEnableCharacters = "使用以下角色登录时自动启用插件：";
    public const string Delete = "删除";
    public const string AddCurrentCharacter = "添加当前角色";
    public const string CharacterName = "角色名";
    public const string Add = "添加";

    public const string GlobalEnableOverridesLocal = "全局启用时覆盖区域设置";
    public const string GlobalEnableOverridesLocalHelp = "勾选后，使用 /at 命令启用插件时会忽略区域单独设置，并使用全局设置。\n未勾选时，无论插件全局状态如何，都会优先使用区域设置。";
    public const string CurrentPluginStateGlobal = "当前插件状态：全局 ";
    public const string CurrentPluginStateLocal = "，当前区域 ";
    public const string StateEnabled = "启用";
    public const string StateDisabled = "禁用";
    public const string SelectArea = "选择区域...";
    public const string Filter = "过滤";
    public const string OnlyModified = "仅显示已修改";
    public const string RemoveCustomSettings = "移除自定义设置";
    public const string AutomaticRewardPickBeta = "自动选择奖励（RP）（测试）";
    public const string SemiAutomaticRequestHandin = "半自动确认交付请求";
    public const string AutomaticRequestFillNew = "自动填充交付物品（RF）（新）";
    public const string NoCustomAreaSettings = "当前区域没有自定义设置。";
    public const string CreateCustomSettings = "创建自定义设置";

    public static string BlockedByPlugins(string plugins) => $"TextAdvance 已被这些插件暂停：{plugins}";

    public static string ExternallyControlledBy(string requester) => $"TextAdvance 正在由 {requester} 外部控制，当前所有设置都会被忽略。";

    public static string SplatoonInstalledEnabled(string version) => $"已安装并启用 Splatoon v{version}。";

    public static string SplatoonInstalledDisabled(string version) => $"已安装 Splatoon v{version}，但尚未启用。";

    public static string CurrentArea(string area) => $"当前区域：{area}";
}
