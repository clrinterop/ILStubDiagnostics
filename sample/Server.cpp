///////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation. All rights reserved.
///////////////////////////////////////////////////////////////////////////////

#include <stdio.h>
#include <windows.h>
#include <tchar.h>

extern "C" __declspec(dllexport) int Marshal_String_In(/*[In]*/LPSTR s)
{
    return 100;
}

extern "C" __declspec(dllexport) int Marshal_String_In2(/*[In]*/LPSTR s)
{
    return 101;
}