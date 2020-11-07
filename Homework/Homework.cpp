#include <stdio.h>

int main()
{
    int x, y;
    scanf_s("%d%d", &x, &y);
    if (x == 0 && y==0) {
        printf("原点");

    }
    else if (x == 0 && y != 0) {
        printf("Y轴");
    }
    else if (x != 0 && y == 0) {
        printf("X轴");
    }

    if (x > 0) {
        printf("%s", y > 0 ? "第一象限" : "第四象限");
    }
    else {
        printf("%s", y > 0 ? "第二象限" : "第三象限");
    }
}

