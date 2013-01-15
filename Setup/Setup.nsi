OutFile "Setup.exe"

installDir "$PROGRAMFILES\PIMPhony Integration Utility"
#still not working here!
#RequestExecutionLevel 'highest'


section
	setOutPath $INSTDIR
	File piu.exe
	File Interop.DAO.dll
	File Interop.VBIDE.dll
	File "PIMPhony Integration Utility Guide.pdf"
	writeUninstaller $INSTDIR\uninstaller.exe

	createShortCut "$SMPROGRAMS\PIMPhony Integration Utility\Integration Settings.lnk" "$INSTDIR\piu.exe" "-setting"
	createShortcut "$SMPROGRAMS\PIMPhony Integration Utility\Integration Guide.lnk" "$INSTDIR\PIMPhony Integration Utility Guide.pdf"
	createShortCut "$SMPROGRAMS\PIMPhony Integration Utility\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
sectionEnd

section "Uninstall"
	delete "$INSTDIR\uninstaller.exe"
	RMDir /r "$INSTDIR"
	RMDir /r "$SMPROGRAMS\PIMPhony Integration Utility"
sectionEnd