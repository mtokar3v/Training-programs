#define _WINSOCK_DEPRECATED_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <WinSock2.h>
#include <iostream>
#include "../DataItems/ModbusProtocol.h"

int main() 
{
    WSADATA wsaData;
    WSAStartup(MAKEWORD(2, 2), &wsaData);

    try
    {
        bool run = true;
        while (run)
        {
            SOCKET sock = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);
            sockaddr_in sockAddr;
            memset(&sockAddr, 0, sizeof(sockAddr));
            sockAddr.sin_family = PF_INET;
            sockAddr.sin_addr.s_addr = inet_addr("127.0.0.1");
            sockAddr.sin_port = htons(502);
            connect(sock, (SOCKADDR*)&sockAddr, sizeof(SOCKADDR));

            system("cls");
            std::cout << "Main menu: " << std::endl;
            std::cout << "1. PING" << std::endl;
            std::cout << "2. Welcome message" << std::endl;
            std::cout << "3. Convert dec to bin" << std::endl;
            std::cout << "4. Exit" << std::endl;

            char choice = 0;
            std::cin >> choice;

            ModBusProtocol* modbus = nullptr;
            switch (choice)
            {
            case '1': 
                modbus = new ModBusProtocol(0, 0, 0, 0, FunctionCode::PING, NULL);
                break;
            case '2': 
            {
                std::cout << "Write your user name: ";
                char* userName = new char[30];
                std::cin >> userName;
                modbus = new ModBusProtocol(0, 0, strlen(userName) + 1, 0, FunctionCode::WELCOME, (unsigned char*)userName);
                break;
            }
            case '3': 
            {
                std::cout << "Write number: ";
                char* number = new char[10];
                std::cin >> number;
                modbus = new ModBusProtocol(0, 0, strlen(number) + 1, 0, FunctionCode::TOBINARY, (unsigned char*)number);
                break;
            }
            case '4': 
                run = false;
                continue;
            default:
                continue;
            }

            system("cls");
            unsigned char* command = modbus->GetCommand();
            send(sock, (char*)command, modbus->GetTotalSize(), NULL);

            char data[MAXBYTE];
            recv(sock, data, MAXBYTE, NULL);
            ModBusProtocol response = ModBusProtocol((unsigned char*) data);
            std::cout << "Server response: " << response.GetData() << std::endl;
            std::cin >> choice;

            closesocket(sock);
            delete modbus;
        }
    }
    catch (std::exception ex)
    {
        std::cout << "Connection is broken. " << ex.what() << std::endl;
    }

    WSACleanup();
    system("pause");
    return 0;
}