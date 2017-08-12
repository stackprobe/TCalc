#include "all.h"

static void ToSameDecPos(Rational *r1, Rational *r2)
{
	r1->Normalize();
	r2->Normalize();

	if(r1->DecPos < r2->DecPos) r1->SlideDecPos(r2->DecPos - r1->DecPos);
	if(r2->DecPos < r1->DecPos) r2->SlideDecPos(r1->DecPos - r2->DecPos);
}

// Calc* >

Rational *CalcReduce(Rational *r1, Rational *r2);

static Rational *CalcAdd(Rational *r1, Rational *r2)
{
	Rational *ra;

	if(r1->Sign == -1)
	{
		r1->Sign = 1;
		ra = CalcReduce(r2, r1);
		r1->Sign = -1;

		goto endFunc;
	}
	if(r2->Sign == -1)
	{
		r2->Sign = 1;
		ra = CalcReduce(r1, r2);
		r2->Sign = -1;

		goto endFunc;
	}

	ToSameDecPos(r1, r2);
	int maxCount = m_max(r1->Figures->GetCount(), r2->Figures->GetCount());
	ra = new Rational();

	for(int index = 0; index < maxCount; index++)
	{
		ra->AddInt(r1->Figures->RefFigure(index) + r2->Figures->RefFigure(index), index);
	}
	ra->DecPos = r1->DecPos;
	ra->Normalize();

endFunc:
	return ra;
}
static Rational *CalcReduce(Rational *r1, Rational *r2)
{
	Rational *ra;

	if(r1->Sign == -1)
	{
		r1->Sign = 1;
		ra = CalcAdd(r1, r2);
		ra->Sign *= -1;
		r1->Sign = -1;

		goto endFunc;
	}
	if(r2->Sign == -1)
	{
		r2->Sign = 1;
		ra = CalcAdd(r1, r2);
		r2->Sign = -1;

		goto endFunc;
	}

	ToSameDecPos(r1, r2);
	int maxCount = m_max(r1->Figures->GetCount(), r2->Figures->GetCount());
	maxCount = m_max(maxCount, 1);
	ra = new Rational();

	for(int index = 0; index < maxCount; index++)
	{
		ra->AddInt(r1->Figures->RefFigure(index) + Radix - r2->Figures->RefFigure(index) - (index ? 1 : 0), index);
	}
	if(ra->Figures->RefFigure(maxCount) == 0) // ? r1 < r2
	{
		delete ra;
		ra = CalcReduce(r2, r1);
		ra->Sign = -1;

		goto endFunc;
	}
	ra->Figures->PutFigure(maxCount, 0);
	ra->DecPos = r1->DecPos;
	ra->Normalize();

endFunc:
	return ra;
}
static Rational *CalcMultiple(Rational *r1, Rational *r2)
{
	Rational *ra = new Rational();

	for(int index1 = 0; index1 < r1->Figures->GetCount(); index1++)
	{
		int value1 = r1->Figures->RefFigure(index1);

		if(value1)
		{
			for(int index2 = 0; index2 < r2->Figures->GetCount(); index2++)
			{
				int value2 = r2->Figures->RefFigure(index2);

				if(value2)
				{
					ra->AddInt(value1 * value2, index1 + index2);
				}
			}
		}
	}
	ra->DecPos = r1->DecPos + r2->DecPos;
	ra->Sign = r1->Sign * r2->Sign;
	ra->Normalize();

	return ra;
}
static Rational *CalcDivide(Rational *&r1, Rational *r2)
{
	r2->Normalize();
	errorCase_m(r2->Figures->GetCount() == 0, "ゼロで除算しました。");

	Rational *ra = new Rational();
	ra->Sign = r1->Sign * r2->Sign;
	ra->DecPos = Basement;

	r1->Sign = 1;
	r2->Sign = 2;
	r2->DecPos += Basement;

	ToSameDecPos(r1, r2);
	int shiftCount = r1->Figures->GetCount() - r2->Figures->GetCount();
	m_maxim(shiftCount, 0);
	r1->DecPos += shiftCount;

	Rational *rI3 = new Rational(3);
	Rational *r2X3 = CalcMultiple(r2, rI3);
	delete rI3;

	for(; ; )
	{
		r1->Normalize();

		if(r1->Figures->GetCount() == 0)
			break;

		for(; ; )
		{
			Rational *ta = CalcReduce(r1, r2X3);

			if(ta->Sign == 1) // ? r2X3 <= r1
			{
				ra->AddInt(3, shiftCount);
				delete r1;
				r1 = ta;
			}
			else
			{
				delete ta;
				break;
			}
		}
		for(; ; )
		{
			Rational *ta = CalcReduce(r1, r2);

			if(ta->Sign == 1) // ? r2 <= r1
			{
				ra->AddInt(1, shiftCount);
				delete r1;
				r1 = ta;
			}
			else
			{
				delete ta;
				break;
			}
		}
		if(shiftCount <= 0)
			break;

		r2->DecPos++;
		r2X3->DecPos++;
		shiftCount--;
	}
	delete r2X3;
	ra->Normalize();
	return ra;
}
static char *Calc(char *operand1, char *enzanshi, char *operand2)
{
	Rational *r1 = new Rational(operand1);
	Rational *r2 = new Rational(operand2);
	Rational *ra;

	switch(*enzanshi)
	{
	case '+':
		ra = CalcAdd(r1, r2);
		break;

	case '-':
		ra = CalcReduce(r1, r2);
		break;

	case '*':
		ra = CalcMultiple(r1, r2);
		break;

	case '/':
		ra = CalcDivide(r1, r2);
		break;

	default:
		error();
	}
	char *answer = ra->ToString();

	delete r1;
	delete r2;
	delete ra;

	return answer;
}
static char *CalcModulo(char *operand1, char *operand2)
{
	int trueBasement = Basement;
	Basement = 0;

	char *a1 = Calc(operand1, "/", operand2);
	char *a2 = Calc(a1, "*", operand2);
	char *answer = Calc(operand1, "-", a2);

	Basement = trueBasement;

	memFree(a1);
	memFree(a2);

	return answer;
}
static char *CalcPower(char *operand, int exponent)
{
	errorCase_m(exponent < 0, "不正な指数が指定されました。");

	if(exponent == 0) return strx("1");
	if(exponent == 1) return strx(operand);

	char *a1 = CalcPower(operand, exponent / 2);
	char *answer = Calc(a1, "*", a1);
	memFree(a1);

	if(exponent & 1)
	{
		a1 = Calc(answer, "*", operand);
		memFree(answer);
		answer = a1;
	}

	if(ExtraAnswerLenMax)
		errorCase_m((size_t)ExtraAnswerLenMax < strlen(answer), "べき乗の計算結果がオーバーフローしました。");

	return answer;
}
static char *CalcRoot(char *operand, int exponent)
{
	errorCase_m(exponent < 1, "不正な指数が指定されました。(べき根)");

	operand = strx(operand);
	operand = replace(operand, "-", ""); // abs()

	char *answer = strx("0");
	char *extend = Calc(operand, "+", "0"); // strx(operand) + trim

	while(strcmp(extend, "0")) // ? extend != "0"
	{
		char *a1 = Calc(answer, "+", extend);
		char *a2 = CalcPower(a1, exponent);
		char *a3 = Calc(operand, "-", a2);

		if(*a3 == '-') // ? a3 < "0"
		{
			memFree(a1);
			a1 = Calc(extend, "/", Radix == 2 ? "10" : "2"); // 次の桁が Basement を超えるなら "0" になる。
			memFree(extend);
			extend = a1;

//cout("1*%s\n", extend);
			for(char *p = extend; *p; p++) // 2つ目以降の非0を排除
			{
				if(!strchr("-.0", *p)) // **** 進数増やす時注意 ****
				{
					while(*++p)
						if(*p != '.')
							*p = '0';

					break;
				}
			}
//cout("2*%s\n", extend);
		}
		else
		{
			memFree(answer);
			answer = a1;

			if(!strcmp(a3, "0")) // ? ぴったり合った -> ループ終了
				strz(extend, "0");
		}
		memFree(a2);
		memFree(a3);
	}
	memFree(operand);
	memFree(extend);
	return answer;
}
static char *CalcChangeRadix(char *operand, int newRadix)
{
	errorCase_m(!m_isRange(newRadix, RADIX_MIN, RADIX_MAX), "不正な基数に変換しようとしました。");

	int trueSign = strchr(operand, '-') ? -1 : 1;
	operand = strx(operand);
	operand = replace(operand, "-", ""); // abs()

	char *extend = strx("1");
	char *lNewRdx;

	{
		Rational *tr = new Rational(newRadix);
		lNewRdx = tr->ToString();
		delete tr;
	}

	for(int index = 0; index < Basement; index++) // operand *= newRadix ** Basement
	{
		char *a1 = Calc(operand, "*", lNewRdx);
		memFree(operand);
		operand = a1;
	}
	int addPos = 0;

	for(; ; )
	{
		char *a1 = Calc(extend, "*", lNewRdx);
		char *a2 = Calc(operand, "-", a1);

		if(*a2 == '-') // ? operand < a1
		{
			memFree(a1);
			memFree(a2);
			break;
		}
		memFree(extend);
		extend = a1;
		memFree(a2);

		addPos++;
	}
	Rational *ra = new Rational();
	ra->DecPos = Basement;
	ra->Sign = trueSign;

	int trueBasement = Basement;
	Basement = 0;

	for(; ; )
	{
		char *a1 = Calc(operand, "/", extend);
		char *a2 = Calc(a1, "*", extend);
		char *a3 = Calc(operand, "-", a2);
		int value;

		{
			Rational *tr = new Rational(a1);
			value = tr->ToInt();
			delete tr;
		}
		errorCase(!m_isRange(value, 0, newRadix - 1));

		ra->Figures->PutFigure(addPos, value);

		memFree(a1);
		memFree(a2);
		memFree(operand);
		operand = a3;

		if(addPos <= 0)
			break;

		if(!strcmp(operand, "0"))
			break;

		a1 = Calc(extend, "/", lNewRdx);
		memFree(extend);
		extend = a1;

		addPos--;
	}
	Basement = trueBasement;

	memFree(operand);
	memFree(extend);
	memFree(lNewRdx);

	Radix = newRadix;

	char *out = ra->ToString();
	delete ra;
	return out;
}

// < Calc*

char *CalcMain(char *operand1, char *enzanshi, char *operand2)
{
	char *answer;

	if(PrintTrimedOperandFlag)
	{
		char *to = Calc(operand1, "+", "0");
		cout("[L]\n%s\n", to);
		memFree(to);
	}
	if(strchr("+-*/", *enzanshi))
	{
		if(PrintTrimedOperandFlag)
		{
			char *to = Calc(operand2, "+", "0");
			cout("[R]\n%s\n", to);
			memFree(to);
		}
		answer = Calc(operand1, enzanshi, operand2);
	}
	else if(*enzanshi == 'M')
	{
		answer = CalcModulo(operand1, operand2);
	}
	else if(*enzanshi == 'P')
	{
		answer = CalcPower(operand1, s2i(operand2));
	}
	else if(*enzanshi == 'R')
	{
		answer = CalcRoot(operand1, s2i(operand2));
	}
	else if(*enzanshi == 'X')
	{
		answer = CalcChangeRadix(operand1, s2i(operand2));
	}
	else
	{
		error_m("不明な演算子が指定されました。");
	}
	return answer;
}
