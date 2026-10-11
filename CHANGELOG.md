# Changelog

All notable changes to **CSS Saison** are documented in this file.

Format based on [Keep a Changelog](https://keepachangelog.com/). Versioning follows [SemVer](https://semver.org/).

## [0.1.0] — 2026-10-11

### Added
- Emby Server plugin that applies **Branding Custom CSS** from user-supplied files
- Eight fixed seasonal windows with enable toggles and periods (`DD-MM → DD-MM`)
- Modes: **Auto** (date match + fixed priority order) and **Manual** (forced season)
- Dashboard UI (`IHasUIPages`) under **Server → CSS Saison**
- Full-screen CSS editor dialogs (paste / save per theme)
- Apply on: server start, settings save, and daily scheduled task (**03:15** server time)
- Safe behaviour: missing or empty CSS → Branding unchanged; identical CSS → no rewrite
- Defaults: plugin and all seasons **disabled** until configured
- MIT license (CSS content remains the user’s responsibility)

[0.1.0]: https://github.com/ppo852/emby-css-saison/releases/tag/v0.1.0
