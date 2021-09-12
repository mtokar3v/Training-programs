#pragma once
#include <vector>

#ifdef LOCALMAX_EXPORTS
#define LOCALMAX_API __declspec(dllexport)
#else
#define LOCALMAX_API __declspec(dllimport)
#endif

extern "C" LOCALMAX_API int* findLocalMax(double* array, int size);