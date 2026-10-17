语言：[English](README.md) | 简体中文

# LanguagePackEnhance.API

![Vibe Coding](https://img.shields.io/badge/Vibe%20Coding-100%25-blueviolet)

[**LanguagePackEnhance**](https://github.com/Alhugh233/MVZ2-LPE)（一个面向 **MVZ2 / MVZ2Expand** Mod 的 BepInEx 6 (IL2CPP) 本地化框架）的**瘦 API** 程序集。

本程序集只包含公开的 API 类型（`LanguagePackEnhanceApi`、`TranslationEntry`、`ILanguagePackEnhanceService`），**不依赖游戏与 BepInEx**。其它 Mod 针对它编译，实际实现由 `LanguagePackEnhance.dll` 插件在运行时提供。

> **从 v1.1 起，本项目适配 MVZ2 0.7.X 底层。** 对 EXPAND 等改版的支持将在其源码更新后于后续版本恢复。

> 本工程设计为与 `LanguagePackEnhance` 插件工程并列存放（同级目录），由插件通过 `ProjectReference` 引用。

## 给 Mod 作者

编译期引用 `LanguagePackEnhance.API.dll`（`Private=false` / `compileOnly`），并声明依赖：

```csharp
[BepInDependency("com.mvz2.languagepackenhance")]
```

然后：

```csharp
// 注册内嵌语言包
LanguagePackEnhanceApi.RegisterMod("MyMod", "MyMod.lang.json");

// 注册运行时译文（例如动态加载的内容）
LanguagePackEnhanceApi.RegisterTranslations("MyMod", new[]
{
    new TranslationEntry("en-US", "原文", "Translation"),
    new TranslationEntry("en-US", "原文（音乐描述）", "Translation", "music.description"),
});

// 翻译
string s = LanguagePackEnhanceApi.Translate("我的设置");
```

完整 API 与语言包格式见 [LanguagePackEnhance README](https://github.com/Alhugh233/MVZ2-LPE/blob/main/README.zh-CN.md)。

## 构建

```bash
dotnet build
```

产物：`bin/Debug/net6.0/LanguagePackEnhance.API.dll`。

## 许可

版权所有 (C) 2026 Alhugh233。

采用 **Apache License 2.0** 授权，完整许可证文本原样收录于 [LICENSE](LICENSE)。

> `LanguagePackEnhance` 插件（实现）采用 **GPL-3.0**；本瘦 API 程序集刻意保持宽松的 **Apache-2.0**，以便其它 Mod 依赖它。Apache-2.0 与 GPL-3.0 兼容，因此 GPL-3.0 的插件可以引用并随包分发本程序集。
