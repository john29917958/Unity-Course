// NativeCppLibrary.cpp : 定義 DLL 的匯出函式。
//

#include "pch.h"
#include "framework.h"
#include "NativeCppLibrary.h"


// 這是匯出變數的範例
NATIVECPPLIBRARY_API int nNativeCppLibrary=0;

// 這是匯出函式的範例。
NATIVECPPLIBRARY_API int fnNativeCppLibrary(void)
{
    return 0;
}

// 這是已匯出的類別建構函式。
CNativeCppLibrary::CNativeCppLibrary()
{
    return;
}

int displayNumber() {
    return 1;
}

int getRandom() {
    return 10;
}

int displaySum()
{
    int first_number = 7;
    int second_number = 7;
    int total = first_number + second_number;
    return total;
}