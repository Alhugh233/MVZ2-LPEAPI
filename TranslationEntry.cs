#nullable enable

namespace LanguagePackEnhance;

/// <summary>
/// 一条翻译条目（用于运行时注册译文）。
/// <see cref="Context"/> 为空表示普通文本（对应游戏的 <c>_</c>）；
/// 非空表示带 context 的文本（对应游戏的 <c>_p</c>，如音乐室的 <c>music.description</c>），
/// 实际查找的 key 为 <c>Context + "\u0004" + Source</c>。
/// </summary>
public readonly struct TranslationEntry
{
    /// <summary>语言代码，如 <c>zh-Hans</c> / <c>en-US</c>。</summary>
    public readonly string Language;

    /// <summary>原文（msgid）。</summary>
    public readonly string Source;

    /// <summary>译文。</summary>
    public readonly string Translation;

    /// <summary>可选的 context（为空表示普通文本）。</summary>
    public readonly string? Context;

    public TranslationEntry(string language, string source, string translation, string? context = null)
    {
        Language = language;
        Source = source;
        Translation = translation;
        Context = context;
    }
}
