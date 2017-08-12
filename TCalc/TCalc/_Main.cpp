#include "all.h"

int main(int argc, char **argv)
{
	if(argIs("/H"))
	{
		BatchMode = 1;
	}
	if(argIs("/S"))
	{
		SilentMode = 1;
	}
	if(argIs("/A"))
	{
		AnswerFile = nextArg();
	}
	if(argIs("/R"))
	{
		Radix = s2i(nextArg());
	}
	if(argIs("/B"))
	{
		Basement = s2i(nextArg());
	}
	if(argIs("/T"))
	{
		PrintTrimedOperandFlag = 1;
	}
	if(argIs("/E:01"))
	{
		ExtraAnswerLenMax = s2i(nextArg());
	}

	errorCase_m(AnswerFile && m_isEmpty(AnswerFile), "�s���ȏo�̓t�@�C���̃p�X���w�肳��܂����B");
	errorCase_m(!m_isRange(Radix, RADIX_MIN, RADIX_MAX), "�s���Ȋ���w�肳��܂����B");
	errorCase_m(!m_isRange(Basement, 0, BASEMENT_MAX), "�s���ȗL���������w�肳��܂����B");

	char *operand1 = strx(nextArg());
	char *enzanshi = strx(nextArg());
	char *operand2 = strx(nextArg());

	if(*operand1 == '@')
		operand1 = readText(operand1 + 1);

	toUpperString(enzanshi);

	if(*operand2 == '@')
		operand2 = readText(operand2 + 1);

	toAsciiToken(operand1);
	toAsciiToken(enzanshi);
	toAsciiToken(operand2);

	cout("%s\n", operand1);
	cout("%s\n", enzanshi);
	cout("%s\n", operand2);
	cout("=\n");

	char *answer = CalcMain(operand1, enzanshi, operand2);

	cout("%s\n", answer);

	if(ExtraAnswerLenMax)
		errorCase_m((size_t)ExtraAnswerLenMax < strlen(answer), "�v�Z���ʂ��I�[�o�[�t���[���܂����B");

	if(AnswerFile)
		writeToken(AnswerFile, answer);

	memFree(operand1);
	memFree(enzanshi);
	memFree(operand2);
	memFree(answer);

	termination(0);
	return 0; // dummy
}
