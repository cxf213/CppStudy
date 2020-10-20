// CppStudy.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <string.h>
#include <string>

using namespace std;

#pragma region 链表

typedef struct Link {
    char elem;          //代表数据域
    struct Link* next;  //代表指针域，指向直接后继元素
}link;

link* initLink() {
    link* p = (link*)malloc(sizeof(link));//创建一个头结点
    link* temp = p;//声明一个指针指向头结点，用于遍历链表
    //生成链表
    for (int i = 1; i < 5; i++) {
        link* a = (link*)malloc(sizeof(link));
        a->elem = i;
        a->next = NULL;
        temp->next = a;
        temp = temp->next;
    }
    return p;
}

int selectElem(link* p, int elem) {
    link* t = p;
    int i = 1;
    while (t->next) {
        t = t->next;
        if (t->elem == elem) {
            return i;
        }
        i++;
    }
    return -1;
}

#pragma endregion

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
    //pointer();
    //structEXP();

    link* ini = initLink();
    cout << selectElem(ini, 2) << endl;

    cout << endl;
}

