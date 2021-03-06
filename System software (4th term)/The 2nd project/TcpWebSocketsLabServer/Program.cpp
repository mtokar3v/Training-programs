#define _WINSOCK_DEPRECATED_NO_WARNINGS

#include <stdio.h>
#include <winsock2.h>
#include "../DataItems/ModbusProtocol.h"
#include "ModbusRequestHandler.h"
#pragma comment (lib, "ws2_32.lib")

int main() 
{
    WSADATA wsaData;
    WSAStartup(MAKEWORD(2, 2), &wsaData);

    SOCKET servSock = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);
    sockaddr_in sockAddr;
    memset(&sockAddr, 0, sizeof(sockAddr));
    sockAddr.sin_family = PF_INET; 
    sockAddr.sin_addr.s_addr = inet_addr("0.0.0.0");
    sockAddr.sin_port = htons(502);

    bind(servSock, (SOCKADDR*)&sockAddr, sizeof(SOCKADDR));
    listen(servSock, 20);

    int nSize;
    SOCKET clntSock;

    char data[MAXBYTE];
    while (true) 
    {
        try
        {
            SOCKADDR* clntAddr = nullptr;

            nSize = sizeof(SOCKADDR);
            clntSock = accept(servSock, clntAddr, &nSize);
            recv(clntSock, data, MAXBYTE, NULL);

            ModBusProtocol modbus = ModBusProtocol((unsigned char*)data);
            ModbusRequestHandler handler = ModbusRequestHandler(clntSock);
            handler.HandleRequest(modbus);
        }
        catch(std::exception ex)
        {
            std::cout << "Error: " << ex.what() << std::endl;
        }

        closesocket(clntSock);
    }


    closesocket(servSock);

    WSACleanup();
    return 0;
}