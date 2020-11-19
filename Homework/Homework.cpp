
#include <stdio.h>

int main() {
	double an = 0, ave = 0, fin = 0;
	int count = 0;
	for (int i = 0; i < 10000; i++) {
		scanf_s("%lf", &an);
		if (an == 0) break;
		if (an > 0) {
			count++, fin = fin + an;
		}
	}
	ave = fin / count;
	if (fin != 0) {
		printf("%g", ave);

	}

}