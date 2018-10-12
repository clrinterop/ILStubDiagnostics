///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

/* This file is best viewed using outline mode (Ctrl-M Ctrl-O) */

// This program uses code hyperlinks available as part of the HyperAddin Visual Studio plug-in.
// It is available from http://www.codeplex.com/hyperAddin 
/* */
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using FastSerialization;


/// <summary>
/// Used to send the rawManifest into the event stream as a series of events.  
/// </summary>
internal struct ManifestEnvelope
{
    public const int MaxChunkSize = 0xFF00;
    public enum ManifestFormats : byte
    {
        SimpleXmlFormat = 1,          // Simply dump what is under the <proivider> tag in an XML manifest
    }

    public ManifestFormats Format;
    public byte MajorVersion;
    public byte MinorVersion;
    public byte Magic;
    public ushort TotalChunks;
    public ushort ChunkNumber;
};
