#include <stdio.h>
#include <ctype.h>
#include <string.h>



int main()
{
    double a = 2, b = 1, ans = 0;;
    for (int i = 0; i < 20; i++) {
        ans += a / b;
        a = a + b;
        b = a - b;
    }
    printf("%lf", ans);
}
