#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <hidapi.h>
#include <stdint.h>
#include <locale.h>
#include <string.h>
#include <wchar.h>
#include <iostream>

#include "NotationConvertor.h"
#include "Constants.h"
#include "Commands.h"
#include "Pins.h"

using namespace std;

string GetString(wchar_t* wstr);
void PrintControllerInfo(hid_device* handle);
void PrintUSBInfo(hid_device_info* deviceInfo);
void SetMaxBrightnes(hid_device* handle, unsigned char* buf);
void SetMinBrightnes(hid_device* handle, unsigned char* buf);
void CheckVoltage(hid_device* handle, unsigned char* buf);
void ColorDisplay(hid_device* handle, unsigned char* buf);

int main(int argc, char* argv[])
{
	unsigned char buf[256];
	
	cout << "Hidapi test/example tool. Compiled with hidapi version " << HID_API_VERSION_STR << ", runtime version " << hid_version_str() << endl;

	if (hid_version()->major == HID_API_VERSION_MAJOR && hid_version()->minor == HID_API_VERSION_MINOR && hid_version()->patch == HID_API_VERSION_PATCH) 
	{
		cout << "Compile-time version matches runtime version of hidapi." << endl;
	}
	else 
	{
		cout << "Compile-time version is different than runtime version of hidapi." << endl;
	}

	if (hid_init()) return -1;

	hid_device_info* devs = hid_enumerate(0x0, 0x0);
	PrintUSBInfo(devs);

	memset(buf, 0x00, sizeof(buf));

	unsigned short vendorId = 0x1234;
	unsigned short productId = 0x0001;

	hid_device* handle = hid_open(vendorId, productId, NULL);
	if (!handle) 
	{
		cout << "Unable to open device" << endl;
		return 1;
	}

	PrintControllerInfo(handle);

	buf[0] = Command::SetLEDBrightness; 
	buf[1] = 0xff; 
	buf[2] = 0xff; 
	buf[3] = 0x00; 
	buf[4] = 0x00; 
	buf[5] = 0xff; 
	buf[6] = 0xff; 

	int result = hid_send_feature_report(handle, buf, 7);
	if (result == -1) 
	{
		cout << "Hid_write error." << endl;
		return -1;
	}

	buf[0] = Command::CheckActivePins;
	result = hid_get_feature_report(handle, buf, 2);
	if (result < 0) 
	{
		cout << "Unable to get a feature report." << endl;
		cout << hid_error(handle) << endl;
	}
	else 
	{
		cout << "Feature Report" << endl;
		for (int i = 0; i < result; i++)
			cout << static_cast<int>(buf[i]);
		cout << endl;
	}

	while (1)
	{
		buf[0] = Command::CheckActivePins;
		hid_get_feature_report(handle, buf, 2);
		switch (buf[1])
		{
			case Pin::FirstPin: SetMaxBrightnes(handle, buf); break;
			case Pin::SecondPin: SetMinBrightnes(handle, buf); break;
			case Pin::ThirdPin: ColorDisplay(handle, buf); break; 
			case Pin::FourthPin: CheckVoltage(handle, buf); break;
		}
	}
	return 0;
}

void PrintUSBInfo(hid_device_info* deviceInfos)
{
	hid_device_info* deviceInfo = deviceInfos;
	while (deviceInfo)
	{
		cout << "Device Found" << endl;
		cout << "Type: " << deviceInfo->vendor_id << " " << deviceInfo->product_id << endl;
		cout << "Path: " << deviceInfo->path << endl;
		cout << "Serial number: " << deviceInfo->serial_number << endl;
		cout << "Manufacturer: " << deviceInfo->manufacturer_string << endl;
		cout << "Product: " << deviceInfo->product_string << endl;
		cout << "Release: " << deviceInfo->release_number << endl;
		cout << "Interface: " << deviceInfo->interface_number << endl;
		cout << "Usage: " << deviceInfo->usage << endl;
		cout << "Page: " << deviceInfo->usage_page << endl;
		cout << endl;

		deviceInfo = deviceInfo->next;
	}

	hid_free_enumeration(deviceInfos);
}

void PrintControllerInfo(hid_device* handle)
{
	wchar_t wstr[MAX_STR * 2];
	wstring string;

	wstr[0] = 0x0000;
	int res = hid_get_manufacturer_string(handle, wstr, MAX_STR);
	res < 0 ?
		cout << "Unable to read manufacturer string" << endl :
		cout << "Manufacturer String: " << GetString(wstr) << endl;

	wstr[0] = 0x0000;
	res = hid_get_product_string(handle, wstr, MAX_STR);
	res < 0 ?
		cout << "Unable to read product string" << endl :
		cout << "Product String: " << GetString(wstr) << endl;

	wstr[0] = 0x0000;
	res = hid_get_serial_number_string(handle, wstr, MAX_STR);
	res < 0 ?
		cout << "Unable to read serial number string" << endl :
		cout << "Serial Number String: " << GetString(wstr) << endl;

	wstr[0] = 0x0000;
	res = hid_get_indexed_string(handle, 1, wstr, MAX_STR);
	res < 0 ?
		cout << "Unable to read indexed string 1" << endl :
		cout << "Indexed String 1: " << GetString(wstr) << endl;
}

string GetString(wchar_t* wstr)
{
	wstring ws(wstr);
	string str(ws.begin(), ws.end());
	return str;
}

void SetMaxBrightnes(hid_device* handle, unsigned char* buf)
{
	int length = 7;
	buf[0] = Command::SetLEDBrightness;
	for (int i = 1; i < length; i++)
		buf[i] = 0xff;

	hid_send_feature_report(handle, buf, length);
}

void SetMinBrightnes(hid_device* handle, unsigned char* buf)
{
	int length = 7;
	buf[0] = Command::SetLEDBrightness;
	for (int i = 1; i < length; i++)
		buf[i] = 0x00;

	hid_send_feature_report(handle, buf, length);
}

void CheckVoltage(hid_device* handle, unsigned char* buf)
{
	buf[0] = Command::GetVoltage;
	hid_get_feature_report(handle, buf, 3);

	unsigned char voltage[2];
	memcpy(&voltage, &buf[1], 2);
	char16_t voltageValue = NotationConvertor::ConvertToChar16(voltage);
	cout << "Voltage: " << voltageValue << endl;

	int length = 7;
	for (int i = 0; i < length / 2; i++)
	{
		buf[1 + i * 2] = voltage[0];
		buf[2 + i * 2] = voltage[1];
	}
	buf[0] = Command::SetLEDBrightness;
	hid_send_feature_report(handle, buf, length);

	Sleep(228);
}

void ColorDisplay(hid_device* handle, unsigned char* buf)
{
	const int displayHeight = 64;
	const int displayWidth = 128;

	static bool color = 0;
	color = !color;
	buf[0] = Command::DrawPixel;
	int lenght = 4;
	for (unsigned char i = 0; i < displayHeight; i++)
	{
		for (unsigned char j = 0; j < displayWidth; j++)
		{
			buf[1] = j;
			buf[2] = i;
			buf[3] = (unsigned char)color;
			hid_send_feature_report(handle, buf, lenght);
		}
	}
}


