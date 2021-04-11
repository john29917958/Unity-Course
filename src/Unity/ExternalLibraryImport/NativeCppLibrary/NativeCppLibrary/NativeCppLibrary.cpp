#include "pch.h"
#include "framework.h"
#include "NativeCppLibrary.h"

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

int NativeCppLibrary::sum(int a, int b)
{
    return a + b;
}