# CSS Saison

**Emby Server plugin** — switch **Branding Custom CSS** by calendar windows (`DD-MM`), with an in-dashboard CSS editor.

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Version](https://img.shields.io/badge/version-0.1.2-green.svg)](CHANGELOG.md)
[![Target](https://img.shields.io/badge/Emby-4.9.x-orange.svg)](#compatibility)

---

## Features

| Feature | Detail |
|--------|--------|
| **Auto mode** | First **enabled** season whose date range contains today (server clock) |
| **Priority** | Fixed order: Valentine → Saint-Patrick → Easter → 4th of July → Halloween → Thanksgiving → Christmas → New Year |
| **Off-season** | Applies `default.css` if present |
| **Manual mode** | Force one season from a dropdown |
| **CSS editor** | Dashboard dialogs to paste/save each theme file |
| **Apply triggers** | Server start · Save settings · Save CSS editor · Scheduled task daily **03:15** (server time) |
| **Safe apply** | Missing/empty file → no Branding change · same CSS → skip write |

No theme CSS is shipped inside the DLL — you provide the files.  
Dashboard UI language is **English**. The product name **CSS Saison** is kept as the brand.

---

## ⚠ Important warnings

1. **Custom CSS is replaced**  
   When a rule applies, the plugin **overwrites** *Dashboard → Branding → Custom CSS* entirely. Put logos/tweaks **inside your `.css` files**, not only in the Branding UI.

2. **Web client**  
   Emby Custom CSS mainly affects the **web** client. Native TV/mobile apps may ignore it.

3. **Server clock**  
   Dates use the **Emby server** time (including Docker). Changing only your PC clock is not enough unless the container follows it — then run **Apply** (task or save).

4. **Your CSS, your license**  
   You supply the `.css` files. Respect third-party theme licenses if you redistribute them.

5. **Missing file = no-op**  
   If the resolved file (or `default.css`) is missing, Branding is **left unchanged**.

---

## Seasons (defaults)

| Season (UI) | Default period (`DD-MM → DD-MM`) | Default file name |
|-------------|----------------------------------|-------------------|
| Valentine | `01-02 → 15-02` | `valentine.css` |
| Saint-Patrick | `10-03 → 18-03` | `saint-patrick.css` |
| Easter | `01-04 → 20-04` | `easter.css` |
| 4th of July | `28-06 → 06-07` | `july-4.css` |
| Halloween | `01-10 → 01-11` | `halloween.css` |
| Thanksgiving | `15-11 → 30-11` | `thanksgiving.css` |
| Christmas | `01-12 → 26-12` | `christmas.css` |
| New Year | `27-12 → 02-01` | `new-year.css` |
| Default (off-season) | — | `default.css` |

Periods and enable flags are editable. Seasons are **fixed** (not a dynamic rule list).  
By default the **plugin and all seasons are disabled** — enable what you need.

Period format in the UI: `01-12 → 26-12` (also accepts `->` or spaced ` / `).

---

## Installation

1. Download `CssSaison.dll` from [Releases](https://github.com/ppo852/emby-css-saison/releases) **or** build (see below)
2. **Stop** Emby Server
3. Copy the DLL into Emby’s `plugins` folder
4. **Start** Emby Server
5. Open **Dashboard → Server → CSS Saison**
6. Put your CSS files in **`{Plugin Data Folder}/css/`**  
   (leave “CSS folder” empty in settings to use this default; or set an absolute custom path).

### Suggested files

```
css/
  default.css
  valentine.css
  saint-patrick.css
  easter.css
  july-4.css
  halloween.css
  thanksgiving.css
  christmas.css
  new-year.css
```

You can create them via the **Edit CSS** buttons (empty file until you paste content).

### Apply immediately

- Save the settings page, **or**
- Save inside a CSS editor dialog, **or**
- **Scheduled Tasks → CSS Saison — Apply theme**

Automatic: every day around **03:15** (server time) + on server start.

---

## Build

Prerequisites: [.NET SDK](https://dotnet.microsoft.com/download), NuGet access to `MediaBrowser.Server.Core`.

```powershell
cd src
dotnet build CssSaison\CssSaison.csproj -c Release
```

Output:

`src/CssSaison/bin/Release/netstandard2.0/CssSaison.dll`

---

## Compatibility

- Built against `MediaBrowser.Server.Core` **4.9.1.90** (Emby **4.9.x**; often OK on **4.10**)
- Always test on your server before production use
- Plugin GUID (stable): `D4E8F1A2-3B5C-4D6E-8F90-1A2B3C4D5E6F`

---

## Configuration notes

| Setting | Meaning |
|---------|---------|
| **Enable plugin** | Master switch |
| **Mode** | Auto (dates) or Manual (forced season) |
| **Forced season** | Used only in Manual mode |
| **CSS folder** | Empty = plugin data `css/` · or absolute path |
| **Season enabled + period** | Window for Auto mode |

Config file name on disk: `CSS Saison.json` (under Emby plugin configurations).

---

## Repository

**GitHub:** [ppo852/emby-css-saison](https://github.com/ppo852/emby-css-saison)

**Short description:**  
Emby Server plugin that switches Branding Custom CSS by date rules (DD-MM), with an in-dashboard CSS editor.

**Topics:** `emby` · `emby-plugin` · `css` · `branding` · `seasonal` · `theme` · `dotnet` · `csharp` · `media-server` · `custom-css`

---

## Credits / Acknowledgments

Special thanks to **Aleas** from the Emby community for the excellent theme work that inspired seasonal CSS usage with this plugin.  
Your themes and contributions to the community are greatly appreciated.

> This plugin does **not** redistribute third-party theme CSS. If you use Aleas’ (or any) theme files with CSS Saison, keep their credits and respect their license terms.

---

## Contributing

Issues and pull requests are welcome. Please:

- Keep behaviour safe (never wipe Branding on missing CSS)
- Test on a real Emby instance when changing apply/UI logic
- Update `CHANGELOG.md` for user-facing changes

---

## License

[MIT](LICENSE) — © 2026 CSS Saison contributors.

Theme CSS files you add are **not** covered by this license statement for third-party content; you remain responsible for their rights and credits.
