#include "pch.h"
#include "localMax.h"
#include "framework.h"

//принимает массив вещественных чисел, а возвращает массив индексов

LOCALMAX_API int* findLocalMax(double* array, int size)
{
	int counter = 0;
	int* index = new int[size];

	if (array[0] > array[1])
		index[counter++] = 0;

	for (int i = 1; i < size - 1; i++)
	{
		if (array[i] > array[i - 1] && array[i] > array[i + 1])
			index[counter++] = i;
	}

	if (array[size - 1] > array[size - 2])
		index[counter++] = size - 1;

	for (int i = counter - 1; i < size; i++)
		index[i] = size + 1;

	return index;
}

