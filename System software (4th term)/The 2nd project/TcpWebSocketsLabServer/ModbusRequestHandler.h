#pragma once
#include "../DataItems/ModbusProtocol.h"

class ModbusRequestHandler 
{
private:
    SOCKET _clntSock;

public:
    ModbusRequestHandler(SOCKET clntSock)
    {
        _clntSock = clntSock;
    }

    char* HandleRequest(ModBusProtocol modbus)
    {
        switch (modbus.GetFunctionCode())
        {
            case FunctionCode::PING: HandlePingCommand(); break;
            case FunctionCode::WELCOME: HandleWelcomeCommand(modbus.GetData(), modbus.GetDataSize()); break;
            case FunctionCode::TOBINARY: HandleToBinaryCommand(modbus.GetData(), modbus.GetDataSize()); break;
            default: throw std::exception("Invalid function code");
        }
    }

private:
    void HandlePingCommand()
    {
        std::string message = "Server is working";

        ModBusProtocol modbus = ModBusProtocol(0, 0, message.length() + 1, 0, FunctionCode::PING, (unsigned char*)message.c_str());
        unsigned char* response = modbus.GetCommand();
        send(_clntSock, (char*)response, modbus.GetTotalSize(), NULL);
    }

    void HandleWelcomeCommand(unsigned char* data, int length)
    {
        std::string message;

        if (data[length - 1] == '\0')
        {
            message = std::string("Hello, ") + std::string((char*)data);
        }
        else 
        {
            message = std::string("Your input is invalid. Message must contains a null terminator");
        }

        ModBusProtocol modbus = ModBusProtocol(0, 0, message.length() + 1, 0, FunctionCode::WELCOME, (unsigned char*)message.c_str());
        unsigned char* response = modbus.GetCommand();
        send(_clntSock, (char*)response, modbus.GetTotalSize(), NULL);
    }

    void HandleToBinaryCommand(unsigned char* data, int length)
    {
        int num = atoi((char*)data);
        
        std::string result;
        
        int  i = 0, d = 1;
        while (num)
        {
            result.push_back((char)(num % 2) + '0');
            num = num / 2;
        }

        for (int i = 0; i < result.length() / 2; i++)
            std::swap(result[i], result[result.length() - i - 1]);

        ModBusProtocol modbus = ModBusProtocol(0, 0, result.length() + 1, 0, FunctionCode::TOBINARY, (unsigned char*)result.c_str());
        unsigned char* response = modbus.GetCommand();
        send(_clntSock, (char*)response, modbus.GetTotalSize(), NULL);
    }
};