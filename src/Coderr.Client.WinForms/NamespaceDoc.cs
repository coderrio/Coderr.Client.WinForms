using System.Runtime.CompilerServices;

namespace codeRR.Client.WinForms
{
    /// <summary>
    ///     <para>
    ///         Integration library for WinForms and WPF applications.
    ///     </para>
    ///     <para>
    ///         To activate the library you need to add the following to your startup class:
    ///     </para>
    ///     <code>
    /// var url = new Uri("https://report.coderrapp.com");
    /// Err.Configuration.Credentials(url, "appKey", "sharedSecret");
    /// Err.Configuration.CatchWinFormsExceptions();
    /// </code>
    ///     <para>
    ///         The appKey/sharedSecret can be found by creating an account at
    ///         <a href="http://coderrapp.com">coderrapp.com</a>.
    ///     </para>
    ///     <para>
    ///         Additional configuration options:
    ///     </para>
    ///     <list type="bullet">
    ///         <item>
    ///             <see cref="ConfigExtensions.TakeScreenshots" />
    ///         </item>
    ///         <item>
    ///             <see cref="ConfigExtensions.SetErrorForm" />
    ///         </item>
    ///     </list>
    /// </summary>
    [CompilerGenerated]
    internal class NamespaceDoc
    {
    }
}