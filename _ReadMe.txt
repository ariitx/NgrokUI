==================================================================================================================================================
Managed Debugging Assistant 'BindingFailure' has detected a problem in 'C:\Program Files (x86)\IIS Express\iisexpress.exe'.

^
to fix this issue: https://stackoverflow.com/questions/21829419/could-not-load-file-or-assembly-microsoft-visualstudio-web-pageinspector-loader
find:
C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\web.config

And remove the lines:
<remove assembly="Microsoft.VisualStudio.Web.PageInspector.Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
<add assembly="Microsoft.VisualStudio.Web.PageInspector.Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />

==================================================================================================================================================

Managed Debugging Assistant 'InvalidApartmentStateChange' has detected a problem in 'C:\Program Files (x86)\IIS Express\iisexpress.exe'.

Additional information: The current thread used to have an apartment state of MTA, but the application has CoUnitialized this thread and it is now STA. This may cause calls on RuntimeCallableWrappers representing some COM components to fail and may also cause COM component that are not multi-threaded to be accessed from multiple threads at the same time which can cause corruption or data loss.


^
encountered while using WMI object (retrieve motherboard SN). skip debugging apparently fixed the issue.

==================================================================================================================================================

Managed Debugging Assistant 'ContextSwitchDeadlock' has detected a problem in 'C:\Program Files (x86)\IIS Express\iisexpress.exe'.

^
just ignore it when it prompt.
==================================================================================================================================================

