// CppStudy.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <string.h>
#include <string>

using namespace std;

typedef struct Node {
    string content = "";
    struct Node* nextnode = NULL;
}Node;

void chaim(){
    Node node1;
}

#pragma region 位域



struct Bool {
    unsigned int a : 1; //位域
}bol;

struct Book //结构体
{
    string name = "default";
    int id = 0;
    struct Book *nextbook = NULL;
}book = {"default",0};

void structEXP() {
    bol.a = 0;
    cout << bol.a << endl; //调用位域

    struct Book book1; //产生了结构体
    struct Book book2;
    book1.name = "b1";
    book1.id = 1001;
    book2.name = "b2";
    book2.id = 1002;

    book1.nextbook = &book2;

    cout << book1.nextbook->name <<endl;

}
#pragma endregion

void pointer() {
    int i = 0;
    int *p1=NULL;
    p1 = &i;

    cout << *p1 << endl;

}


int main()
{
    pointer();
    structEXP();


    cout << endl;
}

