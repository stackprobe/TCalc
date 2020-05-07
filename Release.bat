C:\Factory\Tools\RDMD.exe /RC out

COPY /B TCalc\Release\TCalc.exe out
COPY /B WTCalc\WTCalc\bin\Release\WTCalc.exe out
COPY /B doc\* out

COPY /B C:\Factory\Program\TCalc\Keisan.exe out
C:\Factory\SubTools\EmbedConfig.exe --factory-dir-disabled out\Keisan.exe

C:\Factory\SubTools\zip.exe /O out TCalc

IF NOT "%1" == "/-P" PAUSE
