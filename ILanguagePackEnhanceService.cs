#nullable enable

using System.Collections.Generic;
using System.Reflection;

namespace LanguagePackEnhance;

/// <summary>
/// LPE 的实际实现（由核心插件 <c>LanguagePackEnhance</c> 提供并在加载时注册）。
/// Mod 侧不要直接依赖本接口；请使用 <see cref="LanguagePackEnhanceApi"/>。
/// </summary>
public interface ILanguagePackEnhanceService
{
    void RegisterMod(string nsp, Assembly assembly, string resourceName);
    void RegisterTranslations(string nsp, IEnumerable<TranslationEntry> entries);
    void ClearTranslations(string nsp);
    string Translate(string text, object?[] args);
}
