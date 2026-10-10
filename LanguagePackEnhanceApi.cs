#nullable enable

using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LanguagePackEnhance;

/// <summary>
/// 提供给其它 Mod 对接本地化的公开接口（瘦 API 门面）。
/// 核心插件 <c>LanguagePackEnhance</c> 加载时会注册实现；未安装时这些方法会安全地无操作。
/// </summary>
public static class LanguagePackEnhanceApi
{
    internal static ILanguagePackEnhanceService? Service;

    /// <summary>核心插件是否已加载。</summary>
    public static bool IsReady => Service != null;

    /// <summary>
    /// 注册一个 Mod 自带的语言包（DLL 内嵌资源）。
    /// 调用方程序集默认为调用该方法所在的程序集。
    /// </summary>
    /// <param name="nsp">该 Mod 的唯一命名空间（用于区分不同 Mod 的语言包）。</param>
    /// <param name="resourceName">
    /// 内嵌资源的完整名称。支持两种格式：
    /// <list type="bullet">
    /// <item>与游戏语言包一致的 zip（内含 pack.json / assets/&lt;nsp&gt;/&lt;lang&gt;/*.mo）；</item>
    /// <item>简化 JSON：<c>{ "zh-Hans": { "原文": "译文" }, "en-US": { ... } }</c>，值也可为数组表示复数形式；
    /// 某 key 的值为对象时按 context 处理（对应游戏的 <c>_p</c>，如音乐室的 <c>music.description</c>）：
    /// <c>{ "en-US": { "music.description": { "原文": "译文" } } }</c>。</item>
    /// </list>
    /// 框架按内容自动识别（zip 以 "PK" 开头，否则视为 JSON）。
    /// </param>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void RegisterMod(string nsp, string resourceName)
        => Service?.RegisterMod(nsp, Assembly.GetCallingAssembly(), resourceName);

    /// <summary>
    /// 注册一个 Mod 自带的语言包（DLL 内嵌资源）。
    /// </summary>
    /// <param name="nsp">该 Mod 的唯一命名空间。</param>
    /// <param name="assembly">包含内嵌资源的程序集。</param>
    /// <param name="resourceName">内嵌资源的完整名称。</param>
    public static void RegisterMod(string nsp, Assembly assembly, string resourceName)
        => Service?.RegisterMod(nsp, assembly, resourceName);

    /// <summary>
    /// 运行时注册（或整体替换）某个 Mod 的译文集合。适用于运行时加载的内容（如音乐包）。
    /// 同一个 nsp 重复调用会替换上一次的内容；游戏已初始化时会立即生效。
    /// </summary>
    public static void RegisterTranslations(string nsp, IEnumerable<TranslationEntry> entries)
        => Service?.RegisterTranslations(nsp, entries);

    /// <summary>清除某个 Mod 之前通过 <see cref="RegisterTranslations"/> 注册的运行时译文。</summary>
    public static void ClearTranslations(string nsp)
        => Service?.ClearTranslations(nsp);

    /// <summary>
    /// 在当前语言下翻译文本，等价于游戏的 <c>LanguageManager._</c>。
    /// 查找优先级：第三方语言包 &gt; Mod 自带语言包 &gt; 游戏内置 &gt; 原文本。
    /// </summary>
    public static string Translate(string text, params object?[] args)
        => Service != null ? Service.Translate(text, args) : text;
}
