#include "all.h"

char *AnswerFile; // NULL == 出力しない。

int Radix = DEFAULT_RADIX; // RADIX_MIN 〜 RADIX_MAX
int Basement = DEFAULT_BASEMENT; // 0 〜 BASEMENT_MAX
int PrintTrimedOperandFlag;
int ExtraAnswerLenMax; // 0 == 無効
