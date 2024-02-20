using Tumultu.Domain.ValueObjects;

namespace Tumultu.Domain.Constants;

public static class Signatures
{
    static Signatures()
    {
        signatures = new List<Signature>()
        {
            new Signature([0x23, 0x21], 0, "Bash Script", "Script or data to be passed to the program followed by the shebang.", []), //
            new Signature([0x00, 0x00, 0x03, 0xF3], 0, "Amiga Executable", "Amgica Hunk executable file", []), // 
            new Signature([0x50, 0x57, 0x53, 0x33], 0, "Gorilla DB", "Gorilla Password Database", [".psafe3"]), //
            new Signature([0xD4, 0xC3, 0xB2, 0xA1], 0, "Libpcap", "Libpcap file format (little endian)", [".pcap"], Enums.Endianess.LittleEndian), //
            new Signature([0xA1, 0xB2, 0xC3, 0xD4], 0, "Libpcap", "Libpcap file format (big endian)", [".pcap"], Enums.Endianess.BigEndian), //
            new Signature([0xED, 0xAB, 0xEE, 0xDB], 0, "RPM Package", "Redhat RPM package", [".rpm"]), //
            new Signature([0x53, 0x51, 0x4C, 0x69, 0x74, 0x65, 0x20, 0x66, 0x6F, 0x72, 0x6D, 0x61, 0x74, 0x20, 0x33, 0x00],
                          0, "SQLite DB", "SQLite Database", [".db", ".sqlite", ".sqlitedb"]),
            new Signature([0x00, 0x00, 0x01, 0x00], 0, "Icon file", "Icon in ICO file format", [".ico"]), //
            new Signature([0x69, 0x63, 0x6e, 0x73], 0, "Apple icon", "Icon in Apple Icon Image format", [".icns"]), //
            new Signature([0x1F, 0x9D], 0, "LZW Archive", "Compressed file using Lempel-Ziv-Welch algorithm", [".z", ".tar.z"]), //
            new Signature([0x1F, 0xA0], 0, "LZH Archive", "Compressed file using LZH algorithm", [".z", ".tar.z"]), //
            new Signature([0x2D, 0x68, 0x6C, 0x30, 0x2D], 2, "LZH Archive", "LZH archive file using method 0 (no compression)", [".lzh"]), //
            new Signature([0x2D, 0x68, 0x6C, 0x35, 0x2D], 2, "LZH Archive", "LZH archive file using method 5", [".lzh"]), //
            new Signature([0x42, 0x5A, 0x68], 0, "Bzip2 archive", "Compressed file using Bzip2 algorithm", [".bz2"]), //
            new Signature([0x47, 0x49, 0x46, 0x38, 0x37, 0x61], 0, "GIF", "Image file encoded in the Graphics Interchange Format", [".gif"]), //
            new Signature([0x47, 0x49, 0x46, 0x38, 0x39, 0x61], 0, "GIF", "Image file encoded in the Graphics Interchange Format", [".gif"]), //
            new Signature([0x49, 0x49, 0x2A, 0x00], 0, "TIFF", "Tagged Image File", [".tiff", ".tif"]), //
            new Signature([0xFF, 0xD8, 0xFF], 0, "JPEG", "JPEG raw or in the JFIF or Exif file format", [".jpg", ".jpeg", ".jp2", "jpe"]), //
            new Signature([0x4C, 0x5A, 0x49, 0x50], 0, "LZIP", "Lzip compressed file", [".lz"]), //
            new Signature([0x4D, 0x5A], 0, "DOS MZ", "DOS MZ executable and tis descendants (including NE and PE)", //
                          [".exe", ".dll", ".mui", ".sys", ".scr", ".cpl", ".ocx", ".ax", ".iec", ".ime", ".rs", ".tsp", ".fon", ".efi"]),
            new Signature([0x5A, 0x4D], 0, "DOS ZM", "DOS ZM executable", [".exe"]), //
            new Signature([0x50, 0x4b, 0x03, 0x04], 0, "ZIP based", "Zip file or file based on zip format", //
                          [".zip", ".aar", ".apk", ".docx", ".epub", ".ipa", ".jar", ".kmz", ".maff", ".msix", ".odp", ".ods", ".odt", ".pk3", ".pk4", ".pptx", ".usdz", ".vsdx", ".xlsx", ".xpi"]),
            new Signature([0x50, 0x4b, 0x03, 0x06], 0, "ZIP based", "Zip file or file based on zip format", //
                          [".zip", ".aar", ".apk", ".docx", ".epub", ".ipa", ".jar", ".kmz", ".maff", ".msix", ".odp", ".ods", ".odt", ".pk3", ".pk4", ".pptx", ".usdz", ".vsdx", ".xlsx", ".xpi"]),
            new Signature([0x50, 0x4b, 0x03, 0x08], 0, "ZIP based", "Zip file or file based on zip format", //
                          [".zip", ".aar", ".apk", ".docx", ".epub", ".ipa", ".jar", ".kmz", ".maff", ".msix", ".odp", ".ods", ".odt", ".pk3", ".pk4", ".pptx", ".usdz", ".vsdx", ".xlsx", ".xpi"]),
            new Signature([0x1F, 0x25], 0, "Unix Archive", "Unix archive or compressed file", [".tar"]), //
            new Signature([0x75, 0x73, 0x74, 0x61, 0x72, 0x00, 0x30, 0x30], 257, "Tar Archive", "Tar Archive", [".tar"]), //
            new Signature([0x75, 0x73, 0x74, 0x61, 0x72, 0x20, 0x30, 0x30], 257, "Tar Archive", "Tar Archive", [".tar"]), //
            new Signature([0x7F, 0x45, 0x4C, 0x46], 0, "Executable and Linkable Format (ELF)", "Unix/Linux executable file format", [".elf"]), //
            new Signature([0xCA, 0xFE, 0xBA, 0xBE], 0, "Java Class File", "Java class file", [".class"]), //
            new Signature([0x25, 0x21, 0x50, 0x53], 0, "PostScript", "PostScript document", [".ps", ".eps"]), //
            new Signature([0x1F, 0x8B, 0x08], 0, "Gzip Archive", "Gzip compressed file", [".gz", ".tgz"]), //
            new Signature([0x1F, 0x8B], 0, "Gzip Archive", "Gzip compressed file", [".gz", ".tgz"]), //
            new Signature([0x42, 0x4D], 0, "Bitmap Image", "Bitmap image file", [".bmp"]), //
            new Signature([0x25, 0x50, 0x44, 0x46], 0, "PDF", "Portable Document Format", [".pdf"]), //
            new Signature([0x25, 0x50, 0x44, 0x46, 0x2D], 0, "PDF", "Portable Document Format", [".pdf"]), //
            new Signature([0x4D, 0x54, 0x68, 0x64], 0, "MIDI", "MIDI sound file", [".midi", ".mid"]), //
            new Signature([0x2E, 0x52, 0x4D, 0x46], 0, "RealMedia File", "RealMedia streaming media file", [".rm", ".rmvb"]), //
            new Signature([0x00, 0x61, 0x73, 0x6D], 0, "WASM", "WebAssembly binary file", [".wasm"]), //
            new Signature([0x7B, 0x5C, 0x72, 0x74, 0x66], 0, "RTF", "Rich Text Format", [".rtf"]), //
            new Signature([0x64, 0x6E, 0x73, 0x2E], 0, "Windows DLL", "Windows Dynamic Link Library", [".dll"]), //?
            new Signature([0x50, 0x4B, 0x03, 0x0E, 0x14, 0x00, 0x06, 0x00], 0, "OpenDocument", "Zip based OpenDocument file format", [".odt", ".ods", ".odp"]),
            new Signature([0x4D, 0x5A, 0x90, 0x00], 0, "Windows Executable (NE)", "New Executable (NE) Windows executable", [".exe"]), //
            new Signature([0x4D, 0x5A, 0x50, 0x45], 0, "Windows Executable (PE)", "Portable Executable (PE) Windows executable", [".exe", ".dll", ".sys"]), //
            new Signature([0x4D, 0x41, 0x52, 0x31], 0, "MATLAB Data File", "MATLAB MAT-file version 4", [".mat"]), // 
            new Signature([0x4D, 0x5A, 0x52, 0x53], 0, "Windows Executable (MS-DOS)", "MS-DOS executable", [".exe", ".com"]), //
            new Signature([0x46, 0x4C, 0x49, 0x46], 0, "FLIF", "Free Lossless Image Format", [".flif"]), //
            new Signature([0x2E, 0x4C, 0x4E, 0x4B], 0, "Windows Shortcut", "Windows shortcut file", [".lnk"]),
            new Signature([0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9, 0x00, 0xAA, 0x00, 0x62, 0xCE, 0x6C], 0, "Windows Media File", "Windows Media file", [".wma", ".wmv", ".asf"]),
            new Signature([0x30, 0x32, 0x6F, 0x6F, 0xFC, 0x0D, 0xF3, 0x31, 0xA4, 0x69, 0xD6, 0x35, 0xFF, 0x9F, 0x50, 0xE0], 0, "Windows Media File", "Windows Media file", [".wmv"]),
            new Signature([0x43, 0x61, 0x6C, 0x6D, 0x56, 0x6F, 0x69, 0x63], 0, "VMware Virtual Disk", "VMware Virtual Disk file", [".vmdk"]), //?
            new Signature([0x4B, 0x44, 0x4D], 0, "VMDK file", "VMWare Virtual Disk File", [".vmdk"]), //
            new Signature([0x50, 0x4D, 0x4F, 0x43, 0x43, 0x4D, 0x4F, 0x43], 0, "Windows Metafile", "Windows Metafile / Settings transfer repository", [".wmf", ".dat"]), //
            new Signature([0x38, 0x2D, 0x2D, 0x2D, 0x0D, 0x0A], 0, "PGP Public Key", "Pretty Good Privacy (PGP) Public Key", [".asc", ".pgp", ".gpg"]), //?
            new Signature([0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x42, 0x45, 0x47, 0x49, 0x4E, 0x20, 0x50, 0x47, 0x50, 0x20, 0x50, 0x55, 0x42,
                           0x4C, 0x49, 0x43, 0x20, 0x4B, 0x45, 0x49, 0x20, 0x42, 0x4C, 0x4F, 0x43, 0x4B, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D],
                           0, "PGP armored public key", "Pretty Good Privacy armored public key", [".asc", ".pgp"]), //
            new Signature([0x4D, 0x53, 0x47, 0x53, 0x4D, 0x4F, 0x4E, 0x43], 0, "Windows Compound File", "Microsoft Compound Document File Format", [".doc", ".xls", ".ppt", ".msg"]), //
            new Signature([0x2E, 0x72, 0x61, 0xFD, 0x00, 0x00, 0x00, 0x00], 0, "RealAudio", "RealAudio streaming media file", [".ra", ".ram"]), //
            new Signature([0x23, 0x40, 0x7E, 0x5E], 0, "VBScript Encoded", "Visual Basic Script Encoded", [".vbe"]), //
            new Signature([0x6B, 0x6F, 0x6C, 0x79], -512, "Apple Disk Image", "Apple Disk Image file", [".dmg"]), //
            new Signature([0x43, 0x44, 0x30, 0x30, 0x31], 0x8001, "CD/DVD Image", "ISO9660 CD/DVD image file", [".iso"]), //
            new Signature([0x43, 0x44, 0x30, 0x30, 0x31], 0x8801, "CD/DVD Image", "ISO9660 CD/DVD image file", [".iso"]), //
            new Signature([0x43, 0x44, 0x30, 0x30, 0x31], 0x9001, "CD/DVD Image", "ISO9660 CD/DVD image file", [".iso"]), //
            new Signature([0x73, 0x64, 0x62, 0x66], 8, "Windows DB", "Windows customized database", [".sdb"]), //
            new Signature([0x66, 0x74, 0x79, 0x70, 0x33, 0x67], 4, "3GP multimedia", "3rd Generation Partnership Project multimedia files", [".3gp", ".3g2"]), //
            new Signature([0x66, 0x74, 0x79, 0x70, 0x68, 0x65, 0x69, 0x6, 0x66, 0x74, 0x79, 0x70, 0x6D], 4, "HEIC", "High Efficiency Image Container", [".heic"]), //
            new Signature([0x66, 0x74, 0x79, 0x70, 0x69, 0x73, 0x6F, 0x6D], 4, "Media File", "ISO Base media file", [".mp4"]), // 
            new Signature([0x66, 0x74, 0x79, 0x70, 0x4D, 0x53, 0x4E, 0x56], 4, "Media File", "MPEG-4 video file", [".mp4"]) //

        };
    }
    private static readonly IEnumerable<Signature> signatures;

    public static IList<Signature> MatchSignatures(byte[] payload)
    {
        var payloadLength = payload.Length;
        
        var results = new List<Signature>();
        foreach(var sig in signatures)
        {
            int offset = sig.Offset >= 0 ? (int)sig.Offset : payloadLength + (int)sig.Offset!;

            if (offset + sig.SignatureBytes!.Length > payloadLength) continue;

            bool isMatch = true;
            for(int i = 0; i < sig.SignatureBytes.Length; i++) 
            {
                if (payload[offset + i] != sig.SignatureBytes[i])
                {
                    isMatch = false;
                    break;
                }
            }
            if (isMatch)
            {
                results.Add(sig);
            }
        }
        return results;
    }
}
