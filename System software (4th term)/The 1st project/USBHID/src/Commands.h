#pragma once

enum Command
{
	CheckActivePins = 0x01,
	SetLEDBrightness = 0x02,
	GetVoltage = 0x03,
	DrawPixel = 0x04
};