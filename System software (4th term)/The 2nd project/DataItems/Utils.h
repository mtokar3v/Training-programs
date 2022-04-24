#pragma once
#include <exception>

static class Util {
public:
	static unsigned char* GetPartOfArray(unsigned char* array, int start, int end)
	{
		if (end < start)
			throw std::exception("End point can not be before than start point");

		int newLength = end - start + 1;
		unsigned char* newArray = new unsigned char[newLength];

		for (int i = start, j = 0; j < newLength; i++, j++)
		{
			newArray[j] = array[i];
		}

		return newArray;
	}
};