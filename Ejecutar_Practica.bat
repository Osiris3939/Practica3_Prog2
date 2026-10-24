@echo off
chcp 65001 > nul
title Practica 3 - Estructuras de Datos (Listas, Pilas y Colas)
cd /d "%~dp0"
if exist "bin\Debug\net8.0\Practica3_Prog2.exe" (
    "bin\Debug\net8.0\Practica3_Prog2.exe"
) else (
    dotnet run
)
pause
