using System.ComponentModel;

namespace Tumultu.Domain.Enums
{
    public enum FileType
    {
        [Description("Text File")]
        Txt,

        [Description("PDF Document")]
        Pdf,

        [Description("JPEG Image")]
        Jpg,

        [Description("PNG Image")]
        Png,

        [Description("Microsoft Word Document")]
        Docx,

        [Description("Excel Spreadsheet")]
        Xlsx,

        [Description("PowerPoint Presentation")]
        Pptx,

        [Description("ZIP Archive")]
        Zip,

        [Description("GIF Image")]
        Gif,

        [Description("HTML Document")]
        Html,

        [Description("XML Document")]
        Xml,

        [Description("MP3 Audio")]
        Mp3,

        [Description("MP4 Video")]
        Mp4,

        [Description("JavaScript File")]
        Js,

        [Description("C# Source Code")]
        Cs,

        [Description("JSON Data")]
        Json,

        [Description("SQL Script")]
        Sql,

        [Description("Markdown Document")]
        Md,

        [Description("Bitmap Image")]
        Bmp,

        [Description("SVG Image")]
        Svg,

        [Description("CSS Stylesheet")]
        Css,

        [Description("Python Script")]
        Py,

        [Description("Java Source Code")]
        Java,

        [Description("Executable File")]
        Exe,

        [Description("DLL File")]
        Dll,

        [Description("Windows Shortcut")]
        Lnk,

        [Description("Windows Registry File")]
        Reg,

        [Description("Audio Interchange File Format")]
        Aiff,

        [Description("Windows Media Audio")]
        Wma,

        [Description("Windows Media Video")]
        Wmv,

        [Description("Rich Text Format")]
        Rtf,

        [Description("Comma-Separated Values")]
        Csv,

        [Description("Wireless Markup Language")]
        Wml,

        [Description("Virtual Reality Modeling Language")]
        Vrml,

        [Description("Java Archive")]
        Jar,

        [Description("Photoshop Document")]
        Psd,

        [Description("Microsoft Access Database")]
        Accdb,

        [Description("Ebook")]
        Epub,

        [Description("Windows Batch File")]
        Bat,

        [Description("Windows PowerShell Script")]
        Ps1,

        [Description("Windows Installer Package")]
        Msi,

        [Description("Audio Video Interleave")]
        Avi,

        [Description("Windows System Image")]
        Iso,

        [Description("Virtual Hard Disk")]
        Vhd,

        [Description("QuickTime Movie")]
        Mov,

        [Description("Java Keystore File")]
        Jks,

        [Description("Compressed TAR Archive")]
        TarGz,

        // Add more file types as needed
    }
}
