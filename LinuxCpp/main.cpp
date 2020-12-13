#include <cstdio>

int* test() {
    int a[2] = { 2,4 };
    return a;
}

int main()
{
    printf("%d",*test);
    return 0;
}