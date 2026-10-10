Language: English | [简体中文](README.zh-CN.md)

# LanguagePackEnhance.API

![Vibe Coding](https://img.shields.io/badge/Vibe%20Coding-100%25-blueviolet)

The **thin API** assembly for [**LanguagePackEnhance**](https://github.com/Alhugh233/MVZ2-LPE), a BepInEx 6 (IL2CPP) localization framework for **MVZ2 / MVZ2Expand** mods.

This assembly contains only the public API types (`LanguagePackEnhanceApi`, `TranslationEntry`, `ILanguagePackEnhanceService`) and has **no game or BepInEx dependencies**. Other mods compile against it, while the actual implementation is provided at runtime by the `LanguagePackEnhance.dll` plugin.

> This project is intended to live next to the `LanguagePackEnhance` plugin project (sibling directory). The plugin references it via a `ProjectReference`.

## For mod authors

Reference `LanguagePackEnhance.API.dll` at compile time (`Private=false` / `compileOnly`) and declare the dependency:

```csharp
[BepInDependency("com.mvz2.languagepackenhance")]
```

Then:

```csharp
// register an embedded language pack
LanguagePackEnhanceApi.RegisterMod("MyMod", "MyMod.lang.json");

// register runtime translations (e.g. dynamically loaded content)
LanguagePackEnhanceApi.RegisterTranslations("MyMod", new[]
{
    new TranslationEntry("en-US", "原文", "Translation"),
    new TranslationEntry("en-US", "原文（音乐描述）", "Translation", "music.description"),
});

// translate
string s = LanguagePackEnhanceApi.Translate("我的设置");
```

See the [LanguagePackEnhance README](https://github.com/Alhugh233/MVZ2-LPE/blob/main/README.md) for the full API and language pack formats.

## Building

```bash
dotnet build
```

Output: `bin/Debug/net6.0/LanguagePackEnhance.API.dll`.

## License

Copyright (C) 2026 Alhugh233.

Licensed under the **Apache License, Version 2.0**. The full license text is included verbatim in [LICENSE](LICENSE).

> The `LanguagePackEnhance` plugin (the implementation) is licensed under **GPL-3.0**; this thin API assembly is deliberately kept permissively licensed (**Apache-2.0**) so other mods can depend on it. Apache-2.0 is compatible with GPL-3.0, so the GPL-3.0 plugin may reference and ship this assembly.
