cls
@echo off
setlocal EnableDelayedExpansion

set "Version=1.0.0"
set "FileName=Template.modcomponent"

7zip a -tzip -mx0 %FileName% "auto-mapped" "bundle" "gear-spawns" "localizations" "BuildInfo.json"